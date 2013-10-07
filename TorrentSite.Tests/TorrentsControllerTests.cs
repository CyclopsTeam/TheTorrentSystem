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
    }
}
