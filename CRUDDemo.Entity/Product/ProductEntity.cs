using BaseCore.Base.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDemo.Entity.Product
{
    public class ProductEntity: BaseEntity
    {
        [Description("商品名稱")]
        public string ProductName { get; set; }

        [Description("描述")]
        public string Description { get; set; }

        [Description("價錢")]
        public decimal Price { get; set; }
    }
}
