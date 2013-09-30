using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TorrentSite.Data;

namespace TorrentSite.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();

        public ActionResult Index()
        {
            var catalogues = this.context.Catalogues
                .Select(c => new TreeViewItemModel { Text = c.Name });

            return View(catalogues);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}