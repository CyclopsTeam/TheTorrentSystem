using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using TorrentSite.Data;
using TorrentSite.Models;
using TorrentSite.ViewModels;

namespace TorrentSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
    }
}