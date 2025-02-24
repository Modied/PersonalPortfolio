using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.ViewModels
{
    public class CustomerVModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? About { get; set; }
        public byte Priority { get; set; }
        public string Description { get; set; }

    }
}
