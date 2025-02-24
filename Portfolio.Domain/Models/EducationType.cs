using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public class EducationType
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Type { get; set; }

        public ICollection<Education> Educations { get; set; }

    }
}
