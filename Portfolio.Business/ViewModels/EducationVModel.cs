
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.ViewModels
{
    public class EducationVModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Institution { get; set; }

        [Required, StringLength(100)]
        public string Major { get; set; }

        [Required, StringLength(50)]
        public string Degree { get; set; }

        [AllowNull]
        public DateTime? StartDate { get; set; }

        [AllowNull]
        public DateTime? EndDate { get; set; }

        public int EducationTypeId { get; set; }
        public List<EducationType>? EducationTypes { get; set; }
        // public EducationType? EducationType { get; set; }

    }
}
