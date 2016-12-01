using System;
using NationalCriminalsDB.Service.Models;

namespace NationalCriminalsDB.Service.ViewModels
{
    public interface ICrimeViewModel
    {
        string Accomplices { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        DateTime Time { get; set; }
        CrimeType Type { get; set; }
        string Victim { get; set; }
    }
}