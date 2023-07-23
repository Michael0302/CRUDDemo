using BaseCore.Base.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Helper.DB.DBUtilityDef
{
    public class EntityUtility
    {
        private static List<string> GetEntityCommonFieldNames()
        {
            return typeof(BaseEntity).GetProperties().Select(x => x.Name).ToList();
        }

        private static IEnumerable<PropertyInfo> GetPropertyInfos<T>(bool ExceptCommonFileds)
        {
            if (ExceptCommonFileds)
            {
                return typeof(T).GetProperties().Where(x => !GetEntityCommonFieldNames().Contains(x.Name));
            }
            else
            {
                return typeof(T).GetProperties();
            }
        }

        private static string GetDescription(PropertyInfo property)
        {
            DescriptionAttribute desc = property.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault();
            if (desc != null)
            {
                return desc.Description;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetFieldDescription<T>(string fieldName)
        {
            return GetDescription(typeof(T).GetProperty(fieldName));
        }

        public static List<string> GetAllFieldNames<T>(bool ExceptCommonFileds = true)
        {
            return GetPropertyInfos<T>(ExceptCommonFileds).Select(p => p.Name).ToList();
        }

        public static List<string> GetAllFieldDescriptions<T>(bool ExceptCommonFileds = true)
        {
            return GetPropertyInfos<T>(ExceptCommonFileds).Select(p => GetDescription(p)).ToList();
        }

        public static Dictionary<string, string> GetDescptionDictionaryByField<T>(bool ExceptCommonFileds = true)
        {
            return GetPropertyInfos<T>(ExceptCommonFileds).ToDictionary(x => x.Name, x => GetDescription(x));
        }

        public static DataTable ConvertEntityToDataTable<T>(IEnumerable<T> Entitys)
        {
            DataTable dt = new DataTable(typeof(T).Name);

            dt.Columns.AddRange(GetPropertyInfos<T>(false).Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());

            foreach (T entity in Entitys)
            {
                Object[] objs = GetPropertyInfos<T>(false).Select(p => typeof(T).GetProperty(p.Name).GetValue(entity)).ToArray();
                dt.LoadDataRow(objs, false);
            }

            return dt;
        }

        /// <summary>
        /// 取得標有特定屬性內容
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="propertyName"></param>
        /// <param name="attributeType"></param>
        /// <param name="attributePropertyName"></param>
        /// <returns></returns>
        public static object GetAttributeValue(Type objectType, string propertyName, Type attributeType, string attributePropertyName)
        {
            var propertyInfo = objectType.GetProperty(propertyName);
            if (propertyInfo != null)
            {
                if (Attribute.IsDefined(propertyInfo, attributeType))
                {
                    var attributeInstance = Attribute.GetCustomAttribute(propertyInfo, attributeType);
                    if (attributeInstance != null)
                    {
                        foreach (PropertyInfo info in attributeType.GetProperties())
                        {
                            if (info.CanRead &&
                            String.Compare(info.Name, attributePropertyName,
                            StringComparison.InvariantCultureIgnoreCase) == 0)
                            {
                                return info.GetValue(attributeInstance, null);
                            }
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 取得標有特定屬性內容
        /// </summary>
        /// <param name="objectType">物件型別</param>
        /// <param name="attributeType">屬性型別</param>
        /// <param name="attributePropertyName">屬性型別裡的屬性名稱</param>
        /// <returns></returns>
        public static object GetAttributeValue(Type objectType, Type attributeType, string attributePropertyName)
        {
            PropertyInfo[] _PropertiesInfo = objectType.GetProperties();
            foreach (var propertyInfo in _PropertiesInfo)
            {
                if (propertyInfo != null)
                {
                    if (Attribute.IsDefined(propertyInfo, attributeType))
                    {
                        var attributeInstance = Attribute.GetCustomAttribute(propertyInfo, attributeType);
                        if (attributeInstance != null)
                        {
                            foreach (PropertyInfo info in attributeType.GetProperties())
                            {
                                if (info.CanRead &&
                                String.Compare(info.Name, attributePropertyName,
                                StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    return info.GetValue(attributeInstance, null);
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 取得標有特定屬性的欄位名稱
        /// </summary>
        /// <param name="objectType">物件型別</param>
        /// <param name="propertyName">屬性名稱</param>
        /// <param name="attributeType">屬性型別</param>
        /// <param name="attributePropertyName">屬性型別裡的屬性名稱</param>
        /// <param name="ExpectedAttrValue">期望符合的值</param>
        /// <returns></returns>
        public static string GetFieldNameByAttributeValue(Type objectType, string propertyName, Type attributeType, string attributePropertyName, string ExpectedAttrValue)
        {
            var propertyInfo = objectType.GetProperty(propertyName);
            if (propertyInfo != null)
            {
                if (Attribute.IsDefined(propertyInfo, attributeType))
                {
                    var attributeInstance = Attribute.GetCustomAttribute(propertyInfo, attributeType);
                    if (attributeInstance != null)
                    {
                        foreach (PropertyInfo info in attributeType.GetProperties())
                        {
                            if (info.CanRead &&
                            String.Compare(info.Name, attributePropertyName,
                            StringComparison.InvariantCultureIgnoreCase) == 0)
                            {
                                object _objOfResult = info.GetValue(attributeInstance, null);
                                if (_objOfResult != null)
                                {
                                    if (_objOfResult.ToString() == ExpectedAttrValue)
                                    {
                                        return propertyInfo.Name;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 取得標有特定屬性的欄位名稱
        /// </summary>
        /// <param name="objectType">物件型別</param>
        /// <param name="attributeType">屬性型別</param>
        /// <param name="attributePropertyName">屬性型別裡的屬性名稱</param>
        /// <param name="ExpectedAttrValue">期望符合的值</param>
        /// <returns></returns>
        public static string GetFieldNameByAttributeValue(Type objectType, Type attributeType, string attributePropertyName, string ExpectedAttrValue)
        {
            PropertyInfo[] _PropertiesInfo = objectType.GetProperties();
            foreach (var propertyInfo in _PropertiesInfo)
            {
                if (propertyInfo != null)
                {
                    if (Attribute.IsDefined(propertyInfo, attributeType))
                    {
                        var attributeInstance = Attribute.GetCustomAttribute(propertyInfo, attributeType);
                        if (attributeInstance != null)
                        {
                            foreach (PropertyInfo info in attributeType.GetProperties())
                            {
                                if (info.CanRead &&
                                String.Compare(info.Name, attributePropertyName,
                                StringComparison.InvariantCultureIgnoreCase) == 0)
                                {
                                    object _objOfResult = info.GetValue(attributeInstance, null);
                                    if (_objOfResult != null)
                                    {
                                        if (_objOfResult.ToString() == ExpectedAttrValue)
                                        {
                                            return propertyInfo.Name;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
