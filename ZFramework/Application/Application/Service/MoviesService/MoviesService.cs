using Application.DTO.ResponseModel;
using Application.Interface;
using Application.Service.ResponseService;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Domain.Entites;
using Domain.Entites.Movies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Service.MoviesService.MoviesEnums;
using Category = Domain.Entites.Movies.Category;

namespace Application.Service.MoviesService
{
    public class MoviesService : IMoviesService
    {
        private readonly IResponseService responseGenerator;
        private readonly IUnitOfWork _unitOfWork;



        public MoviesService(IResponseService responseGenerator, IUnitOfWork unitOfWork)
        {
            this.responseGenerator = responseGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<RessponseModel> AddOrUpdateByExcelFile(IFormFile file, MoviesEnums.ExcelFileType type)
        {
            Stopwatch time = Stopwatch.StartNew();

            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(file.OpenReadStream(), false);


            var Extension = System.IO.Path.GetExtension(file.FileName);

            if (Extension != ".xlsx")
                return responseGenerator.Fail(System.Net.HttpStatusCode.BadRequest, "فرمت فایل صحیح نمی باشد ");

            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
            WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

            if (sheetData is null || sheetData.Elements<Row>().Count() == 0)
                return responseGenerator.Fail(System.Net.HttpStatusCode.NoContent, "داده ایی پیدا نشد ");


            dynamic result = type switch
            {
                MoviesEnums.ExcelFileType.Movies => await GetMovieList(sheetData.Elements<Row>(), workbookPart),
                MoviesEnums.ExcelFileType.categores => await GetCategoryList(sheetData.Elements<Row>(), workbookPart),
            };

            spreadsheetDocument.Dispose();

            bool addOrUpdateResult = false;
            if (result is List<Movie>)
            {
                addOrUpdateResult = await AddorUpdateMoviesAsync(result);

            }
            else
            {
                addOrUpdateResult = await AddorUpdateCategoryAsync(result);
            }

            time.Stop();
            return addOrUpdateResult ? responseGenerator.SuccssedWithResult($"time={time.ElapsedMilliseconds}") : responseGenerator.Fail(System.Net.HttpStatusCode.Conflict, "اشکال در بروز رسانی");

        }

        private async Task<List<Movie>> GetMovieList(IEnumerable<Row> rows, WorkbookPart workbookPart)
        {
            List<Movie> lst = new List<Movie>();
            foreach (Row r in rows)
            {
                if (r.RowIndex == "1")
                {
                    continue;
                }

                List<string> stringLst = new List<string>();

                foreach (Cell c in r.Elements<Cell>())
                {

                    var value = c.CellValue.Text;
                    if (c.DataType != null && c.DataType == CellValues.SharedString)
                    {
                        var stringId = Convert.ToInt32(c.InnerText);
                        value = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(stringId).InnerText;
                    }
                    else
                    {
                        value = DateTime.FromOADate(double.Parse(value)).ToString("yyyy/MM/dd");
                    }

                    stringLst.Add(value);
                }

                var arry = stringLst.ToArray();
                lst.Add(new Movie()
                {
                    Code = Convert.ToInt32(arry[0].Contains(",") ? arry[0].Replace(",", "") : arry[0]),
                    Name = arry[1],
                    Status = arry[2] == "فعال" ? MovieStatus.Active : MovieStatus.DeActive,
                    CategoryCode = Convert.ToInt32(arry[3].Contains(",") ? arry[3].Replace(",", "") : arry[3]),
                    Descriptions = arry[4],
                    UpdateDate = Convert.ToDateTime(arry[5]),
                }); ;
            }
            return lst;
        }
        private async Task<List<Domain.Entites.Movies.Category>> GetCategoryList(IEnumerable<Row> rows, WorkbookPart workbookPart)
        {
            List<Domain.Entites.Movies.Category> lst = new List<Domain.Entites.Movies.Category>();
            foreach (Row r in rows)
            {
                if (r.RowIndex == "1")
                {
                    continue;
                }

                List<string> stringLst = new List<string>();
                List<Cell> cellLst = r.Elements<Cell>().ToList();

                for (int i = 0; i < cellLst.Count(); i++)
                {
                    Cell c = cellLst[i];
                    var value = c.CellValue.Text;
                    if (c.DataType != null && c.DataType == CellValues.SharedString)
                    {
                        var stringId = Convert.ToInt32(c.InnerText);
                        value = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(stringId).InnerText;
                    }
                    if (value != "" && i == 4)
                    {
                        value = DateTime.FromOADate(double.Parse(value)).ToString("yyyy/MM/dd");
                    }
                    stringLst.Add(value);
                }

                //foreach (Cell c in r.Elements<Cell>())
                //{

                //    var value = c.CellValue.Text;
                //    if (c.DataType != null && c.DataType == CellValues.SharedString)
                //    {
                //        var stringId = Convert.ToInt32(c.InnerText);
                //        value = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(stringId).InnerText;
                //    }
                //    if(value != ""&& i==4)
                //    {
                //        value = DateTime.FromOADate(double.Parse(value)).ToString("yyyy/MM/dd");
                //    }

                //    stringLst.Add(value);
                //}

                var arry = stringLst.ToArray();
                lst.Add(new Domain.Entites.Movies.Category()
                {
                    Code = Convert.ToInt32(arry[0].Contains(",") ? arry[0].Replace(",", "") : arry[0]),
                    Name = arry[1],
                    Status = arry[2] == "فعال" ? CategoryStatus.Active : CategoryStatus.DeActive,
                    Description = arry[3],
                    UpdateDate = Convert.ToDateTime(arry[4]),
                    Priorty = Convert.ToInt32(arry[5].Contains(",") ? arry[5].Replace(",", "") : arry[5]),
                }); ;
            }
            return lst;
        }
        private async Task<bool> AddorUpdateCategoryAsync(List<Domain.Entites.Movies.Category> categories)
        {
            try
            {

                int batchFindSize = 200;

                await _unitOfWork.BeginTransactionAsync();

                var categoryRepositopry = _unitOfWork.GetRepository<Domain.Entites.Movies.Category>();


                int totalRow = await categoryRepositopry.TotalRecords();

                BlockingCollection<Domain.Entites.Movies.Category> updateLst = new BlockingCollection<Domain.Entites.Movies.Category>();
                BlockingCollection<Domain.Entites.Movies.Category> AddLst = new BlockingCollection<Domain.Entites.Movies.Category>();
                BlockingCollection<Domain.Entites.Movies.Category> removeLst = new BlockingCollection<Domain.Entites.Movies.Category>();


                if (batchFindSize > 200)
                {

                    int loop = (int)Math.Ceiling((double)totalRow / batchFindSize);
                    for (int i = 0; i < loop; i++)
                    {
                        var availableLst = await categoryRepositopry.GetAllAsync(i, batchFindSize);


                        Parallel.For(0, categories.Count(), i =>
                        {

                            foreach (var available in availableLst)
                            {
                                //در اینجا می تونیم بررسی کنیم اگر بیش از یک رکورد باشه الباقی را حذف کنه
                                if (available.Code == categories[i].Code)
                                {
                                    categories[i].Id = available.Id;
                                    updateLst.Add(categories[i]);
                                    break;
                                }
                            }


                        });
                    }

                    Parallel.For(0, categories.Count(), i =>
                    {
                        bool isFind = false;
                        foreach (var update in updateLst)
                        {
                            //در اینجا می تونیم بررسی کنیم اگر بیش از یک رکورد باشه الباقی را حذف کنه
                            if (update.Code == categories[i].Code)
                            {
                                break;
                            }
                        }
                        if (!isFind)
                        {
                            AddLst.Add(categories[i]);

                        }


                    });

                }
                else
                {
                    batchFindSize = totalRow;
                    var availableLst = await categoryRepositopry.GetAllAsync(1, batchFindSize);

                    //List<Domain.Entites.Movies.Category> availableLst = await categoryRepositopry.GetAllAsync(1, batchFindSize);

                    foreach (var category in categories)
                    {
                        bool isFind = false;
                        foreach (var available in availableLst)
                        {
                            //در اینجا می تونیم بررسی کنیم اگر بیش از یک رکورد باشه الباقی را حذف کنه
                            if (available.Code == category.Code)
                            {
                                category.Id = available.Id;
                                updateLst.Add(category);
                                isFind = true;
                                break;
                            }
                        }
                        if (!isFind)
                        {
                            AddLst.Add(category);
                        }

                    }


                }
                if (AddLst is not null && AddLst.ToList().Count() > 0)
                {
                    await categoryRepositopry.BulkInsertAsync(AddLst.ToList());

                }
                if (updateLst is not null && updateLst.ToList().Count() > 0)
                {
                    await categoryRepositopry.BulkUpdateAsync(updateLst.ToList());

                }

                await _unitOfWork.BulkSaveChangesAsync();
                _unitOfWork.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                return false;
            }

        }
        private async Task<bool> AddorUpdateMoviesAsync(List<Movie> movies)
        {
            try
            {

                int batchFindSize = 300;

                await _unitOfWork.BeginTransactionAsync();

                var movieRepositopry = _unitOfWork.GetRepository<Movie>();


                int totalRow = await movieRepositopry.TotalRecords();

                BlockingCollection<Movie> updateLst = new BlockingCollection<Movie>();
                BlockingCollection<Movie> AddLst = new BlockingCollection<Movie>();
                BlockingCollection<Movie> removeLst = new BlockingCollection<Movie>();


                if (batchFindSize > 200)
                {
                    int loop = (int)Math.Ceiling((double)totalRow / batchFindSize);
                    for (int i = 1; i <= loop; i++)
                    {
                        var availableLst = await movieRepositopry.GetAllAsync(i, batchFindSize);


                        Parallel.For(0, movies.Count(), i =>
                        {

                            foreach (var available in availableLst)
                            {
                                //در اینجا می تونیم بررسی کنیم اگر بیش از یک رکورد باشه الباقی را حذف کنه
                                if (available.Code == movies[i].Code)
                                {
                                    movies[i].Id = available.Id;
                                    updateLst.Add(movies[i]);
                                    break;
                                }
                            }


                        });
                    }

                    Parallel.For(0, movies.Count(), i =>
                    {
                        bool isFind = false;
                        foreach (var update in updateLst)
                        {
                            //در اینجا می تونیم بررسی کنیم اگر بیش از یک رکورد باشه الباقی را حذف کنه
                            if (update.Code == movies[i].Code)
                            {
                                isFind = true;
                                break;
                            }

                        }
                        if (!isFind)
                        {
                            AddLst.Add(movies[i]);

                        }


                    });
                }
                else
                {
                    batchFindSize = totalRow;
                    var availableLst = await movieRepositopry.GetAllAsync(1, batchFindSize);

                    //List<Domain.Entites.Movies.Category> availableLst = await categoryRepositopry.GetAllAsync(1, batchFindSize);

                    foreach (var movie in movies)
                    {
                        bool isFind = false;
                        foreach (var available in availableLst)
                        {
                            //در اینجا می تونیم بررسی کنیم اگر بیش از یک رکورد باشه الباقی را حذف کنه
                            if (available.Code == movie.Code)
                            {
                                movie.Id = available.Id;
                                updateLst.Add(movie);
                                isFind = true;
                                break;
                            }
                        }
                        if (!isFind)
                        {
                            AddLst.Add(movie);
                        }

                    }


                }
                if (AddLst is not null && AddLst.ToList().Count() > 0)
                {
                    await movieRepositopry.BulkInsertAsync(AddLst.ToList());


                }
                if (updateLst is not null && updateLst.ToList().Count() > 0)
                {

                    await movieRepositopry.BulkUpdateAsync(updateLst.ToList());

                }

                await _unitOfWork.BulkSaveChangesAsync();
                _unitOfWork.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                return false;
            }

        }

        public async Task<RessponseModel> GetTopCategoryWithMOvies()
        {
            try
            {
                var repo = _unitOfWork.GetMovieRepository();
                var res = await repo.GetTopCategoryWithMOvies();

                return responseGenerator.SuccssedWithResult(res);

            }
            catch (Exception ex)
            {
                return responseGenerator.Fail(System.Net.HttpStatusCode.BadRequest, "خطا");
            }
        }
    }
}
