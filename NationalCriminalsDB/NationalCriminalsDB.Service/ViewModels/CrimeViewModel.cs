using System;
using System.Collections.Generic;
using NationalCriminalsDB.Service.Models;
using System.Linq;

namespace NationalCriminalsDB.Service.ViewModels
{
    internal class CrimeViewModel : ICrimeViewModel
    {
        public CrimeViewModel(ICrime crime)
        {
            Description = crime.Description;
            Location = crime.Location;
            Time = crime.Time;
            Type = crime.Type;
            Victim = crime.Victime;
            if (crime.Criminals != null)
                Accomplices = string.Join(", ", crime.Criminals.Select(c => $"{c.FirstName} {c.LastName}"));
        }

        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public CrimeType Type { get; set; }
        public string Victim { get; set; }
        public string Accomplices { get; set; }
    }
}