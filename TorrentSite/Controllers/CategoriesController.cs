using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TorrentSite.Areas.ViewModels;
using TorrentSite.Data;

namespace TorrentSite.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories(int? id)
        {
            var categories = this.Data.Categories.All()
                .Where(x => x.Id == id)
                .Select(CategoryViewModel.FromCategory);

            return View(categories);
        }

	}
}