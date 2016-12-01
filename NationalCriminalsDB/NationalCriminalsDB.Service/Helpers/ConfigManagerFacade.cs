using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCriminalsDB.Service.Helpers
{
    public interface IConfiguration
    {
        string SMTPHost { get; }
        string GmailId { get; }
        string GmailPswrd { get; }
    }

    internal class ConfigManagerFacade : IConfiguration
    {
        public string SMTPHost { get { return ConfigurationManager.AppSettings["SMTPHost"]; } }
        public string GmailId { get { return ConfigurationManager.AppSettings["GmailId"]; } }
        public string GmailPswrd { get { return ConfigurationManager.AppSettings["GmailPswrd"]; } }
    }
}
