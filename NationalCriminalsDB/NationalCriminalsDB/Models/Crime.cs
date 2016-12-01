using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCriminalsDB.Models
{
    public class Crime : ICrime
    {
        [Key]
        public Guid CrimeID { get; set; }

        [Required]
        public CrimeType Type { get; set; }

        public string Victime { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public string Location { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ICriminal> Criminals { get; set; }
    }

    public enum CrimeType
    {
        Homicide,
        Robbery,
        Rape
    }
}
