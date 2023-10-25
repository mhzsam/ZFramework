
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ResponseModel
{
    public record class RessponseModel(
        bool IsSuccssed, 
        object Result,        
        Pagination Pagination,
        dynamic ErrorMessage, 
        HttpStatusCode ResponseCode);


    public record class Pagination(int Total, int PageNumber, int RowPerPage);
}
