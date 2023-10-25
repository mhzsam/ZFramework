using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.MoviesService
{
    public class MoviesEnums
    {
        public enum ExcelFileType
        {
            Movies=1,
            categores=2
        }
        public enum MovieStatus
        {
            Active = 1,
            DeActive = 2
        }
        public enum CategoryStatus
        {
            Active = 1,
            DeActive = 2
        }

    }
}
