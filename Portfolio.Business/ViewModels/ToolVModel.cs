
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.ViewModels
{/*
  
  
   
  */
    public class ToolVModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [AllowNull]
        public string? Type { get; set; }

        public byte Priority { get; set; }

    }
}
