using Layer.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class BaseController : Controller
    {
        public AppSession session;
        public ReturnMessage retunMessage;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (base.Session[AppSetting.UserSession] != null)
            {
                session = CurrentSession.GetCurrentSession();
                base.Session[AppSetting.UserSession] = session;
            }
            else
            {
                session = new AppSession();
                session.UserInfo = new UserInfoSession();
                filterContext.Result = new RedirectResult("~/Home");
            }
            base.Session[AppSetting.UserSession] = session;
            ViewBag.Session = session;
            ViewBag.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            ViewBag.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();

            base.OnActionExecuting(filterContext);
        }
    }
}