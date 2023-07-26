using BaseCore.Base.Attribute;
using BaseUtility.Common.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Base.Entity
{
    public class BaseEntity
    {
        [DisplayName("編號")]
        [Description("編號")]
        [KeyAttr("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("建立日期")]
        [Description("建立日期")]
        [KeyAttr("CreateDateTime")]
        [JsonConverter(typeof(ISO8601UtcDateTimeConverter))]
        public DateTime CreateDateTime { set; get; }

        [DisplayName("更新日期")]
        [Description("更新日期")]
        [KeyAttr("UpdateDateTime")]
        [JsonConverter(typeof(ISO8601UtcDateTimeConverter))]
        public DateTime UpdateDateTime { set; get; }
    }
}
