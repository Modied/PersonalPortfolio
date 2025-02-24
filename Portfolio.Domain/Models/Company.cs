using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? About { get; set; }

        [Required, StringLength(200)]
        public string Position { get; set; }

        [StringLength(1000)]
        public string? AboutJob { get; set; }

        public byte? Priority { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Achievement>? Achievements { get; set; } = new List<Achievement>();


    }
}
