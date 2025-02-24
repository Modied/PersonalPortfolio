using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, Url, StringLength(500)]
        public string Url { get; set; }

        [StringLength(500)]
        public string? Icon { get; set; }



    }
}
