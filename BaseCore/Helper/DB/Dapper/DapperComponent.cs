using BaseCore.Base.Attribute;
using BaseCore.Helper.DB.DBUtilityDef;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Helper.DB.Dapper
{
    public class DapperComponent : IDapperComponent
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private readonly string _connectionString = null;

        public DapperComponent(string connectionString)
        {
            _connectionString = connectionString;
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
            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                return await sqlConnection.QueryFirstOrDefaultAsync<T>(sqlScript, paras);
            }
        }

        #region Insert

        /// <summary>
        /// 依Entity寫入資料
        /// </summary>
        /// <typeparam name="T">通用類別</typeparam>
        /// <param name="entity">物件</param>
        public T InsertByEntityId<T>(T entity)
        {
            string sqlScript = ToInsertScriptWithReturn(entity);
            Dictionary<string, object> paras = ToSqlParameterForInsert(entity);
            return GetEntityBySQLScript<T>(sqlScript, paras);
        }

        /// <summary>
        /// 依Entity寫入資料
        /// </summary>
        /// <typeparam name="T">通用類別</typeparam>
        /// <param name="entity">物件</param>
        public async Task<T> InsertByEntityIdAsync<T>(T entity)
        {
            string sqlScript = ToInsertScriptWithReturn(entity);
            Dictionary<string, object> paras = ToSqlParameterForInsert(entity);
            return await GetEntityBySQLScriptAsync<T>(sqlScript, paras);
        }

        /// <summary>
        /// 取得單筆Entity資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlScript"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public T GetEntityBySQLScript<T>(string sqlScript, Dictionary<string, object> paras = null)
        {
            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                return sqlConnection.QueryFirstOrDefault<T>(sqlScript, paras);
            }
        }        

        /// <summary>
        /// 組SQL insert script
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private string ToInsertScriptWithReturn<T>(T entity)
        {
            var computedColumns = GetDatabaseGeneratedOptioNonColumns(typeof(T));

            List<string> fieldNames = EntityUtility.GetAllFieldNames<T>(false).Where(x => !computedColumns.Contains(x.ToLower())).ToList();

            string columnNameList = string.Join(",", fieldNames.Select(x => "[" + x + "]").ToArray());

            string valueList = string.Join(",", fieldNames.Select(x => "@" + x).ToArray());

            return string.Format("Insert Into [{0}] ({1}) OUTPUT INSERTED.* VALUES ({2}) ", typeof(T).Name, columnNameList, valueList);
        }
        /// <summary>
        /// 取得Entity所有屬性名稱
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        private List<string> GetDatabaseGeneratedOptioNonColumns(Type entityType)
        {
            var computedColumns = new List<string>();

            PropertyInfo[] props = entityType.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    if (attr is DatabaseGeneratedAttribute databaseGeneratedAttribute)
                    {
                        if (databaseGeneratedAttribute.DatabaseGeneratedOption == DatabaseGeneratedOption.Computed
                            || databaseGeneratedAttribute.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity)
                        {
                            string propName = prop.Name;
                            computedColumns.Add(propName.ToLower());
                        }
                    }
                }
            }

            return computedColumns;
        }

        private Dictionary<string, object> ToSqlParameterForInsert<T>(T entity)
        {
            return typeof(T).GetProperties()
                .ToDictionary(

                p => p.Name,
                p =>
                {
                    object value = p.GetValue(entity);

                    //建立時間
                    if (p.Name.ToUpper().Equals(EntityUtility.GetFieldNameByAttributeValue(typeof(T), typeof(KeyAttr), DBdef.KEYATTR, DBdef.CREATE_DATE_TIME).ToUpper()) && ((DateTime)value).Year == 1)
                    {
                        p.SetValue(entity, DateTime.UtcNow);
                    }

                    //最後更新時間
                    if (p.Name.ToUpper().Equals(EntityUtility.GetFieldNameByAttributeValue(typeof(T), typeof(KeyAttr), DBdef.KEYATTR, DBdef.UPDATE_DATE_TIME).ToUpper()) && ((DateTime)value).Year == 1)
                    {
                        p.SetValue(entity, DateTime.UtcNow);
                    }

                    return p.GetValue(entity);
                }
            );
        }

        #endregion

        #region Update

        /// <summary>
        /// 依Entity更新資料
        /// </summary>
        /// <typeparam name="T">通用類別</typeparam>
        /// <param name="entity">物件</param>
        public T UpdateByEntityId<T>(T entity)
        {
            string sqlScript = ToUpdateScriptWithReturn(entity, DBdef.Id);
            Dictionary<string, object> paras = ToSqlParameterForUpdate(entity);
            return GetEntityBySQLScript<T>(sqlScript, paras);
        }

        /// <summary>
        /// 依Entity更新資料
        /// </summary>
        /// <typeparam name="T">通用類別</typeparam>
        /// <param name="entity">物件</param>
        public async Task<T> UpdateByEntityIdAsync<T>(T entity)
        {
            string sqlScript = ToUpdateScriptWithReturn(entity, DBdef.Id);
            Dictionary<string, object> paras = ToSqlParameterForUpdate(entity);
            return await GetEntityBySQLScriptAsync<T>(sqlScript, paras);
        }

        /// <summary>        
        /// 組SQL update script
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        private string ToUpdateScriptWithReturn<T>(T entity, string keyName)
        {
            var computedColumns = GetDatabaseGeneratedOptioNonColumns(typeof(T));
            string valueList = string.Join(",", EntityUtility.GetAllFieldNames<T>(false).Where(x => !computedColumns.Contains(x.ToLower())).Select(x => "[" + x + "] = " + "@" + x).ToArray());

            return string.Format("Update [{0}] set {1} where [{2}] = @{2} select * from [{0}] where [{2}] = @{2}", typeof(T).Name, valueList, EntityUtility.GetFieldNameByAttributeValue(typeof(T), typeof(KeyAttr), DBdef.KEYATTR, DBdef.Id));
        }


        private Dictionary<string, object> ToSqlParameterForUpdate<T>(T entity)
        {
            return typeof(T).GetProperties()
                .ToDictionary(

                p => p.Name,
                p =>
                {
                    object value = p.GetValue(entity);

                    //更新時間
                    if (p.Name.ToUpper().Equals(EntityUtility.GetFieldNameByAttributeValue(typeof(T), typeof(KeyAttr), DBdef.KEYATTR, DBdef.UPDATE_DATE_TIME).ToUpper()) && ((DateTime)value).Year == 1)
                    {
                        p.SetValue(entity, DateTime.UtcNow);
                    }

                    if (value != null && p.PropertyType.IsEnum)
                    {
                        return (int)value;
                    }

                    return p.GetValue(entity);
                }
            );
        }

        #endregion

        #region Delete

        #endregion

        #region GetById

        #endregion

        #region GetAll

        #endregion
    }
}
