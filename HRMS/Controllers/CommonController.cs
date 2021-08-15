using Layer.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class CommonController : BaseController
    {
        //private readonly ICommonBALManager _commonBalManager;
        public CommonController()
        {
            //_commonBalManager = new CommonBALManager();
        }
        public JsonResult GetRoleCombo()
        {
            var data = from UserRole e in Enum.GetValues(typeof(UserRole)) select new { Id = (int)e, Name = e.ToString() };
            var list = data.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name.ToString(),
                Selected = Convert.ToInt32(o.Id) == (int)DateTime.UtcNow.Month ? true : false
            });
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMonthCombo()
        {
            var data = from Month e in Enum.GetValues(typeof(Month)) select new { Id = (int)e, Name = e.ToString() };
            var list = data.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name.ToString(),
                Selected = Convert.ToInt32(o.Id) == (int)DateTime.UtcNow.Month ? true : false
            });

            return Json(list, JsonRequestBehavior.AllowGet);
        }



    }

}