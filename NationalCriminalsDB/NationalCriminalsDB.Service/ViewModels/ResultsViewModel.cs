using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalCriminalsDB.Service.Models;

namespace NationalCriminalsDB.Service.ViewModels
{
    internal class ResultsViewModel : IResultsViewModel
    {
        public ResultsViewModel(ICriminal criminal)
        {
            FullName = $"{criminal.FirstName} {criminal.LastName}";
            Photo = criminal.Photo;
            Address = criminal.Address;
            Nationality = criminal.Nationality;
            DateOfBirth = criminal.DateOfBirth;
            Height = criminal.Height;
            Weight = criminal.Weight;
            Sex = criminal.Sex;
            Age = criminal.Age;
            if (criminal.CriminalHistory != null)
            {
                foreach (var crime in criminal.CriminalHistory)
                    (CriminalHistory as List<ICrimeViewModel>).Add(new CrimeViewModel(crime));
            }
        }

        public string FullName { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public Sex Sex { get; set; }
        public IEnumerable<ICrimeViewModel> CriminalHistory { get; set; } = new List<ICrimeViewModel>();
    }
}
