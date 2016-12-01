using System;
using System.Runtime.Serialization;
using NationalCriminalsDB.Service.Models;

namespace NationalCriminalsDB.Service.ViewModels
{
    public interface ISearchViewModel
    {
        string Address { get; set; }
        string FirstName { get; set; }
        DateTime? FromDateOfBirth { get; set; }
        string LastName { get; set; }
        int? MaxAge { get; set; }
        double? MaxHeight { get; set; }
        int? MaxResultCount { get; set; }
        double? MaxWeight { get; set; }
        int? MinAge { get; set; }
        double? MinHeight { get; set; }
        double? MinWeight { get; set; }
        string Nationality { get; set; }
        string RequesterEmail { get; set; }
        Sex? Sex { get; set; }
        DateTime? ToDateOfBirth { get; set; }
        bool HasAtLeastOneFilter { get; }
    }
}