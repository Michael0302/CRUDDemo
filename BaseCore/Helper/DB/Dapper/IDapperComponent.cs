using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Helper.DB.Dapper
{
    public interface IDapperComponent
    {
        void DeleteByEntity<T>(T entity);
        void DeleteByEntityAsync<T>(T entity);
        int Execute(string sql, object paras = null, int? commandTimeout = null);
        Task<int> ExecuteAsync(string sql, object paras = null, int? commandTimeout = null);
        IEnumerable<T> GetEntitiesBySQLScript<T>(string sqlScript, Dictionary<string, object> paras = null);
        Task<IEnumerable<T>> GetEntitiesBySQLScriptAsync<T>(string sqlScript, Dictionary<string, object> paras = null);
        T GetEntityBySQLScript<T>(string sqlScript, Dictionary<string, object> paras = null);
        Task<T> GetEntityBySQLScriptAsync<T>(string sqlScript, Dictionary<string, object> paras = null);
        T InsertByEntityId<T>(T entity);
        Task<T> InsertByEntityIdAsync<T>(T entity);
        T UpdateByEntityId<T>(T entity);
        Task<T> UpdateByEntityIdAsync<T>(T entity);
    }
}
