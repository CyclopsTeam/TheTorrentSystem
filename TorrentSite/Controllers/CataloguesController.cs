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
    public class CataloguesController : Controller
    {
        DataContext context = new DataContext();

        public ActionResult Index()
        {
            return View(GetCatalogues());
        }

        private IEnumerable<CatalogueViewModel> GetCatalogues()
        {
            var catalogues = this.context.Catalogues
                .Select(CatalogueViewModel.FromCatalogue).ToList();

            return catalogues;
        }

        public ActionResult Movies()
        {
            ViewBag.Message = "All Torrents.";
            var movieCategories = context.Categories
                .Where(c => c.Catalogue.Name == "Movies")
                .Select(c => new TreeViewItemModel
                {
                    Text = c.Name
                });

            return View();
        }
	}
}