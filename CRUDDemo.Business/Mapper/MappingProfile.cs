using AutoMapper;
using CRUDDemo.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDemo.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, ProductEntity>();
            CreateMap<ProductEntity, ProductModel>();
        }
    }
}
