using AutoMapper;
using CRUDDemo.Business.Product.Interface;
using CRUDDemo.Data.DataAccessObjects.Product.Interfaces;
using CRUDDemo.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDemo.Business.Product.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductImpl _productImpl;
        private readonly IMapper _mapper;

        public ProductService(
            IProductImpl productImpl,
            IMapper mapper)
        {
            _productImpl = productImpl;
            _mapper = mapper;
        }

        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public ProductModel InsertProduct(ProductModel productModel)
        {
            var product = _mapper.Map<ProductEntity>(productModel);

            var result_Entity = _productImpl.Insert(product);

            var result = _mapper.Map<ProductModel>(result_Entity);

            return result;
        }

        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public async Task<ProductModel> InsertProductAsync(ProductModel productModel)
        {
            var product = _mapper.Map<ProductEntity>(productModel);

            var result_Entity = await _productImpl.InsertAsync(product);

            var result = _mapper.Map<ProductModel>(result_Entity);

            return result;
        }

        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public ProductModel UpdateProduct(ProductModel productModel)
        {
            var product = _mapper.Map<ProductEntity>(productModel);

            var result_Entity = _productImpl.Update(product);

            var result = _mapper.Map<ProductModel>(result_Entity);

            return result;
        }

        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public async Task<ProductModel> UpdateProductAsync(ProductModel productModel)
        {
            var product = _mapper.Map<ProductEntity>(productModel);

            var result_Entity = await _productImpl.UpdateAsync(product);

            var result = _mapper.Map<ProductModel>(result_Entity);

            return result;
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            _productImpl.DeleteById(id);
        }

        /// <summary>
        /// 依Id取得單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductModel GetProductById(int id)
        {
            var productEntity = _productImpl.GetById(id);

            var product = _mapper.Map<ProductModel>(productEntity);

            return product;
        }

        /// <summary>
        /// 依Id取得單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            var productEntity = await _productImpl.GetByIdAsync(id);

            var product = _mapper.Map<ProductModel>(productEntity);

            return product;
        }

        /// <summary>
        /// 取得多筆資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetAllProduct()
        {
            var productEntities = _productImpl.GetAll();

            var products = _mapper.Map<List<ProductModel>>(productEntities);

            return products;
        }

        /// <summary>
        /// 取得多筆資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetAllProductAsync()
        {
            var productEntities = _productImpl.GetAllAsync();

            var products = _mapper.Map<List<ProductModel>>(productEntities);

            return products;
        }
    }
}
