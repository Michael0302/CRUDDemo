using CRUDDemo.Business.Product.Interface;
using CRUDDemo.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRUDDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(
            IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductModel productModel)
        {
            var result = await _productService.InsertProductAsync(productModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductModel productModel)
        {
            var result = await _productService.UpdateProductAsync(productModel);

            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _productService.GetAllProductAsync();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetById()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return Json(result);
        }
    }
}