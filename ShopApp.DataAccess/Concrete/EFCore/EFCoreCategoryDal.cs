using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EFCore
{
    public class EFCoreCategoryDal : EFCoreGenericRepository<Category,ShopContext>,ICategoryDal
    {


    }
}
