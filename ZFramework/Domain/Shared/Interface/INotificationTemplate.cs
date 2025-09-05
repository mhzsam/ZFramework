using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Interface
{
    public interface INotificationTemplate
    {
        string Render(Dictionary<string, string> parameters);
    }
}
