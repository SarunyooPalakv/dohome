using Dohome.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Dohome.API.Controllers
{
    public class BaseController : ApiController
    {
        #region //--- Properties ---//
        private string _baseAddress = null;
        private string baseAddress
        {
            get { return (_baseAddress == null) ? _baseAddress = System.Configuration.ConfigurationManager.AppSettings["APIMainURL"] : _baseAddress; }
        }

        private static string _LazadaAuthApiUrl = null;
        public static string LazadaAuthApiUrl
        {
            get { return (_LazadaAuthApiUrl == null) ? _LazadaAuthApiUrl = System.Configuration.ConfigurationManager.AppSettings["LazadaAuthApiUrl"] : _LazadaAuthApiUrl; }
        }

        private static string _LazadaApiUrl = null;
        public static string LazadaApiUrl
        {
            get { return (_LazadaApiUrl == null) ? _LazadaApiUrl = System.Configuration.ConfigurationManager.AppSettings["LazadaApiUrl"] : _LazadaApiUrl; }
        }

        private static string _LazadaAppkey = null;
        public static string LazadaAppkey
        {
            get { return (_LazadaAppkey == null) ? _LazadaAppkey = System.Configuration.ConfigurationManager.AppSettings["LazadaAppkey"] : _LazadaAppkey; }
        }

        private static string _LazadaAppSecret = null;
        public static string LazadaAppSecret
        {
            get { return (_LazadaAppSecret == null) ? _LazadaAppSecret = System.Configuration.ConfigurationManager.AppSettings["LazadaAppSecret"] : _LazadaAppSecret; }
        }
        #endregion

        protected string apiPathAndQuery { get; set; }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            HttpRequestMessage request = controllerContext.Request;
            var authorization = request.Headers.Authorization;
            //var token = authorization.Parameter;
            var controller = request.GetRouteData().Values["controller"];
            var acction = request.GetRouteData().Values["action"];
            var RequestURLParams = request.RequestUri.Query;
            var content = request.Content;
            string jsonContent = content.ReadAsStringAsync().Result;
            apiPathAndQuery = string.Format("/api/v1/{0}/{1}{2}", controller, acction, RequestURLParams);
        }

        protected T GetDataFromAPINotAuthen<T>(string pathAndQuery) where T : new()
        {
            T ObjReturn = new T();
            bool isSuccess = false;
            var _obj = GetObjFormAPI<T>(ref isSuccess, baseAddress, pathAndQuery);
            if (_obj != null && _obj is T)
            {
                ObjReturn = _obj;
            }
            else if (_obj != null && _obj is SystemExceptionReturn<string>)
            {
                ObjReturn = _obj;
            }
            return ObjReturn;
        }

        protected T PostDataToAPINotAuth<T>(string _requstUri, object objPost) where T : new()
        {
            T ObjReturn = new T();
            bool isSuccess = false;
            var _obj = PostObjToAPI<T>(ref isSuccess, objPost, baseAddress, _requstUri);
            if (_obj != null && _obj is T)
            {
                ObjReturn = _obj;
            }
            else if (_obj != null && _obj is SystemExceptionReturn<string>)
            {
                ObjReturn = _obj;
            }
            return ObjReturn;
        }

        protected T GetObjFormAPI<T>(ref bool isSuccess, string baseAddress, string requstUri) where T : new()
        {
            T objResult;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(AppConfig.RequestTimeout);
                    requstUri = baseAddress + requstUri;
                    HttpResponseMessage _response = client.GetAsync(requstUri).Result;

                    if (_response.IsSuccessStatusCode)
                    {
                        isSuccess = true;
                    }
                    else
                    {
                        isSuccess = false;
                    }

                    objResult = _response.Content.ReadAsAsync<T>().Result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResult;
        }

        protected T PostObjToAPI<T>(ref bool isSuccess, object obj, string baseAddress, string requstUri) where T : new()
        {
            T objResult;

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(AppConfig.RequestTimeout);
                    requstUri = baseAddress.TrimEnd('/') + requstUri;
                    var _response = client.PostAsync(requstUri, new StringContent(JsonConvert.SerializeObject(obj).ToString(), Encoding.UTF8, "application/json")).Result;

                    if (_response.IsSuccessStatusCode)
                    {
                        isSuccess = true;
                    }
                    else
                    {
                        isSuccess = false;
                    }

                    objResult = _response.Content.ReadAsAsync<T>().Result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return objResult;
        }
    }
}
