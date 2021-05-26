using System;
using System.Collections.Generic;

namespace Dohome.Model.Product
{
    public class CreateProductRequest
    {
        public Product Product { get; set; }
    }
    public class UpdateProduct
    {
        public ProductUpdate Product { get; set; }

    }
    public class ProductUpdate
    {
        public Attributes Attributes { get; set; }
        public Skus Skus { get; set; }
    }

    public class Product
    {
        public string PrimaryCategory { get; set; }
        public string SPUId { get; set; }
        public string AssociatedSku { get; set; }
        public Attributes Attributes { get; set; }
        public Skus Skus { get; set; }

    }

    public class Attributes
    {
        public string name { get; set; }
        public string short_description { get; set; }
        public string short_description_en { get; set; }
        public string description { get; set; }
        //public string video { get; set; }
        //public List<color_family> color_family { get; set; }
        public string warranty_type { get; set; }
        public List<Names> warranty { get; set; }
        public string name_en { get; set; }
        public string product_warranty { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string product_warranty_en { get; set; }
        //public List<Names> delivery_option_standard { get; set; }
        public string description_en { get; set; }
        //public List<Names> delivery_option_express { get; set; }
        //public List<Names> delivery_option_economy { get; set; }


    }

    public class Skus
    {
        public List<Sku> Sku { get; set; }
    }

    public class Sku
    {
        public string SellerSku { get; set; }
        public decimal price { get; set; }
        public int? quantity { get; set; }
        public decimal? special_price { get; set; }
        public DateTime? special_from_date { get; set; }
        public DateTime? special_to_date { get; set; }


        public List<string> color_family { get; set; }
        //public string size { get; set; }
        
        
        //public string special_price { get; set; }
        //public string special_from_date { get; set; }
        //public string delivery_option_standard { get; set; }
        //public string special_to_date { get; set; }
        public string package_content { get; set; }
        //public string package_contents_en { get; set; }
        public string package_weight { get; set; }
        public string package_length { get; set; }
        public string package_width { get; set; }
        public string package_height { get; set; }
        //public string __images__ { get; set; }
        //public List<Names> tax_class { get; set; }
        //public List<Names> zal_present { get; set; }
        //public List<Hazmat> Hazmat { get; set; }

        public List<Images> Images { get; set; }
    }

    public class Images
    {
        public string Image { get; set; }
    }

    public class color_family
    {
        public string name { get; set; }
    }

    public class Hazmat
    {
        public string name { get; set; }
    }

    public class Names
    {
        public string name { get; set; }
    }
}
