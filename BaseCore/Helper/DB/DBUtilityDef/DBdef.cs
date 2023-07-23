using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Helper.DB.DBUtilityDef
{
    public class DBdef
    {
        public readonly static string KEYATTR = "Key";
        public readonly static string Id = "Id";
        public readonly static string CREATE_DATE_TIME = "CreateDateTime";
        public readonly static string UPDATE_DATE_TIME = "UpdateDateTime";
        public readonly static DateTime MSSQLMaxDateTime = Convert.ToDateTime("9999/12/31");
        public readonly static DateTime MSSQLMinDateTime = Convert.ToDateTime("1900/01/01");
    }
}
