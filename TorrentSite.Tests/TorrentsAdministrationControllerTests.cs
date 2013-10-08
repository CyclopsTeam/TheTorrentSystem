using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TorrentSite.Models;
using System.Collections.Generic;
using Moq;
using TorrentSite.Data;
using TorrentSite.Controllers;
using System.Web.Mvc;
using TorrentSite.Areas.ViewModels;
using TorrentSite.Areas.Administration.Controllers;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace TorrentSite.Tests
{
    [TestClass]
    public class TorrentsAdministrationControllerTests
    {
        
        [TestMethod]
        public void IndexMethodShouldReturnView()
        {
            var list = new List<Torrent>();
            list.Add(new Torrent() { Id = 1, Title = "test", FileLink = "Test Link" });
            list.Add(new Torrent() { Id = 2, Title = "test2", FileLink = "Test Link2" });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Torrents.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new TorrentsAdministrationController(uowDataMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
        }

        [TestMethod]
        public void IndexMethodShouldReturnCOrrectNumberOfTorrents()
        {
            var list = new List<Torrent>();
            list.Add(new Torrent() { Id = 1, Title = "test", FileLink = "Test Link" });
            list.Add(new Torrent() { Id = 2, Title = "test2", FileLink = "Test Link2" });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Torrents.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new TorrentsAdministrationController(uowDataMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var torrentList = viewResult.Model as IEnumerable<TorrentViewModel>;
            Assert.IsNotNull(torrentList, "The torrent list is null.");
            Assert.AreEqual(torrentList.Count(), 2);
        }

        [TestMethod]
        public void CreateTorrentsShouldLoadCataloguesListInViewData()
        {
            int id = 1;

            var list = new List<Catalogue>();
            list.Add(new Catalogue() { Id = id });
            list.Add(new Catalogue() { Id = id + 1 });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Catalogues.All()).Returns(list.AsQueryable());
            var controller = new TorrentsAdministrationController(uowDataMock.Object);
            var viewResult = controller.CreateTorrent() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var catList = viewResult.ViewData["catalogs"] as IEnumerable<SelectListItem>;
            Assert.IsNotNull(catList, "The catalogues list is null.");
            Assert.AreEqual(catList.Count(), 2);
        }

        [TestMethod]
        public void GetCategoriesShouldReturnProperNumberOfCategories()
        {

            var list = new List<Category>();
            list.Add(new Category() { Id = 1, Name = "test", Catalogue = new Catalogue() { Name = "Test Catalogue" } });
            list.Add(new Category() { Id = 2, Name = "test2", Catalogue = new Catalogue() { Name = "Test Catalogue2" } });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Categories.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new TorrentsAdministrationController(uowDataMock.Object);
            var viewResult = controller.GetCategories() as JsonResult;
            Assert.IsNotNull(viewResult, "ReadCategories action returns null.");
            var model = viewResult.Data as IEnumerable<CategoryViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());
        }

    }
}
