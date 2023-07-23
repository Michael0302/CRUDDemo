using BaseUtility.Common.Extension;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUtility.Common.Json
{
    public class ISO8601UtcDateTimeConverter : IsoDateTimeConverter
    {
        public ISO8601UtcDateTimeConverter()
        {
            DateTimeFormat = StringExtensions.ISO8601Format;
        }
    }
}
