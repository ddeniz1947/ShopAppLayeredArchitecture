using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EFCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        /// <summary>
        /// Manager içerisinde direk EFCoreProductDal çağırmak yerine
        /// IProductDal çağırarak , onun üzerinden EFCoreProductDal ' a erişebiliyoruz.
        /// Bu Sayede bağımlılıkları kaldırarak , ilerde başka bi DB yapısı gerektiğinde Manager kodunu
        /// değiştirmemize gerek kalmadan , sadece Db kodunun Interface kısmı değişecek. 
        /// (Örnek : MySQLProductDal oluşturursak , erişmek için ProductDal kullanılabilir.
        /// Sonuçta burda sadece Product Class ının işlemleri yapılacak.)
        /// Bu durumun konfigurasyonu , Startup.cs üzerinden , ConfigureServices methodunun içerisinde
        /// yapılır ve istenilen DB yaklaşımı Interface 'i orda çağrılıp implemente edilir.
        /// </summary>

        private IProductDal _productDal;
        /// <summary>
        /// Bu kkısımda çağıracağımız DB yaklaşımını içeren class Startup üzerinden çağrılır.
        /// Ve bu durumun adı , 'Dependency Injection' dır.
        /// </summary>

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Create(Product entity)
        {
            _productDal.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetPopularProducts()
        {
            return _productDal.GetAll();
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
