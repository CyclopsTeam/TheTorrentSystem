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
using Microsoft.AspNet.Identity.EntityFramework;

namespace TorrentSite.Tests
{
    [TestClass]
    public class UsersControllerTests
    {

        [TestMethod]
        public void IndexShouldLoadRolesListInViewData()
        {
            var list = new List<Role>();
            list.Add(new Role() { Id = "1", Name = "User" });
            list.Add(new Role() { Id = "2", Name = "Admin" });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Roles.All()).Returns(list.AsQueryable());
            var controller = new UsersController(uowDataMock.Object);
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var rolesList = viewResult.ViewData["roles"] as IEnumerable<SelectListItem>;
            Assert.IsNotNull(rolesList, "The roles list is null.");
            Assert.AreEqual(rolesList.Count(), 2);
        }

        [TestMethod]
        public void ReadUsersShouldReturnProperNumberOfUsers()
        {

            var list = new List<ApplicationUser>();
            list.Add(new ApplicationUser() { Id = "1", UserName = "test", Roles = new List<UserRole>() });
            list.Add(new ApplicationUser() { Id = "2", UserName = "test2", Roles = new List<UserRole>() });

            var uowDataMock = new Mock<IUowData>();
            uowDataMock.Setup(x => x.Users.All()).Returns(list.AsQueryable());
            var controller = new UsersController(uowDataMock.Object);
            var viewResult = controller.ReadUsers(new DataSourceRequest()) as JsonResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var data = viewResult.Data as DataSourceResult;
            var model = data.Data as IEnumerable<UserViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());
        }

    }
}
