using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppUI.Models
{
    public class ProductListModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
