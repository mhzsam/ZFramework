using Domain.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Message
{
    public class NotificationTemplate :INotificationTemplate
    {
        private readonly string _template;

        public NotificationTemplate(string template)
        {
            _template = template ?? throw new ArgumentNullException(nameof(template));
        }

        public string Render(Dictionary<string, string> parameters)
        {
            string result = _template;
            foreach (var param in parameters)
            {
                result = result.Replace($"{{{param.Key}}}", param.Value);
            }
            return result;

            /*if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            return parameters.Aggregate(_template, (current, param) =>
                current.Replace($"{{{param.Key}}}", param.Value));*/
        }

    }
}
