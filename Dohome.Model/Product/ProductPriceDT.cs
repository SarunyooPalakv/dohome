using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model.Product
{
    public class ProductPriceDT
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string Site { get; set; }
        public string SalesOrganization { get; set; }
        public string DistributionChannel { get; set; }
        public string UOMCode { get; set; }
        public string UPC { get; set; }
        public string Conversion { get; set; }
        public string UnitWeight { get; set; }
        public string ConditionType { get; set; }
        public string PromotionNumber { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string Price { get; set; }
        public string AgentPrice { get; set; }
        public string ProjectPrice { get; set; }
        public string Currency { get; set; }
        public string ExportFlag { get; set; }
        public string ExportDescription { get; set; }
        public bool ItemFlag { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
    }
}
