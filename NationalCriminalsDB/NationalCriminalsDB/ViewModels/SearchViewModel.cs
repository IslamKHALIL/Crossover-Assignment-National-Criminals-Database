using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalCriminalsDB.Service.Models;
using NationalCriminalsDB.Service.ViewModels;

namespace NationalCriminalsDB.ViewModels
{
    public class SearchViewModel : ISearchViewModel
    {
        [Display(Name = "Criminal's first name")]
        public string FirstName { get; set; }

        [Display(Name = "Criminal's last name")]
        public string LastName { get; set; }

        [Display(Name = "Criminal's address")]
        public string Address { get; set; }

        [Display(Name = "Criminal's nationality")]
        public string Nationality { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Minimal age")]
        public int? MinAge { get; set; }

        [Display(Name = "Maximal age")]
        [Range(0, int.MaxValue)]
        public int? MaxAge { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Minimal weight")]
        public double? MinWeight { get; set; }

        [Display(Name = "Maximal weight")]
        [Range(0, double.MaxValue)]
        public double? MaxWeight { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Minimal height")]
        public double? MinHeight { get; set; }

        [Display(Name = "Maximal height")]
        [Range(0, double.MaxValue)]
        public double? MaxHeight { get; set; }

        [Display(Name = "From date of birth")]
        public DateTime? FromDateOfBirth { get; set; }

        [Display(Name = "To date of birth")]
        public DateTime? ToDateOfBirth { get; set; }

        public Sex? Sex { get; set; }

        [Required(ErrorMessage = "You have to specify the max results count")]
        [Range(1, int.MaxValue)]
        [Display(Name = "Max results count")]
        public int? MaxResultCount { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Requester")]
        public string RequesterEmail { get; set; }

        public bool HasAtLeastOneFilter
        {
            get
            {
                return this.GetType().GetProperties().Any(p => p.Name != "RequesterEmail" && p.GetValue(this) != null);
            }
        }
    }
}
