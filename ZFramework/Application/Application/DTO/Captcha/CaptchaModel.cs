using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Captcha
{
    public class GetCaptchaModel
    {
        public string CaptchaToken { get; set; }
        public string Base64Image { get; set; }
    }

    public class VaslidateCaptchaModel
    {
        public string CaptchaToken { get; set; }
        public string Key { get; set; }

    }
}
