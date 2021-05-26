using Dohome.DAL;
using Dohome.Model;
using System.Data;
using System.Web.Http;

namespace Dohome.API.Controllers
{
    public class AliveController : ApiController
    {
        #region //--- Properties ---//
        public static helper _helper = null;
        public static helper helper
        {
            get { return (_helper == null) ? _helper = new helper() : _helper; }
        }
        #endregion

        [HttpGet]
        public ResponseInfo<AliveResponse> GetAlive()
        {
            ResponseInfo<AliveResponse> responseInfo = new ResponseInfo<AliveResponse>();
            AliveResponse alive = new AliveResponse();
            alive.isAlive = true;
            responseInfo.data = alive;
            return responseInfo;
        }

        [HttpPost]
        public ResponseInfo<AliveResponse> Test([FromBody] TokenRequest request)
        {
            ResponseInfo<AliveResponse> responseInfo = new ResponseInfo<AliveResponse>();
            AliveResponse alive = new AliveResponse();
            alive.isAlive = true;
            responseInfo.data = alive;
            return responseInfo;
        }
    }
}
