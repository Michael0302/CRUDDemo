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

namespace CRUDDemo.UnitTests.Product
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
                Description = "測試",
            };

            var productEntity_Return = new ProductEntity
            {
                Id = 0,
                ProductName = "測試用",
                Price = 10,
                Description = "測試",
                CreateDateTime = DateTime.Parse("2023-07-27 16:00:00"),
                UpdateDateTime = DateTime.Parse("2023-07-27 16:00:00")
            };

            _mockProductImpl.Setup(x => x.InsertAsync(It.IsAny<ProductEntity>())).ReturnsAsync(productEntity_Return);

            var productModel_Result = _mockMapper.Object.Map<ProductModel>(productEntity_Return);

            var prodcutService = new ProductService(_mockProductImpl.Object, _mockMapper.Object);

            var result = await prodcutService.InsertProductAsync(productModel);

            Assert.Equal(productModel_Result, result);
        }

        [Fact]
        public async Task TestUpdateProductAsync()
        {
            var productModel = new ProductModel
            {
                Id = 1,
                ProductName = "測試用",
                Price = 10,
                Description = "測試",
            };

            var productEntity_Return = new ProductEntity
            {
                Id = 1,
                ProductName = "測試用",
                Price = 10,
                Description = "測試",
                CreateDateTime = DateTime.Parse("2023-07-27 16:00:00"),
                UpdateDateTime = DateTime.Parse("2023-07-27 16:00:00")
            };

            _mockProductImpl.Setup(x => x.UpdateAsync(It.IsAny<ProductEntity>())).ReturnsAsync(productEntity_Return);

            var productModel_Result = _mockMapper.Object.Map<ProductModel>(productEntity_Return);

            var prodcutService = new ProductService(_mockProductImpl.Object, _mockMapper.Object);

            var result = await prodcutService.UpdateProductAsync(productModel);

            Assert.Equal(productModel_Result, result);
        }

        [Fact]
        public async Task TestGetAllProductAsync()
        {
            var productModel = new ProductModel
            {
                Id = 1,
                ProductName = "測試用",
                Price = 10,
                Description = "測試",
            };

            var productEntity_Return = new List<ProductEntity>
            {
                new ProductEntity
                {
                    Id = 1,
                    ProductName = "測試用",
                    Price = 10,
                    Description = "測試",
                    CreateDateTime = DateTime.Parse("2023-07-27 16:00:00"),
                    UpdateDateTime = DateTime.Parse("2023-07-27 16:00:00")
                },
                new ProductEntity
                {
                    Id = 2,
                    ProductName = "測試用2",
                    Price = 120,
                    Description = "測試2",
                    CreateDateTime = DateTime.Parse("2023-07-27 16:00:00"),
                    UpdateDateTime = DateTime.Parse("2023-07-27 16:00:00")
                },
            };

            _mockProductImpl.Setup(x => x.GetAllAsync()).ReturnsAsync(productEntity_Return);

            var productModel_Result = _mockMapper.Object.Map<List<ProductModel>>(productEntity_Return);

            var prodcutService = new ProductService(_mockProductImpl.Object, _mockMapper.Object);

            var result = await prodcutService.GetAllProductAsync();

            Assert.Equal(productModel_Result, result);
        }

        [Fact]
        public async Task TestGetProductByIdAsync()
        {
            var id = 1;
            var productModel = new ProductModel
            {
                Id = 1,
                ProductName = "測試用",
                Price = 10,
                Description = "測試",
            };

            var productEntity_Return = new ProductEntity
            {
                Id = 1,
                ProductName = "測試用",
                Price = 10,
                Description = "測試",
                CreateDateTime = DateTime.Parse("2023-07-27 16:00:00"),
                UpdateDateTime = DateTime.Parse("2023-07-27 16:00:00")
            };

            _mockProductImpl.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(productEntity_Return);

            var productModel_Result = _mockMapper.Object.Map<ProductModel>(productEntity_Return);

            var prodcutService = new ProductService(_mockProductImpl.Object, _mockMapper.Object);

            var result = await prodcutService.GetProductByIdAsync(id);

            Assert.Equal(productModel_Result, result);
        }
    }
}
