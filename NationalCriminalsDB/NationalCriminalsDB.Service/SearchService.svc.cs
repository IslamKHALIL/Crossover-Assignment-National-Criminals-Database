using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NationalCriminalsDB.Service.Helpers;
using NationalCriminalsDB.Service.Models;
using NationalCriminalsDB.Service.Repositories;
using NationalCriminalsDB.Service.ViewModels;

namespace NationalCriminalsDB.Service
{
    public class SearchService : ISearchService, IDisposable
    {
        private ICriminalRepository criminalRepositoryService;
        private static IUnityContainer container;

        public SearchService()
        {
            criminalRepositoryService = container.Resolve<ICriminalRepository>();
        }

        public static void Configure(ServiceConfiguration config)
        {
            config.LoadFromConfiguration();
            container = UnityConfig.GetConfiguredContainer();
        }

        public bool Search(SearchViewModel model)
        {
            if (model == null)
                return false;

            if (model.HasAtLeastOneFilter)
            {
                var files = new List<FileInfo>();
                foreach (var item in GetResults(model))
                {
                    var file = container.Resolve<IPDFCreator>().CreatePdf(item);
                    if (file != null)
                        files.Add(file);
                }
                try
                {
                    SendDataAsync(files, 10, model.RequesterEmail);
                }
                catch
                {
                    return false;
                }
            }
            return model.HasAtLeastOneFilter;
        }

        private IEnumerable<ResultsViewModel> GetResults(ISearchViewModel model)
        {
            foreach (var item in criminalRepositoryService.Get(model))
                yield return new ResultsViewModel(item);
        }

        private Task SendDataAsync(IEnumerable<FileInfo> files, int countPerMail, string recipient)
        {
            var tasks = new List<Task>();
            var mail = container.Resolve<IMail>();
            if (files.Count() > countPerMail)
            {
                foreach (var item in files.Batch(countPerMail))
                    tasks.Add(mail.SendEmailAsync(recipient, item));
                return Task.WhenAll(tasks);
            }
            return mail.SendEmailAsync(recipient, files);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}
