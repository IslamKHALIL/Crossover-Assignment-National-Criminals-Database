using System;
using System.Collections.Generic;
using NationalCriminalsDB.Service.Models;

namespace NationalCriminalsDB.Service.ViewModels
{
    public interface IResultsViewModel
    {
        string Address { get; set; }
        int Age { get; set; }
        IEnumerable<ICrimeViewModel> CriminalHistory { get; set; }
        DateTime DateOfBirth { get; set; }
        string FullName { get; set; }
        double Height { get; set; }
        string Nationality { get; set; }
        string Photo { get; set; }
        Sex Sex { get; set; }
        double Weight { get; set; }
    }
}