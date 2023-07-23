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

        #region Insert

        public T InsertByEntityId<T>(T _EntityObject)
        {
            return _dapperComponent.InsertByEntityId(_EntityObject);
        }

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
        public T UpdateByEntityId<T>(T _EntityObject)
        {
            return _dapperComponent.UpdateByEntityId<T>(_EntityObject);
        }

        /// <summary>
        /// 依Entity更新資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_EntityObject"></param>
        public async Task<T> UpdateByEntityIdAsync<T>(T _EntityObject)
        {
            return await _dapperComponent.UpdateByEntityIdAsync<T>(_EntityObject);
        }

        #endregion
    }
}
