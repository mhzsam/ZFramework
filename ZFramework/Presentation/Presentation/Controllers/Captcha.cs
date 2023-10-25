using Application.DTO.Captcha;
using Application.DTO.ResponseModel;
using Application.Helper;
using Application.Service.MoviesService;
using Application.Service.ResponseService;
using Application.Service.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers
{
    [AllowAnonymous]
    public class Captcha : BaseController
    {


        public Captcha(IResponseService responseService) : base(responseService) { }

        [HttpGet]
        public RessponseModel GetCaptcha()
        {
            GetCaptchaModel captcha = CaptchaHelper.GetCaptcha();
            if (captcha == null || string.IsNullOrEmpty(captcha.Base64Image))
            {
                return responseGenerator.Fail(System.Net.HttpStatusCode.Conflict, "اشکال در پردازش");
            }
            return responseGenerator.SuccssedWithResult(captcha);

        }

        [HttpPost]
        public RessponseModel ValidateCaptcha(VaslidateCaptchaModel model)
        {
            if (CaptchaHelper.ValidateCaptcha(model))
                return responseGenerator.Succssed();
            return responseGenerator.Fail(System.Net.HttpStatusCode.NotFound, "کپچا صحیح نمی باشد  ");
        }

    }
}
