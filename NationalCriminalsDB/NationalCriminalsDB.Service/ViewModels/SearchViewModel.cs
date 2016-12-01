using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using NationalCriminalsDB.Service.Models;

namespace NationalCriminalsDB.Service.ViewModels
{
    [DataContract]
    public class SearchViewModel : ISearchViewModel
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Nationality { get; set; }

        [DataMember]
        public int? MinAge { get; set; }

        [DataMember]
        public int? MaxAge { get; set; }

        [DataMember]
        public double? MinWeight { get; set; }

        [DataMember]
        public double? MaxWeight { get; set; }

        [DataMember]
        public double? MinHeight { get; set; }

        [DataMember]
        public double? MaxHeight { get; set; }

        [DataMember]
        public DateTime? FromDateOfBirth { get; set; }

        [DataMember]
        public DateTime? ToDateOfBirth { get; set; }

        [DataMember]
        public Sex? Sex { get; set; }

        [DataMember]
        public int? MaxResultCount { get; set; }

        [DataMember]
        public string RequesterEmail { get; set; }

        public bool HasAtLeastOneFilter
        {
            get
            {
                return GetType().GetProperties().Any(p => p.Name != "RequesterEmail" && p.GetValue(this) != null);
            }
        }
    }
}
