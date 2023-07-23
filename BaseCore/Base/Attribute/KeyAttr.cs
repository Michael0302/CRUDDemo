using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Base.Attribute
{
    public class KeyAttr : System.Attribute
    {
        private string _key = string.Empty;
        public KeyAttr(string _Key)
        {
            this._key = _Key;
        }
        public string Key
        {
            get { return _key; }
        }
    }
}
