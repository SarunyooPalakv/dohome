using Dohome.DAL;
using Dohome.Model;
using Dohome.Model.Base;
using Lazop.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Dohome.Lazada
{
    public class LazadaAccess
    {
        #region //--- Properties ---//
        public static helper _helper = null;
        public static helper helper
        {
            get { return (_helper == null) ? _helper = new helper() : _helper; }
        }

        #endregion

        private string url;
        private string appkey;
        private string appSecret;
        private string authUrl;


        public LazadaAccess(string url, string authUrl, string appkey, string appSecret)
        {
            this.url = url;
            this.appkey = appkey;
            this.appSecret = appSecret;
            this.authUrl = authUrl;
        }

        public LazopResponse GetNoAuthen(string apiName, List<ApiParameters> apiParameters = null, string offset = "0", string limit = "100")
        {
            ILazopClient client = new LazopClient(url, appkey, appSecret);
            LazopRequest request = new LazopRequest();
            request.SetApiName(apiName);
            request.SetHttpMethod("GET");
            request.AddApiParameter("offset", offset);
            request.AddApiParameter("limit", limit);
            if (apiParameters != null && apiParameters.Count > 0) {
                for (int i = 0; i<apiParameters.Count; i++) {
                    request.AddApiParameter(apiParameters[i].key, apiParameters[i].value);
                }
            }
            return client.Execute(request);
        }

        public LazopResponse GetAuthen(string apiName, List<ApiParameters> apiParameters = null, string offset = "0", string limit = "100")
        {
            LazopResponse response = new LazopResponse();
            string access_token = GetAccessToken();
            if (access_token != "")
            {
                ILazopClient client = new LazopClient(url, appkey, appSecret);
                LazopRequest request = new LazopRequest();
                request.SetApiName(apiName);
                request.SetHttpMethod("GET");
                request.AddApiParameter("offset", offset);
                request.AddApiParameter("limit", limit);
                if (apiParameters != null && apiParameters.Count > 0)
                {
                    for (int i = 0; i < apiParameters.Count; i++)
                    {
                        request.AddApiParameter(apiParameters[i].key, apiParameters[i].value);
                    }
                }
                response = client.Execute(request, access_token);
            }
            else {
                response.Code = "401";
                response.Message = "AccessToken is expired. Please Get new AuthenticationCode";
            }

            return response;
        }

        public LazopResponse PostNoAuthen(string apiName, List<ApiParameters> apiParameters = null)
        {
            ILazopClient client = new LazopClient(url, appkey, appSecret);
            LazopRequest request = new LazopRequest();
            request.SetApiName(apiName);

            if (apiParameters != null && apiParameters.Count > 0)
            {
                for (int i = 0; i < apiParameters.Count; i++)
                {
                    request.AddApiParameter(apiParameters[i].key, apiParameters[i].value);
                }
            }
            return client.Execute(request);
        }

        public LazopResponse PostAuthen(string apiName, List<ApiParameters> apiParameters = null)
        {
            LazopResponse response = new LazopResponse();
            string access_token = GetAccessToken();
            if (access_token != "")
            {
                ILazopClient client = new LazopClient(url, appkey, appSecret);
                LazopRequest request = new LazopRequest();
                request.SetApiName(apiName);
                if (apiParameters != null && apiParameters.Count > 0)
                {
                    for (int i = 0; i < apiParameters.Count; i++)
                    {
                        request.AddApiParameter(apiParameters[i].key, apiParameters[i].value);
                    }
                }
                response = client.Execute(request, access_token);
            }
            else
            {
                response.Code = "401";
                response.Message = "AccessToken is expired. Please Get new AuthenticationCode";
            }

            return response;
        }

        public static AccessToken _accessToken = null;
        public static AccessToken getAccessToken {
            get
            {
                if (_accessToken == null) {
                    _accessToken = helper.ExecuteQuery<AccessToken>("sp_Get_AccessToken", null, System.Data.CommandType.StoredProcedure).FirstOrDefault();
                }
                return _accessToken;
            }
        }

        private string GetAccessToken() {

            string access_token = "";

            //AccessToken accessToken = helper.ExecuteQuery<AccessToken>("sp_Get_AccessToken", null, System.Data.CommandType.StoredProcedure).FirstOrDefault();

            AccessToken accessToken = getAccessToken;

            if (accessToken != null)
            {
                if(accessToken.expires_on <= accessToken.datenow && accessToken.refresh_expires_on <= accessToken.datenow)
                {
                    //call api create token
                    access_token = CreateAccessToken();
                }
                else if(accessToken.expires_on <= accessToken.datenow)
                {
                    //call api refresh token
                    access_token = RefreshAccessToken(accessToken);
                }
                else
                {
                    //return access token
                    access_token = accessToken.access_token;
                }
            }
            else
            {
                //call api create token
                access_token = CreateAccessToken();
            }

            return access_token;
        }

        private string CreateAccessToken() {

            string access_token = "";

            //Get code from db
            SysConfig sysConfig = helper.ExecuteQuery<SysConfig>("sp_Get_SysConfig", new { sys_key = "AuthenticationCode" }, System.Data.CommandType.StoredProcedure).FirstOrDefault();

            if (sysConfig != null)
            {
                ILazopClient client = new LazopClient(authUrl, appkey, appSecret);
                LazopRequest request = new LazopRequest();
                request.SetApiName("/auth/token/create");
                request.AddApiParameter("code", sysConfig.sys_value);
                LazopResponse result = client.Execute(request);

                CreateAccessToken accessToken = JsonConvert.DeserializeObject<CreateAccessToken>(result.Body);

                if (accessToken.code == "0")
                {
                    access_token = accessToken.access_token;

                    //insert access token
                    InsertAccessToken(accessToken);
                }
            }
            
            return access_token;
        }

        private string RefreshAccessToken(AccessToken accessToken) {
            string access_token = "";

            if(accessToken != null)
            {
                ILazopClient client = new LazopClient(authUrl, appkey, appSecret);
                LazopRequest request = new LazopRequest();
                request.SetApiName("/auth/token/refresh");
                request.AddApiParameter("refresh_token", accessToken.refresh_token);
                LazopResponse result = client.Execute(request);

                CreateAccessToken createAccessToken = JsonConvert.DeserializeObject<CreateAccessToken>(result.Body);

                if (createAccessToken.code == "0")
                {
                    access_token = createAccessToken.access_token;

                    //insert access token
                    InsertAccessToken(createAccessToken);
                }
            }

            return access_token;
        }

        private void InsertAccessToken(CreateAccessToken accessToken) {
            helper.ExecuteNonQuery("sp_Ins_AccessToken", new
            {
                access_token = accessToken.access_token,
                expires_in = accessToken.expires_in,
                account_id = accessToken.account_id,
                country = accessToken.country,
                country_user_info = JsonConvert.SerializeObject(accessToken.country_user_info),
                account_platform = accessToken.account_platform,
                account = accessToken.account,
                refresh_token = accessToken.refresh_token,
                refresh_expires_in = accessToken.refresh_expires_in
            }, System.Data.CommandType.StoredProcedure);
        }
    }
}