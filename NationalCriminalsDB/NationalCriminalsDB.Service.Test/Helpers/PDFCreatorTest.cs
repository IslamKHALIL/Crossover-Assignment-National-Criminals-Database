using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NationalCriminalsDB.Service.ViewModels;


namespace NationalCriminalsDB.Service.Helpers
{
    [TestClass]
    public class PDFCreatorTest
    {
        Mock<PDFCreator> pdfCreatorMock = new Mock<PDFCreator>();

        [TestMethod]
        public void CreatePdf_NullInput()
        {
            var res = pdfCreatorMock.Object.CreatePdf(null);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void CreatePdf_EmptyModel()
        {
            var vm = new Mock<IResultsViewModel>();
            var res = pdfCreatorMock.Object.CreatePdf(vm.Object);
            Assert.IsNull(res);
        }
    }
}
