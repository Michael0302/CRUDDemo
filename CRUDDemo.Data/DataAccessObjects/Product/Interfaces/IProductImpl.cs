using BaseCore.Base.Impl;
using CRUDDemo.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDemo.Data.DataAccessObjects.Product.Interfaces
{
    public interface IProductImpl
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        ProductEntity Insert(ProductEntity entity);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        Task<ProductEntity> InsertAsync(ProductEntity entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        ProductEntity Update(ProductEntity entity);

        /// <summary>
        /// 修改
        /// </summary>
        Task<ProductEntity> UpdateAsync(ProductEntity entity);

        /// <summary>
        /// 依Id刪除
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(int id);

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id">Entity Id</param>
        int Delete(ProductEntity entity);

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(ProductEntity entity);

        /// <summary>
        /// 依Id查詢單筆
        /// </summary> 
        /// <param name="id"></param>
        /// <returns></returns>
        ProductEntity GetById(int id);

        /// <summary>
        /// 依Id查詢單筆
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductEntity> GetByIdAsync(int id);

        /// <summary>
        /// 查詢全部
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductEntity> GetAll();

        /// <summary>
        /// 查詢全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IEnumerable<ProductEntity>> GetAllAsync();
    }
}
