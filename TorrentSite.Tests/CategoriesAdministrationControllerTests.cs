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
    public class CategoriesAdministrationControllerTests
    {
        
        [TestMethod]
        public void IndexMethodShouldReturnView()
        {
            int id = 1;

            var list = new List<Catalogue>();
            list.Add(new Catalogue() { Id = id });
            list.Add(new Catalogue() { Id = id + 1 });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Catalogues.All()).Returns(list.AsQueryable());
            var controller = new CategoriesAdministrationController(uowDataMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
        }

        [TestMethod]
        public void IndexMethodShouldLoadCataloguesListInViewData()
        {
            int id = 1;

            var list = new List<Catalogue>();
            list.Add(new Catalogue() { Id = id });
            list.Add(new Catalogue() { Id = id + 1 });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Catalogues.All()).Returns(list.AsQueryable());
            var controller = new CategoriesAdministrationController(uowDataMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var catList = viewResult.ViewData["catalogs"] as IEnumerable<SelectListItem>;
            Assert.IsNotNull(catList, "The catalogues list is null.");
            Assert.AreEqual(catList.Count(), 2);
        }


        [TestMethod]
        public void ReadCategoriesShouldReturnProperNumberOfCategories()
        {

            var list = new List<Category>();
            list.Add(new Category() { Id = 1, Name = "test", Catalogue = new Catalogue() { Name = "Test Catalogue"} });
            list.Add(new Category() { Id = 2, Name = "test2", Catalogue = new Catalogue() { Name = "Test Catalogue2" } });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Categories.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new CategoriesAdministrationController(uowDataMock.Object);
            var viewResult = controller.ReadCategories(new DataSourceRequest()) as JsonResult;
            Assert.IsNotNull(viewResult, "ReadCategories action returns null.");
            var data = viewResult.Data as DataSourceResult;
            var model = data.Data as IEnumerable<CategoryViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void ReadCategoriesWithEmptyDBShouldReturnEmptyList()
        {

            var list = new List<Category>();
        
            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Categories.All()).Returns(list.AsQueryable());
            var torrentRepoMock = uowDataMock.Object.Torrents;
            var controller = new CategoriesAdministrationController(uowDataMock.Object);
            var viewResult = controller.ReadCategories(new DataSourceRequest()) as JsonResult;
            Assert.IsNotNull(viewResult, "ReadCategories action returns null.");
            var data = viewResult.Data as DataSourceResult;
            var model = data.Data as IEnumerable<CategoryViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(0, model.Count());
        }

    }
}
