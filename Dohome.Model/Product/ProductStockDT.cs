using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model.Product
{
    public class ProductStockDT
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string SiteGroup { get; set; }
        public string EcomSite { get; set; }
        public string Quantity { get; set; }
        public string ReorderPoint { get; set; }
        public string ScaleGroup { get; set; }
        public string DeliveryDate { get; set; }
        public string UOM { get; set; }
        public bool ItemFlag { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
    }
}
