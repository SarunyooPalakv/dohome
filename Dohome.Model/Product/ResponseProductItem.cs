using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model.Product
{
    public class ResponseProductItem
    {        
        public int primary_category { get; set; }
        public ProductItemAttribute attributes { get; set; }
        public List<ProductItemSku> skus { get; set; }
        public int item_id { get; set; }
    }

    public class ProductItemSku
    {
        public string Status { get; set; }
        public Int64 SkuId { get; set; }
        public int quantity { get; set; }
        public string product_weight { get; set; }
        public List<string> Images { get; set; }
        public string SellerSku { get; set; }
        public string ShopSku { get; set; }
        public string Url { get; set; }
        public string package_width { get; set; }
        public string special_to_time { get; set; }
        public string special_from_time { get; set; }
        public string package_height { get; set; }
        public decimal special_price { get; set; }
        public decimal price { get; set; }
        public string package_length { get; set; }
        public string package_weight { get; set; }
        public int Available { get; set; }
        public string special_to_date { get; set; }
    }

    public class ProductItemAttribute
    {
        public string description { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string short_description { get; set; }
        public string warranty_type { get; set; }
    }
}
