using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xinerji.Dc.Internet.Model;
using Xinerji.Dc.Internet.Services;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Dc.Web.Filters;

namespace Xinerji.Dc.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService;

        public ProductController()
        {
            productService = new ProductService();
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetProductList(GetProductListRequest request)
        {
            return Json(this.productService.GetProductList(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertProduct(InsertProductRequest request)
        {
            return Json(this.productService.InsertProduct(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteProduct(DeleteProductRequest request)
        {
            return Json(this.productService.DeleteProduct(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditProduct(EditProductRequest request)
        {
            return Json(this.productService.EditProduct(request));
        }

        
    }
}