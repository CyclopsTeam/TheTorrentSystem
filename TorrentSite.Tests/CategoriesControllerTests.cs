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

namespace TorrentSite.Tests
{
    [TestClass]
    public class CategoriesControllerTests
    {
        
        [TestMethod]
        public void CategoriesMethodShouldReturnProperObject()
        {
            int id = 1;

            var list = new List<Category>();
            list.Add(new Category() { Id = id });
            list.Add(new Category() { Id = id + 1 });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Categories.All()).Returns(list.AsQueryable());
            var controller = new CategoriesController(uowDataMock.Object);
            var viewResult = controller.Categories(id) as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<CategoryViewModel>;
            Assert.IsNotNull(model, "The model is null.");
        }

        [TestMethod]
        public void CategoriesMethodShouldReturnEmptyListIfIdDoesNotExists()
        {
            int id = 1;

            var list = new List<Category>();
            list.Add(new Category() { Id = id + 1 });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Categories.All()).Returns(list.AsQueryable());
            var controller = new CategoriesController(uowDataMock.Object);
            var viewResult = controller.Categories(id) as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<CategoryViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(model.Count(), 0);
        }

        [TestMethod]
        public void CategoriesMethodShouldReturnEmptyListIfDbIsEmpty()
        {
            int id = 1;

            var list = new List<Category>();

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Categories.All()).Returns(list.AsQueryable());
            var controller = new CategoriesController(uowDataMock.Object);
            var viewResult = controller.Categories(id) as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<CategoryViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(model.Count(), 0);
        }

        //[TestMethod]
        //public void IndexMethodShouldReturnProperNumberOfCategories()
        //{
        //    var list = new List<Category>();
        //    list.Add(new Category());
        //    list.Add(new Category());

        //    var uowDataMock = new Mock<IUowData>();
        //    uowDataMock.Setup(x => x.Categories.All()).Returns(list.AsQueryable());
        //    var categoryRepoMock = uowDataMock.Object.Categories;
        //    var controller = new CategoriesController(uowDataMock.Object);
        //    var viewResult = controller.Index() as ViewResult;
        //    Assert.IsNotNull(viewResult, "Index action returns null.");
        //    var model = viewResult.Model as IEnumerable<CategoryViewModel>;
        //    Assert.IsNotNull(model, "The model is null.");
        //    Assert.AreEqual(2, model.Count());
        //}

        //[TestMethod]
        //public void IndexMethodShouldReturnProperNumberOfCategoriesWhenModelIsEmpty()
        //{
        //    var list = new List<Category>();

        //    var uowDataMock = new Mock<IUowData>();
        //    uowDataMock.Setup(x => x.Categories.All()).Returns(list.AsQueryable());
        //    var ategoryRepoMock = uowDataMock.Object.Categories;
        //    var controller = new CategoriesController(uowDataMock.Object);
        //    var viewResult = controller.Index() as ViewResult;
        //    Assert.IsNotNull(viewResult, "Index action returns null.");
        //    var model = viewResult.Model as IEnumerable<CategoryViewModel>;
        //    Assert.IsNotNull(model, "The model is null.");
        //    Assert.AreEqual(0, model.Count());
        //}
    }
}
