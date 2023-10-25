using Application.DTO.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ResponseService
{
    public class ResponseService : IResponseService
    {
        public RessponseModel Fail(HttpStatusCode httpStatusCode, string message)
        {
           return new RessponseModel(false,null,null,message,httpStatusCode) ;
        }

        public RessponseModel FailWithCustomErrorCode()
        {
            throw new NotImplementedException();
        }

        public RessponseModel Succssed()
        {
            return new RessponseModel(true, null, null,null,HttpStatusCode.OK);
        }

        public RessponseModel SuccssedWithPagination(object result, int total, int pageNumber, int rowPerPage)
        {
            return new RessponseModel(true, result, new Pagination(total,pageNumber,rowPerPage), null, HttpStatusCode.OK);

        }

        public RessponseModel SuccssedWithResult(object result)
        {
            return new RessponseModel(true, result, null, null, HttpStatusCode.OK);
        }
    }
}
