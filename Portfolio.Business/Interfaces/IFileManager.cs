using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface IFileManager
    {
        Task<string> CopyFileName(IFormFile File);
        Task<string> CopyFileName(IFormFile File, string ImageUrl);
        void DeletFileName(string ImageUrl);
        Task<List<string>> GetFullPathWithRansdomName(IFormFile fileName);

    }
}
