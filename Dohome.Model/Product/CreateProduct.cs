using System;
using System.Collections.Generic;

namespace Dohome.Model.Product
{
    public class CreateProduct
    {
        public string item_id { get; set; }
        public List<sku_list> sku_list { get; set; }
    }

    public class sku_list
    {
        public string shop_sku { get; set; }
        public string seller_sku { get; set; }
        public string sku_id { get; set; }
    }
}
