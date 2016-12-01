using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NationalCriminalsDB.Service.Helpers;
using NationalCriminalsDB.Service.Models;
using NationalCriminalsDB.Service.Repositories;
using NationalCriminalsDB.Service.ViewModels;

namespace NationalCriminalsDB.Service.Test.Repositories
{
    [TestClass]
    public class CriminalRepositoryTest
    {
        Mock<ICriminalRepository> ICriminalRepositoryMock = new Mock<ICriminalRepository>();

        [TestMethod]
        public void GetWithNullCriteria()
        {
            var res = ICriminalRepositoryMock.Object.Get(null);
            Assert.IsNotNull(res);
            Assert.IsInstanceOfType(res, typeof(IEnumerable<ICriminal>));
        }

        [TestMethod]
        public void GetWithNoCriterias()
        {
            var criteriaMock = new Mock<ISearchViewModel>();
            var res = ICriminalRepositoryMock.Object.Get(criteriaMock.Object);
            Assert.IsNotNull(res);
            Assert.IsInstanceOfType(res, typeof(IEnumerable<ICriminal>));
        }
    }
}
