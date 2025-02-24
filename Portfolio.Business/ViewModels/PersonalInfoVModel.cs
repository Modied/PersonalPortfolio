using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.ViewModels
{
    public class PersonalInfoVModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required, Phone, StringLength(100)]
        public string Phone { get; set; }

        [Required, StringLength(200)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Bio { get; set; }

        [StringLength(200)]
        public string About { get; set; }
        [StringLength(200)]
        public string? ImageUrl { get; set; }
        public IFormFile? file { get; set; }

    }
}
