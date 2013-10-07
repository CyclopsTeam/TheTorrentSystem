using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TorrentSite.Data;
using TorrentSite.ViewModels;
using Microsoft.AspNet.Identity;
using TorrentSite.Models;

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

        public ActionResult Details(int id)
        {
            var result = this.Data.Torrents.All().Where(t => t.Id == id).Select(TorrentViewModel.FromTorrent).Single();
            return View(result);
        }

        public JsonResult GetTorrents([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Torrents.All().Select(TorrentViewModel.FromTorrent);
            DataSourceResult requestResult = result.ToDataSourceResult(request);
            return Json(requestResult, JsonRequestBehavior.AllowGet);

        }

        //public JsonResult GetTorrents([DataSourceRequest]DataSourceRequest request)
        //{
        //    var result = this.Data.Torrents.All().Select(TorrentViewModel.FromTorrent);
        //    var torrents = result.ToDataSourceResult(request);
        //    return Json(torrents, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult Download(string fileLink)
        {
            string folder = Server.MapPath("~/App_Data/TorrentFiles");

            return File(new FileStream(folder + "/" + fileLink, FileMode.Open), "content-dispostion", fileLink);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                ApplicationUser user = this.Data.Users.All().Where(u => u.Id == userId).Single();

                if (user == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "User does not exists!");
                }

                Torrent torrent = this.Data.Torrents.GetById(commentModel.TorrentId);

                if (torrent == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Torrent does not exists!");
                }

                var currentDateTime = DateTime.Now;

                Comment comment = new Comment()
                {
                    Creator = user,
                    Content = commentModel.Comment,
                    Torrent = torrent,
                    DateCreated = currentDateTime
                };

                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                CommentViewModel viewModel = this.Data.Comments.All().Where(c => c.Id == comment.Id).Select(CommentViewModel.FromComment).Single();
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }
    }
}