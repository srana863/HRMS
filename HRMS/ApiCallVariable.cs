using Layer.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace HRMS
{
    public static class ApiCallVariable
    {
        public static HttpClient WebApiClient = new HttpClient();

        static ApiCallVariable()
        {
            WebApiClient.BaseAddress = new Uri(AppSetting.ApiUrl);
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}