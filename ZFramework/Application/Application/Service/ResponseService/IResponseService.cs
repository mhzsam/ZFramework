using Application.DTO.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ResponseService
{
    public interface IResponseService
    {
        public RessponseModel Succssed();

        public RessponseModel SuccssedWithResult(object result);

        public RessponseModel SuccssedWithPagination(object result,int total,int pageNumber,int pageRowNumber);

        public RessponseModel Fail(HttpStatusCode httpStatusCode, string message);

        public RessponseModel FailWithCustomErrorCode();
       
    }
}
