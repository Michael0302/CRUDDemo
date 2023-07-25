using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDemo.Entity.Product
{
    public class ProductModel
    {
        /// <summary>
        /// 編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Descirption { get; set; }

        /// <summary>
        /// 價錢
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDatetime { set; get; }

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime UpdateDateTime { set; get; }
    }
}
