using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dohome.Model.Product
{
    public class GetCategorySuggestion
    {
        public Categorysuggestion[] categorySuggestions { get; set; }
    }

    public class Categorysuggestion
    {
        public string categoryPath { get; set; }
        public string categoryName { get; set; }
        public string categoryId { get; set; }
    }

}
