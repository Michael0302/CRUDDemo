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
    public class BaseImpl<T> where T : BaseEntity
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


    }
}
