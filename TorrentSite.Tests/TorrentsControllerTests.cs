using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TorrentSite.Models;
using TorrentSite.Data;
using TorrentSite.Controllers;
using System.Web.Mvc;
using TorrentSite.ViewModels;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace TorrentSite.Tests
{
    [TestClass]
    public class TorrentsControllerTests
    {
        [TestMethod]
        public void IndexMethodShouldReturnProperNumberOfTorrents()
        {
            var list = new List<Torrent>();
            list.Add(new Torrent());
            list.Add(new Torrent());

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Torrents.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new TorrentsController(uowDataMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<TorrentViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void IndexMethodShouldReturnProperNumberOfTorrentsWhenModelIsEmpty()
        {
            var list = new List<Torrent>();

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Torrents.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new TorrentsController(uowDataMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<TorrentViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(0, model.Count());
        }

        [TestMethod]
        public void DetailsMethodShouldReturnProperObject()
        {
            int id = 1;

            var list = new List<Torrent>();
            list.Add(new Torrent() { Id = id });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Torrents.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new TorrentsController(uowDataMock.Object);
            var viewResult = controller.Details(id) as ViewResult;
            Assert.IsNotNull(viewResult, "Details action returns null.");
            var model = viewResult.Model as TorrentViewModel;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(id, model.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DetailsMethodShouldThrowIfTorrentIdDoesNotExists()
        {
            int id = 1;

            var list = new List<Torrent>();
            list.Add(new Torrent() { Id = id + 1});

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Torrents.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new TorrentsController(uowDataMock.Object);
            var viewResult = controller.Details(id) as ViewResult;
            Assert.IsNotNull(viewResult, "Details action returns null.");
            var model = viewResult.Model as TorrentViewModel;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(id, model.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DetailsMethodShouldThrowIfTorrentDbIsEmpty()
        {
            int id = 1;

            var list = new List<Torrent>();

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Torrents.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new TorrentsController(uowDataMock.Object);
            var viewResult = controller.Details(id) as ViewResult;
            Assert.IsNotNull(viewResult, "Details action returns null.");
            var model = viewResult.Model as TorrentViewModel;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(id, model.Id);
        }

        [TestMethod]
        public void GetTorrentsMethodShouldReturnProperNumberOfTorrents()
        {
            var list = new List<Torrent>();
            list.Add(new Torrent());
            list.Add(new Torrent());

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Torrents.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new TorrentsController(uowDataMock.Object);
            var viewResult = controller.GetTorrents(new DataSourceRequest()) as JsonResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var data = viewResult.Data as DataSourceResult;
            var model = data.Data as IEnumerable<TorrentViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void GetTorrentsMethodShouldReturnProperNumberOfTorrentsWhenDbIsEmpty()
        {
            var list = new List<Torrent>();

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Torrents.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new TorrentsController(uowDataMock.Object);
            var viewResult = controller.GetTorrents(new DataSourceRequest()) as JsonResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var data = viewResult.Data as DataSourceResult;
            var model = data.Data as IEnumerable<TorrentViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(0, model.Count());
        }
    }
}
