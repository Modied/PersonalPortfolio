using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public class AchievedFor
    {
        [Key]
        public int Id { get; set; }

        public int? CompanyId { get; set; }

        public int? CustomerId { get; set; }

        public int AchievementId { get; set; }




    }
}
