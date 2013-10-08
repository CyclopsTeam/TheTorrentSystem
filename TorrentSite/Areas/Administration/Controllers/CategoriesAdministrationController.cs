using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TorrentSite.Areas.ViewModels;
using TorrentSite.Controllers;
using TorrentSite.Data;
using Kendo.Mvc.Extensions;
using TorrentSite.Models;

namespace TorrentSite.Areas.Administration.Controllers
{
    public class CategoriesAdministrationController : BaseController
    {

        public CategoriesAdministrationController(IUowData data)
            : base(data)
        {
        }
        public ActionResult Index()
        {

            IEnumerable<SelectListItem> listsCatalogs = from catalog in Data.Catalogues.All().ToList()
                                                        select new SelectListItem()
                                                        {
                                                            Text = catalog.Name,
                                                            Value = catalog.Name
                                                        };

            ViewData["catalogs"] = listsCatalogs;

            return View();
        }

        public JsonResult ReadCategories([DataSourceRequest]DataSourceRequest request)
        {

            var categories = Data.Categories.All().Select( CategoryViewModel.FromCategory).ToList();

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
         }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = Data.Categories.All().FirstOrDefault(c => c.Id == category.Id);

            if (category != null && ModelState.IsValid)
            {

                existingCategory.Name = category.Name;
                var catalog = Data.Catalogues.All().FirstOrDefault(c => c.Name == category.Catalog);
                if (catalog!=null)
                {
                    existingCategory.Catalogue = catalog;
                }

                Data.SaveChanges();
            }

            return Json((new[] { category }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = Data.Categories.All().FirstOrDefault(c => c.Id == category.Id);

            Data.Categories.Delete(existingCategory);
            Data.SaveChanges();

            return Json(new[] { category }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var catalog = Data.Catalogues.All().FirstOrDefault(c => c.Name == category.Catalog);
                var newCategory = new Category
                {
                    Name=category.Name,
                    Catalogue=catalog

                };

                Data.Categories.Add(newCategory);
                Data.SaveChanges();

                category.Id=newCategory.Id;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
	}
}