using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helper
{
    public static class Mapper<TDestination>
        where TDestination : class
        
    {
        public static TDestination ToEntity(object sourceType)
        {
          return (sourceType).Adapt<TDestination>();
        }
    }
}
