using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCriminalsDB.Models
{
    public class Criminal : ICriminal
    {
        [Key]
        public Guid CriminalId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual ICollection<ICrime> CriminalHistory { get; set; }
    }
}
