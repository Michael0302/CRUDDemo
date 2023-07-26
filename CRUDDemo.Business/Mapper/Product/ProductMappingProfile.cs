using AutoMapper;
using CRUDDemo.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDemo.Business.Mapper.Product
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductModel, ProductEntity>();
            CreateMap<ProductEntity, ProductModel>();
        }
    }
}
