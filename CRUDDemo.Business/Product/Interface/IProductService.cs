using CRUDDemo.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDemo.Business.Product.Interface
{
    public interface IProductService
    {
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id"></param>
        void DeleteProduct(int id);

        /// <summary>
        /// 取得多筆資料
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductModel> GetAllProduct();

        /// <summary>
        /// 取得多筆資料
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductModel> GetAllProductAsync();

        /// <summary>
        /// 依Id取得單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductModel GetProductById(int id);

        /// <summary>
        /// 依Id取得單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductModel> GetProductByIdAsync(int id);

        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        ProductModel InsertProduct(ProductModel productModel);

        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        Task<ProductModel> InsertProductAsync(ProductModel productModel);

        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        ProductModel UpdateProduct(ProductModel productModel);

        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        Task<ProductModel> UpdateProductAsync(ProductModel productModel);
    }
}
