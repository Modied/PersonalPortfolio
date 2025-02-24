
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.ViewModels
{
    public class AchievementVModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required, StringLength(500)]
        public string Features { get; set; }

        [Range(0, 255)]
        public byte? Priority { get; set; }

        [Required, StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int? CompanyId { get; set; }

        public Company? Company { get; set; }

        public List<CompanyVModel>? Companies { get; set; }

        public int? CustomerId { get; set; }

        public Customer? Customer { get; set; }
        public List<CustomerVModel>? Customers { get; set; }

        // public ICollection<AchievedFor>? achievedFors { get; set; }
    }
}
