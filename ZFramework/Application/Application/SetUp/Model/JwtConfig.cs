using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SetUp.Model
{
    public class JwtConfig
    {
        public string TokenKey { get; set; }
        public int TokenTimeOut { get; set; }
    }
}
