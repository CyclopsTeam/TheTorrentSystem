using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TorrentSite.Controllers;
using System.Web.Mvc;
using System.Collections;
using TorrentSite.Models;
using System.Collections.Generic;
using TorrentSite.Data;
using TorrentSite.ViewModels;

namespace TorrentSite.Tests
{
    [TestClass]
    public class CatalogueControllerTests
    {
        [TestMethod]
        //public void IndexMethodShouldReturnProperNumberOfCatalogue()
        //{
        //    var list = new List<Catalogue>();
        //    list.Add(new Catalogue());
        //    list.Add(new Catalogue());

        //    var uowDataMock = new Mock<IUowData>();
        //    uowDataMock.Setup(x => x.Catalogues.All()).Returns(list.AsQueryable());
        //    var catalogueRepoMock = uowDataMock.Object.Catalogues;

        //    var controller = new CataloguesController(uowDataMock.Object);
        //    var viewResult = controller.Index() as ViewResult;
        //    Assert.IsNotNull(viewResult, "Index action returns null.");
        //    var model = viewResult.Model as IEnumerable<CatalogueViewModel>;
        //    Assert.IsNotNull(model, "The model is null.");
        //    Assert.AreEqual(2, model.Count());
        //}
    }
}
