using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDemo.Entity.Product
{
    public class ProductModel
    {
        [Display(Name = "編號")]
        public int Id { get; set; }

        [Display(Name = "商品名稱")]
        public string ProductName { get; set; }

        [Display(Name = "描述")]
        public string Descirption { get; set; }

        [Display(Name = "價錢")]
        public decimal Price { get; set; }

        [Display(Name = "建立時間")]
        public DateTime CreateDatetime { set; get; }

        [Display(Name = "更新時間")]
        public DateTime UpdateDateTime { set; get; }
    }
}
