using AutoMapper;
using Sample.Model;
using Sample.Service;
using Sample.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sample.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly IUnitService unitService;
        public HomeController(IProductService productService, IUnitService unitService)
        {
            this.productService = productService;
            this.unitService = unitService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Produsts()
        {
            var units = unitService.GetUnits();
            var result = Mapper.Map<IEnumerable<Unit>, IEnumerable<UnitViewModel>>(units);
            return View(result);
        }

        [HttpPost]
        [ActionName("get-products")]
        public JsonResult GetProducts()
        {
            try
            {
                var products = productService.GetProducts();
                var result = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductsDataTableViewModel>>(products);
               
                return Json(new { isValid = true, data = result ,JsonRequestBehavior.AllowGet});
            }
            catch (Exception) { return Json(new { isValid = false, message = "خطایی رخ داده است" }); }

        }


        [HttpPost]
        [ActionName("Modify-product")]
        public JsonResult ModifyProduct(long productId, string productName,long unitId,decimal count)
        {
            try
            {
                
                var isValid= CheckProductData(productName, unitId, count, out string errMsg);
                if (!isValid)
                {
                    return Json(new { isValid = false, message = errMsg });
                }
                if (productService.IsRepitiveProduct(productId, productName))
                {
                    return Json(new { isValid = false, message = "این محصول قبلا ثبت شده است" });
                }
                SaveProduct(productId, productName, unitId, count);
                return Json(new { isValid = true, message = "عملیات موفق" });
            }
            catch (Exception)
            {
                return Json(new { isValid = false, message = "خطایی رخ داده است" });
            }
        }


        [HttpDelete]
        [ActionName("delete-product")]
        public JsonResult DeleteProduct(long id)
        {
            try
            {
                if (id == default)
                {
                    return Json(new { isValid = false, message = "اطلاعات این رکورد یافت نشد" });
                }
                var product = productService.GetProduct(id);
                if(product is null)
                {
                    return Json(new { isValid = false, message = "اطلاعات این رکورد یافت نشد" });
                }
                productService.DeleteProduct(product);
                productService.SaveProduct();
                return Json(new { isValid = true, message = "عملیات موفق" });
            }
            catch (Exception)
            {
                return Json(new { isValid = false, message = "خطایی رخ داده است" });
            }
        }


        private void SaveProduct(long productId, string productName, long unitId, decimal count)
        {
            if (productId == 0)
            {
                var newProduct = new Product()
                {
                    ProductName = productName,
                    UnitId = unitId,
                    Count = count,
                };
                productService.CreateProduct(newProduct);
            }
            else
            {
                var product = productService.GetProduct(productId);
                product.ProductName = productName;
                product.UnitId = unitId;
                product.Count = count;
                productService.UpdateProduct(product);
            }
            productService.SaveProduct();
        }
        private bool CheckProductData(string productName, long unitId, decimal count,out string msg)
        {
            bool isValid = true;
            msg = "";
            if (string.IsNullOrEmpty(productName))
            {
                isValid = false;
                msg = "عنوان محصول نمی تواند خالی باشد";
            }else if (unitId == default)
            {
                isValid = false;
                msg = "واحد شمارش نمی تواند خالی باشد";
            }
            else if (count == default)
            {
                isValid = false;
                msg = "مقدار نمی تواتد خالی باشد";
            }
            return isValid;
        }
    }
}