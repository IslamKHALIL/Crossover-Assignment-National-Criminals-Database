using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NationalCriminalsDB.Service.ViewModels;

namespace NationalCriminalsDB.Service
{
    [ServiceContract]
    public interface ISearchService
    {
        [OperationContract]
        bool Search(SearchViewModel model);
    }
}
