using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NationalCriminalsDB.Service.Helpers;
using NationalCriminalsDB.Service.ViewModels;

namespace NationalCriminalsDB.Service.Test
{
    [TestClass]
    public class SearchServiceTest
    {
        Mock<ISearchService> serviceMock = new Mock<ISearchService>();

        [TestMethod]
        public void Search_NullInput()
        {
            var res = serviceMock.Object.Search(null);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Search_EmptyModelInput()
        {
            var searchViewModelMock = new Mock<SearchViewModel>();
            var res = serviceMock.Object.Search(searchViewModelMock.Object);
            Assert.IsFalse(res);
        }
    }
}
