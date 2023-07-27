using AutoMapper;
using CRUDDemo.Business.Product.Interface;
using CRUDDemo.Business.Product.Service;
using CRUDDemo.Data.DataAccessObjects.Product.Interfaces;
using CRUDDemo.Entity.Product;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CRUDDemo.Tests.Business.Product
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly Mock<IProductImpl> _mockProductImpl;
        private readonly Mock<IMapper> _mockMapper;

        public ProductServiceTest()
        {
            _mockProductImpl = new Mock<IProductImpl>();
            _mockProductService = new Mock<IProductService>();
            _mockMapper = new Mock<IMapper>();

        }

        [Fact]
        public async Task TestInsertProductAsync()
        {
            var productModel = new ProductModel
            {
                ProductName = "測試用",
                Price = 10,
                Description = "測試"
            };
            _mockProductService.Setup(x => x.InsertProductAsync(productModel)).ReturnsAsync(new ProductModel { Price = 10, ProductName = "測試用", Description = "測試" });


            var prodcutService = new ProductService(_mockProductImpl.Object, _mockMapper.Object);

            var result = await prodcutService.InsertProductAsync(productModel);

            Assert.Equal(new ProductModel { Price = 10, ProductName = "測試用", Description = "測試" }, result);
        }
    }
}
