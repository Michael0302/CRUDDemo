using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUtility.Common.WebConfig
{
    public class WebConfigHelper
    {
        /// <summary>
        /// 利用Key去取得WebConfig的AppSettings中的設定值
        /// </summary>
        /// <param name="_KeyName"></param>
        /// <returns></returns>
        public static string GetAppSettingsByKeyName(string _KeyName)
        {
            try
            {
                return ConfigurationManager.AppSettings[_KeyName];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 利用Key去取得WebConfig的ConnectionStrings中的連線字串
        /// </summary>
        /// <param name="_KeyName"></param>
        /// <returns></returns>
        public static string GetConnectionStringsByKeyName(string _KeyName)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[_KeyName].ConnectionString;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
