using System;
using System.Collections.Generic;

namespace NationalCriminalsDB.Service.Models
{
    public interface ICriminal
    {
        string Address { get; set; }
        ICollection<Crime> CriminalHistory { get; set; }
        Guid CriminalId { get; set; }
        DateTime DateOfBirth { get; set; }
        string FirstName { get; set; }
        double Height { get; set; }
        string LastName { get; set; }
        string Nationality { get; set; }
        string Photo { get; set; }
        Sex Sex { get; set; }
        double Weight { get; set; }
        int Age { get; }
    }
}