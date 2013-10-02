﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TorrentSite.Data;
using TorrentSite.ViewModels;

namespace TorrentSite.Controllers
{
    public class TorrentsController : BaseController
    {
        public TorrentsController(IUowData data)
            : base(data)
        {
        }

        //
        // GET: /Torrents/
        [HttpGet]
        public ActionResult Index()
        {
            var result = this.Data.Torrents.All().Select(TorrentViewModel.FromTorrent).ToList();
            return View(result);
        }

        public JsonResult GetTorrents()
        {
            var result = this.Data.Torrents.All().Select(TorrentViewModel.FromTorrent).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        
        [HttpGet]
        public ActionResult Download(string fileLink)
        {
            string folder = Server.MapPath("~/App_Data/TorrentFiles");

            return File(new FileStream(folder + "/" + fileLink, FileMode.Open), "content-dispostion", fileLink);
        }
    }
}