using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TorrentSite.Areas.ViewModels;
using TorrentSite.Controllers;
using TorrentSite.Data;
using TorrentSite.Models;
using Kendo.Mvc.Extensions;

namespace TorrentSite.Areas.Administration.Controllers
{
    //[Authorize(Roles="Admin")]
    public class TorrentsController : BaseController
    {
        public TorrentsController(IUowData data)
            : base(data)
        {
        }
        public ActionResult Index()
        {
            var torrents = Data.Torrents.All().Select(TorrentViewModel.FromTorrent).ToList();



            return View(torrents);
        }

        public ActionResult CreateTorrent()
        {
            var cataloges = from catalog in Data.Catalogues.All().ToList()
                            select new SelectListItem()
                            {
                                Text = catalog.Name,
                                Value = catalog.Id.ToString()
                            };

            ViewData["catalogs"] = cataloges.ToList();

            return View();
        }


        //TODO:File upload
        public ActionResult CreateNewTorrent(TorrentViewModel torrentModel)
        {
            if (ModelState.IsValid && torrentModel != null)
            {
                Torrent torrentEntity = new Torrent()
                {
                    Title = torrentModel.Title,
                    FileLink = torrentModel.FileLink,
                    CatalogueId = int.Parse(torrentModel.CatalogueName),
                    Size = torrentModel.Size,
                    DateCreated = DateTime.Now,
                    Description = torrentModel.Description

                };

                Data.Torrents.Add(torrentEntity);
                Data.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                var cataloges = from catalog in Data.Catalogues.All().ToList()
                                select new SelectListItem()
                                {
                                    Text = catalog.Name,
                                    Value = catalog.Id.ToString()
                                };

                ViewData["catalogs"] = cataloges.ToList();

                return View("CreateTorrent");
            }

        }

        public ActionResult UploadedFiles(IEnumerable<HttpPostedFileBase> upload)
        {
            if (upload != null)
            {
                foreach (var file in upload)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    file.SaveAs(physicalPath);
                }
            }

            return Content("");
        }

        public ActionResult EditTorrent(int id)
        {
            var torrent = Data.Torrents.All()
                .Select(TorrentViewModel.FromTorrent).FirstOrDefault(t => t.Id == id);

            var cataloges = from catalog in Data.Catalogues.All().ToList()
                            select new SelectListItem()
                            {
                                Text = catalog.Name,
                                Value = catalog.Id.ToString()
                            };

            var categories = (from catalog in Data.Categories.All().ToList()
                            select new SelectListItem()
                            {
                                Text = catalog.Name,
                                Value = catalog.Id.ToString()
                            }).ToList();
            categories.Add(new SelectListItem()
            {
                Text = null,
                Value = null,
                Selected = true
            });

            ViewData["categories"] = categories.ToList();
            ViewData["catalogs"] = cataloges.ToList();
            

            return View(torrent);
        }

        public ActionResult SaveEditedTorrent(TorrentViewModel torrentModel)
        {
            if (ModelState.IsValid && torrentModel != null)
            {
                Torrent torrentEntity = Data.Torrents.All().FirstOrDefault(t => t.Id == torrentModel.Id);
                torrentEntity.Title = torrentModel.Title;
                torrentEntity.FileLink = torrentModel.FileLink;
                torrentEntity.CatalogueId = int.Parse(torrentModel.CatalogueName);
                torrentEntity.Size = torrentModel.Size;
                torrentEntity.DateCreated = DateTime.Now;
                torrentEntity.Description = torrentModel.Description;

                if (torrentModel.CategoryToAdd!=null)
                {
                    int categoryId = int.Parse(torrentModel.CategoryToAdd);
                    var existingCategory = torrentEntity.Categories.FirstOrDefault(c => c.Id == categoryId);
                    if (existingCategory == null)
                    {
                        var newCategory = Data.Categories.All().FirstOrDefault(c => c.Id == categoryId);
                        torrentEntity.Categories.Add(newCategory);
                    }

                }
                
                Data.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                var cataloges = from catalog in Data.Catalogues.All().ToList()
                                select new SelectListItem()
                                {
                                    Text = catalog.Name,
                                    Value = catalog.Id.ToString()
                                };
                var categories = (from catalog in Data.Categories.All().ToList()
                                  select new SelectListItem()
                                  {
                                      Text = catalog.Name,
                                      Value = catalog.Id.ToString()
                                  }).ToList();
                categories.Add(new SelectListItem()
                {
                    Text = null,
                    Value = null,
                    Selected = true
                });

                ViewData["categories"] = categories.ToList();
                ViewData["catalogs"] = cataloges.ToList();

                return View("EditTorrent",torrentModel);
            }

        }

        public ActionResult DeleteTorrent(int id)
        {
            var torrent = Data.Torrents.All().FirstOrDefault(t => t.Id == id);
            Data.Torrents.Delete(torrent);
            Data.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult GetCategories()
        {
            var categories = Data.Categories.All().Select(CategoryViewModel.FromCategory).ToList();


            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchByCategory(string categoryId)
        {
            if (!String.IsNullOrEmpty(categoryId))
            {
                int id = int.Parse(categoryId);
                var torrents = Data.Torrents.All().Where(t => t.Categories.Any(cat => cat.Id == id))
                .Select(TorrentViewModel.FromTorrent).ToList();

                return PartialView("_AllTorrentsList", torrents);
            }
            else
            {
                var torrents = Data.Torrents.All().Select(TorrentViewModel.FromTorrent).ToList();
                return PartialView("_AllTorrentsList", torrents);
            }
           
        }

        //public JsonResult GetAllTorrents([DataSourceRequest] DataSourceRequest request)
        //{
        //    var torrents = Data.Torrents.All().Select(TorrentViewModel.FromTorrent).ToList();

        //    return Json(torrents.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        //}

        
    }
}