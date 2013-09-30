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
        public CataloguesController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View(GetCatalogues());
        }

        private IEnumerable<CatalogueViewModel> GetCatalogues()
        {
            var catalogues = this.Data.Catalogues.All()
                .Select(CatalogueViewModel.FromCatalogue).ToList();

            return catalogues;
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