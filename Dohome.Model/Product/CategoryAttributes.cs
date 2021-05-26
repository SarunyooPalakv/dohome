using System;
using System.Collections.Generic;

namespace Dohome.Model.Product
{
    public class CategoryAttributes
    {
        public string label { get; set; }
        public string name { get; set; }
        public string is_mandatory { get; set; }
        public string attribute_type { get; set; }
        public string input_type { get; set; }
        public List<Options> options { get; set; }
        public string is_sale_prop { get; set; }
    }

    public class Options
    {
        public string name { get; set; }
    }
}
