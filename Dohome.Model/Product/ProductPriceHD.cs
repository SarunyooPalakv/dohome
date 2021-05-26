using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model.Product
{
    public class ProductPriceHD
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string TotalRecord { get; set; }
        public string SuccessRecord { get; set; }
        public string FailRecord { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
