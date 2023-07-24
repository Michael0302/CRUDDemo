using BaseCore.Helper.DB.Dapper;
using BaseCore.Helper.DB.DBUtilityDef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Helper
{
    public class DBHelper
    {
        private IDapperComponent _dapperComponent = null;

        public DBHelper(string connectionString)
        {
            this._dapperComponent = new DapperComponent(connectionString);
        }

        /// <summary>
        /// 執行語法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public int Execute(string sql, object paras = null, int? commandTimeout = default(int?))
        {
            return _dapperComponent.Execute(sql, paras, commandTimeout);
        }

        /// <summary>
        /// 執行語法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, object paras = null, int? commandTimeout = default(int?))
        {
            return await _dapperComponent.ExecuteAsync(sql, paras, commandTimeout);
        }        

        #region Insert

        /// <summary>
        /// 依Entity新增資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_EntityObject"></param>
        /// <returns></returns>
        public T InsertByEntityId<T>(T _EntityObject)
        {
            return _dapperComponent.InsertByEntityId(_EntityObject);
        }

        /// <summary>
        /// 依Entity新增資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_EntityObject"></param>
        /// <returns></returns>
        public async Task<T> InsertByEntityIdAsync<T>(T _EntityObject)
        {
            return await _dapperComponent.InsertByEntityIdAsync(_EntityObject);
        }

        #endregion

        #region Update

        /// <summary>
        /// 依Entity更新資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_EntityObject"></param>
        public T UpdateByEntity<T>(T _EntityObject)
        {
            return _dapperComponent.UpdateByEntityId<T>(_EntityObject);
        }

        /// <summary>
        /// 依Entity更新資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_EntityObject"></param>
        public async Task<T> UpdateByEntityAsync<T>(T _EntityObject)
        {
            return await _dapperComponent.UpdateByEntityIdAsync<T>(_EntityObject);
        }

        #endregion

        #region Delete

        /// <summary>
        /// 依Entity刪除資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_EntityObject"></param>
        public int DeleteByEntity<T>(T _EntityObject)
        {
            return _dapperComponent.DeleteByEntity(_EntityObject);
        }

        /// <summary>
        /// 依Entity刪除資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_EntityObject"></param>
        public async Task<int> DeleteByEntityAsync<T>(T _EntityObject)
        {
            return await _dapperComponent.DeleteByEntityAsync(_EntityObject);
        }

        #endregion

        #region Get

        /// <summary>
        /// 取得單筆Entity資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlScript"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public T GetEntityBySQLScript<T>(string sqlScript, Dictionary<string, object> paras = null)
        {
            return _dapperComponent.GetEntityBySQLScript<T>(sqlScript, paras);
        }

        /// <summary>
        /// 取得單筆Entity資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlScript"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public async Task<T> GetEntityBySQLScriptAsync<T>(string sqlScript, Dictionary<string, object> paras = null)
        {
            return await _dapperComponent.GetEntityBySQLScriptAsync<T>(sqlScript, paras);
        }

        #endregion

        #region GetAll

        /// <summary>
        /// 取得多筆Entity資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlScript"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public IEnumerable<T> GetEntitiesBySQLScript<T>(string sqlScript, Dictionary<string, object> paras = null)
        {
            return _dapperComponent.GetEntitiesBySQLScript<T>(sqlScript, paras);
        }

        /// <summary>
        /// 取得多筆Entity資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlScript"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetEntitiesBySQLScriptAsync<T>(string sqlScript, Dictionary<string, object> paras = null)
        {
            return await _dapperComponent.GetEntitiesBySQLScriptAsync<T>(sqlScript, paras);
        }

        #endregion
    }
}
