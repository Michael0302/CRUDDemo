using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Base.Dao
{
    public interface IBaseDAO<T>
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        T Insert(T entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id">Entity Id</param>
        void Delete(int id);

        /// <summary>
        /// 依Id查詢單筆
        /// </summary> 
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// 查詢全部
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
    }
}
