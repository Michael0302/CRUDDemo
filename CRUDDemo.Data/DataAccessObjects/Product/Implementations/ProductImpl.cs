using BaseCore.Base.Impl;
using CRUDDemo.Data.DataAccessObjects.Product.Interfaces;
using CRUDDemo.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDemo.Data.DataAccessObjects.Product.Implementations
{
    public class ProductImpl : BaseImpl<ProductEntity>, IProductImpl
    {
    }
}
