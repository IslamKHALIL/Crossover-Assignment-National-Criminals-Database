using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NationalCriminalsDB;
using NationalCriminalsDB.Controllers;
using NationalCriminalsDB.Models;
using NationalCriminalsDB.ViewModels;

namespace NationalCriminalsDB.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        //Test Search GET
        [TestMethod]
        public void GetSearch_NotLoggedInUser()
        {
            using (HomeController controller = new HomeController(new Mock<ApplicationUserManager>(new Mock<IUserStore<ApplicationUser>>().Object).Object))
            {
                var result = controller.Search();
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(ActionResult));
                Assert.IsTrue(result is ViewResult || result is RedirectToRouteResult);
            }
        }

        // Test Search POST
        [TestMethod]
        public void PostSearch_NullInput()
        {
            using (HomeController controller = new HomeController(new Mock<ApplicationUserManager>(new Mock<IUserStore<ApplicationUser>>().Object).Object))
            {
                var result = controller.Search(null);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Task<ActionResult>));
                Assert.IsNotNull(result.Result);
                Assert.IsInstanceOfType(result.Result, typeof(RedirectToRouteResult));
            }
        }

        [TestMethod]
        public void PostSearch_EmptyModelInput()
        {
            using (HomeController controller = new HomeController(new Mock<ApplicationUserManager>(new Mock<IUserStore<ApplicationUser>>().Object).Object))
            {
                var modelMock = new Mock<SearchViewModel>();
                var result = controller.Search(modelMock.Object);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Task<ActionResult>));
                Assert.IsNotNull(result.Result);
                Assert.IsInstanceOfType(result.Result, typeof(ViewResult));
            }
        }

        [TestMethod]
        public void PostSearch_WrongEmail_ModelInput()
        {
            using (HomeController controller = new HomeController(new Mock<ApplicationUserManager>(new Mock<IUserStore<ApplicationUser>>().Object).Object))
            {
                var modelMock = new Mock<SearchViewModel>();
                modelMock.Object.RequesterEmail = It.IsAny<string>();
                var result = controller.Search(modelMock.Object);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Task<ActionResult>));
                Assert.IsNotNull(result.Result);
                Assert.IsInstanceOfType(result.Result, typeof(ViewResult));
            }
        }

        [TestMethod]
        public void PostSearch_PopulatedModelWithNoEmailInput()
        {
            using (HomeController controller = new HomeController(new Mock<ApplicationUserManager>(new Mock<IUserStore<ApplicationUser>>().Object).Object))
            {
                var modelMock = new Mock<SearchViewModel>();
                modelMock.Object.LastName = It.IsAny<string>();
                var result = controller.Search(modelMock.Object);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Task<ActionResult>));
                Assert.IsNotNull(result.Result);
                Assert.IsInstanceOfType(result.Result, typeof(ViewResult));
                Assert.IsInstanceOfType((result.Result as ViewResult).Model, typeof(SearchViewModel));
            }
        }
    }
}
