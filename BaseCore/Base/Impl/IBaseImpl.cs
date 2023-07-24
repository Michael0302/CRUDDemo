using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Base.Impl
{
    public interface IBaseImpl<T>
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        T Insert(T entity);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        Task<T> InsertAsync(T entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        T Update(T entity);

        /// <summary>
        /// 修改
        /// </summary>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// 依Id刪除
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(int id);

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id">Entity Id</param>
        int Delete(T entity);

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(T entity);

        /// <summary>
        /// 依Id查詢單筆
        /// </summary> 
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// 依Id查詢單筆
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// 查詢全部
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// 查詢全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();
    }
}
