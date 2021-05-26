using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model
{
    public class SystemExceptionReturn<T> where T : class
    {
        public SystemExceptionReturn()
        {
            ResponseInfo<T> responseInfo = new ResponseInfo<T>();
        }

        public ResponseInfo<T> ResponseInfo { get; set; }
    }
}
