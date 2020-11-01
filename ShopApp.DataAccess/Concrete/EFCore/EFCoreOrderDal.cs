using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EFCore
{
    public class EFCoreOrderDal:EFCoreGenericRepository<Order,ShopContext>,IOrderDal
    {
    }
}
