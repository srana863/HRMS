using Layer.Business.HRMS.Settings;
using Layer.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HRMSApi.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUsersManager _usersManager;
        public LoginController()
        {
            _usersManager = new UsersManager();
        }
        public IHttpActionResult Login(string userName)
        {
            var data = _usersManager.Login(userName);
            if (data == null) {
                return NotFound();
            }
            return Ok(data);
        }

        
    }
}
