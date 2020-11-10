using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EFCore
{
    public class EFCoreProductDal : EFCoreGenericRepository<Product, ShopContext>, IProductDal
    {
        public Product GetProductDetails(int id)
        {
            using(var context = new ShopContext())
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category,int page,int productCount)
        {
            using(var context = new ShopContext())
            {
                var products = context.Products.AsQueryable();
                //AsQueryable ile gelecek sorgunun bir kopyası saklanır. 
                //Ne zaman Bir ToList çağrılırsa o zaman sorgu alınıp kullanıcıya gösterilir.
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(i =>i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(a=>a.Category.Name.ToLower() == category.ToLower()));
                    //Product tan => ProductCategories => Category alıyoruz . 
                    //Eğer burda gelen bi değer varsa Any() methodu true dönüyor.
                }
                return products.Skip((page-1)*productCount).Take(productCount).ToList();
                //Skip methodu ötelemek için , gelen değeri içindeki parametre kadar öteleyip , 
                //sonraki productCount kadar değeri Take ile alır
            }
        }
    }
}
