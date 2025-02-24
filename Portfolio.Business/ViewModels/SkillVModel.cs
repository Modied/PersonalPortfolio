
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.ViewModels
{
    public class SkillVModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int SkillTypeId { get; set; }
        public SkillType? SkillType { get; set; }
        public List<SkillType>? SkillTypes { get; set; }

    }
}
