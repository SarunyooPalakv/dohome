using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model.Product.Price
{
    public class UpdatePriceQuantity
    {
        public List<PriceProduct> Product { get; set; }
    }

    public class PriceSku
    {
        public int index { get; set; }
        public string SellerSku { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string SalePrice { get; set; }
        public string SaleStartDate { get; set; }
        public string SaleEndDate { get; set; }
    }

    public class PriceSkus
    {
        public List<PriceSku> Sku { get; set; }

    }

    public class PriceProduct
    {
        public int index { get; set; }
        public PriceSkus Skus { get; set; }
    }

    //public class PriceRequest
    //{
    //    public List<PriceProduct> Product { get; set; }
    //}
}
