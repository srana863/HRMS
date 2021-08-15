using Layer.Model.Common;
using Layer.Model.HRMS.Settings;
using System.Web.Mvc;
using System.Net.Http;

namespace HRMS.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var message = new ReturnMessage();
            if (TempData[AppSetting.TD_ERROR] != null)
            {
                message = TempData[AppSetting.TD_ERROR] as ReturnMessage;
            }
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            HttpResponseMessage response = ApiCallVariable.WebApiClient.GetAsync("Login/Login/userName=" + user.UserName).Result;
            var hasUser = response.Content.ReadAsAsync<UserInfoSession>().Result;
            session.DashboardController = "/Home";
            if (hasUser != null)
            {
                //if (password == DataEncryptionUtilities.GenerateDecryptedString(hasUser.Password))
                if (user.Password == hasUser.Password)
                {
                    session.UserInfo = hasUser;
                    System.Web.HttpContext.Current.Session[AppSetting.UserSession] = session;
                    TempData["Message"] = "";
                    session.DashboardController = "/Dashboard";
                    return Json(session, JsonRequestBehavior.AllowGet);
                }
            }
            TempData["Message"] = "Invalid User Name or Password";

            return Json(session, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session[AppSetting.UserSession] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
