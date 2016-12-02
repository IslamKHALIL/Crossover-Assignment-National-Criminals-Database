using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NationalCriminalsDB.Service.Helpers;

namespace NationalCriminalsDB.Service.Test.Helpers
{
    [TestClass]
    public class MailTest
    {
        private static IConfiguration config = new Mock<IConfiguration>().Object;
        private IMail mail = new Mail(config);

        [TestMethod]
        public async Task SendEMail_NullRecipient()
        {
            try
            {
                await mail.SendEmailAsync(null, new Mock<IEnumerable<FileInfo>>().Object);
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false);
        }

        [TestMethod]
        public async Task SendEMail_NullRecipient_NullFiles()
        {
            try
            {
                await mail.SendEmailAsync(null, null);
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false);
        }

        [TestMethod]
        public async Task SendEMail_BadEmailRecipient()
        {
            try
            {
                await mail.SendEmailAsync(It.IsAny<string>(), new Mock<IEnumerable<FileInfo>>().Object);
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false);
        }

        [TestMethod]
        public async Task SendEMail_BadEmailRecipient_NullFiles()
        {
            try
            {
                await mail.SendEmailAsync(It.IsAny<string>());
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void SendEMail_NullMailInput()
        {
            try
            {
                var res = mail.SendEmailAsync(null);
            }
            catch (NullReferenceException)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false);
        }
    }
}
