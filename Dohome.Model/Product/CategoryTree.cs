using System;
using System.Collections.Generic;

namespace Dohome.Model.Product
{
    public class CategoryTree
    {
        public int category_id { get; set; }
        public List<children> children { get; set; }
    }

    public class children
    {
        public int category_id { get; set; }
        public bool var { get; set; }
        public string name { get; set; }
        public bool leaf { get; set; }
    }
}
