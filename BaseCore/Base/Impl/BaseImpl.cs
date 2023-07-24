using BaseCore.Base.Entity;
using BaseCore.Helper;
using BaseUtility.Common.WebConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Base.Impl
{
    public class BaseImpl<T> : IBaseImpl<T> where T : BaseEntity
    {
        private DBHelper _dbHelper = null;

        //取得DBHelper物件
        protected DBHelper dbHelper
        {
            get
            {
                if (this._dbHelper == null)
                {
                    ConnectionString = WebConfigHelper.GetConnectionStringsByKeyName("ConnectionString");
                }
                return this._dbHelper;
            }
        }

        /// <summary>
        /// 利用連線字串建立
        /// </summary>
        public string ConnectionString
        {
            set
            {
                _dbHelper = new DBHelper(value);
            }
        }

        #region Insert

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public T Insert(T entity)
        {
            return dbHelper.InsertByEntityId<T>(entity);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public async Task<T> InsertAsync(T entity)
        {
            return await dbHelper.InsertByEntityIdAsync<T>(entity);
        }

        #endregion

        #region Update

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Update(T entity)
        {
            return dbHelper.UpdateByEntity<T>(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> UpdateAsync(T entity)
        {
            return await dbHelper.UpdateByEntityAsync<T>(entity);
        }

        #endregion

        #region Delete

        /// <summary>
        /// 依Id刪除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            var sqlScript = string.Format(@"delete {0} where Id = @Id", typeof(T).Name);
            var parms = new Dictionary<string, object>();
            parms.Add("Id", id);

            dbHelper.Execute(sqlScript, parms);
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="entity"></param>
        public int Delete(T entity)
        {
            return dbHelper.DeleteByEntity<T>(entity);
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(T entity)
        {
            return await dbHelper.DeleteByEntityAsync<T>(entity);
        }

        #endregion

        #region Get

        /// <summary>
        /// 依Id取得Entity
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            var sqlScript = string.Format(@"select * from {0} where Id = @id", typeof(T).Name);
            var parms = new Dictionary<string, object>();
            parms.Add("Id", id);

            return dbHelper.GetEntityBySQLScript<T>(sqlScript, parms);
        }

        /// <summary>
        /// 依Id取得Entity
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(int id)
        {
            var sqlScript = string.Format(@"select * from {0} where Id = @id", typeof(T).Name);
            var parms = new Dictionary<string, object>();
            parms.Add("Id", id);

            return await dbHelper.GetEntityBySQLScriptAsync<T>(sqlScript, parms);
        }

        #endregion

        #region GetAll

        /// <summary>
        /// 取得全部
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            var sqlScript = string.Format(@"select * from {0}", typeof(T).Name);
            return dbHelper.GetEntitiesBySQLScript<T>(sqlScript);
        }

        /// <summary>
        /// 取得全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var sqlScript = string.Format(@"select * from {0}", typeof(T).Name);
            return await dbHelper.GetEntitiesBySQLScriptAsync<T>(sqlScript);
        }

        #endregion
    }
}
