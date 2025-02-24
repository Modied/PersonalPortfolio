
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.ViewModels
{
    public class AchievedForVModel
    {
        public int Id { get; set; }

        public string? CompnyId { get; set; }
        public Company? Company { get; set; }
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int AchievementId { get; set; }
    }
}
