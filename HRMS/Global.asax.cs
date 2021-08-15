using Layer.Model.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HRMS
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //App_Start.AutoMapperConfig.Initialize();

            #region DataBase ConnectionString Setting
            AppSetting.DatabaseProvider = "System.Data.SqlClient";
            var serverName = ConfigurationManager.AppSettings["ServerName"].ToString();
            var dataBaseName = ConfigurationManager.AppSettings["DataBaseName"].ToString();
            var username = ConfigurationManager.AppSettings["UserName"].ToString();
            var password = ConfigurationManager.AppSettings["Password"].ToString();
            var apiUrl = ConfigurationManager.AppSettings["ApiUrl"].ToString();

            //AppSetting.ServerName = DataEncryptionUtilities.GenerateDecryptedString(serverName);
            //AppSetting.DataBaseName = DataEncryptionUtilities.GenerateDecryptedString(dataBaseName);
            //AppSetting.UserName = DataEncryptionUtilities.GenerateDecryptedString(username);
            //AppSetting.Password = DataEncryptionUtilities.GenerateDecryptedString(password);

            AppSetting.ServerName = serverName;
            AppSetting.DataBaseName = dataBaseName;
            AppSetting.UserName = username;
            AppSetting.Password = password;
            AppSetting.ApiUrl = apiUrl;


            AppSetting.ConnectionString = string.Format("server={0} ; database={1} ; uid={2} ; pwd={3} ;", AppSetting.ServerName, AppSetting.DataBaseName, AppSetting.UserName, AppSetting.Password);
            #endregion
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            newCulture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = newCulture;
        }
    }
}
