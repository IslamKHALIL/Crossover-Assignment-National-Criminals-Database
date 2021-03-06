﻿using System;
using System.Collections.Generic;

namespace NationalCriminalsDB.Service.Models
{
    public interface ICrime
    {
        Guid CrimeID { get; set; }
        ICollection<Criminal> Criminals { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        DateTime Time { get; set; }
        CrimeType Type { get; set; }
        string Victime { get; set; }
    }
}