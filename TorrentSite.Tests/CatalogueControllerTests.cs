using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TorrentSite.Controllers;
using System.Web.Mvc;
using System.Collections;
using TorrentSite.Models;
using System.Collections.Generic;

namespace TorrentSite.Tests
{
    [TestClass]
    public class CatalogueControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {

            var controller = new CataloguesController();
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action does not return View");

            var model = viewResult.Model as IEnumerable<Catalogue>


        }
    }
}
