using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TorrentSite.Data;
using TorrentSite.ViewModels;

namespace TorrentSite.Controllers
{
    public class CataloguesController : BaseController
    {
        //private string nameOfTheSearch = "";
        public CataloguesController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View(GetCatalogues());
        }

        private CataloguesCategoriesViewModel GetCatalogues()
        {
            var catalogues = this.Data.Catalogues.All().ToList()
              .Select(x => new TreeViewItemModel
              {
                  Text = x.Name,
                  Items = this.Data.Categories.All().Where(cat => cat.CatalogueId == x.Id).ToList()
                  .Select(tr => new TreeViewItemModel
                  {
                      Text = tr.Name
                  })
                  .ToList()
              });

            var categories = this.Data.Categories.All()
                .Select(CategoryViewModel.FromCategory);

            CataloguesCategoriesViewModel model = new CataloguesCategoriesViewModel();
            model.TreeView = catalogues;
            model.Categories = categories;
            return model;
        }

        public ActionResult Editing_Read([DataSourceRequest] DataSourceRequest request)
        {
            throw new ArgumentException();
        }

        public ActionResult FilterByCategory()
        {


            return View();
        }

        public ActionResult ChoosenCatalogue(string name)
        {
            ViewBag.CatName = name;
            var catalogue = this.Data.Catalogues.All().FirstOrDefault(cat => cat.Name == name);
            if (catalogue == null)
            {
                return RedirectToRoute(new { controller = "Catalogues", action = "ChoosenCategory", name = name });
            }

            var singleCat = new SingleCatalogueViewModel
            {
                Id = catalogue.Id,
                Name = catalogue.Name,
                Image = catalogue.Image,
                Categories = catalogue.Categories.AsQueryable().Select(CategoryViewModel.FromCategory).ToList()
            };
            singleCat.Torrents = this.Data.Torrents.All().Where(t => t.CatalogueId == singleCat.Id).Select(TorrentViewModel.FromTorrent).ToList();
            return View(singleCat);
        }

        public ActionResult ChoosenCategory(string name)
        {

            return View();
        }

        public ActionResult Search(string query, string hiddenName)
        {
            var catalogue = this.Data.Catalogues.All().FirstOrDefault(cat => cat.Name == hiddenName);
            var result = this.Data.Torrents.All().Where(t => (t.Title.Contains(query) && t.CatalogueId == catalogue.Id )).Select(TorrentViewModel.FromTorrent);

            return PartialView("_TorrentsSearch", result);
        }

        public ActionResult Movies()
        {
            ViewBag.Message = "All Torrents.";
            var movieCategories = this.Data.Categories.All()
                .Where(c => c.Catalogue.Name == "Movies")
                .Select(c => new TreeViewItemModel
                {
                    Text = c.Name
                });

            return View();
        }
    }
}