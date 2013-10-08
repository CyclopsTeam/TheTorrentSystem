using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TorrentSite.Areas.ViewModels;
using TorrentSite.Data;

namespace TorrentSite.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(int? id)
        {
            var torrents = this.Data.Torrents.All()
                .Where(x => x.Categories.Any(y => y.Id == id))
                .Select(TorrentSite.ViewModels.TorrentViewModel.FromTorrent);

            this.ViewBag.CategoryId = id;

            return View(torrents);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var torrent = this.Data.Torrents.All()
                .Where(x => x.Id == id.Value)
                .Select(TorrentSite.ViewModels.TorrentViewModel.FromTorrent)
                .FirstOrDefault();

            if (torrent == null)
            {
                return HttpNotFound();
            }

            return PartialView("_Details", torrent);
        }
    }
}