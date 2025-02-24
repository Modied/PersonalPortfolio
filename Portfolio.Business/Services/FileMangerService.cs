using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class FileMangerService : IFileManager
    {
        private readonly IWebHostEnvironment _hosting;

        public FileMangerService(IWebHostEnvironment hosting)
        {
            _hosting = hosting;
        }
        public async Task<string> CopyFileName(IFormFile File)
        {

            if (File != null)
            {
                var result = await GetFullPathWithRansdomName(File);
                using (var fileStream = new FileStream(result[2], FileMode.Create))
                {
                    await File.CopyToAsync(fileStream);
                }
                return result[1];

            }
            else
                return null;

        }


        public async Task<string> CopyFileName(IFormFile File, string ImageUrl)
        {
            if (File != null)
            {
                var result = await GetFullPathWithRansdomName(File);

                string oldName = ImageUrl;

                string oldFullPath = string.Empty;

                if (!string.IsNullOrEmpty(ImageUrl))
                {
                    oldFullPath = Path.Combine(result[0], ImageUrl);

                    if (System.IO.File.Exists(oldFullPath) && oldFullPath != result[2])
                    {
                        System.IO.File.Delete(oldFullPath);
                    }
                }

                using (var fileStream = new FileStream(result[2], FileMode.Create))
                {
                    await File.CopyToAsync(fileStream);
                }


                return result[1];
            }
            else
                return null;
        }

        public async Task<List<string>> GetFullPathWithRansdomName(IFormFile File)
        {
            string filesStorage = Path.Combine(_hosting.WebRootPath, "FilesStorage");
            string randomName = string.Concat(Guid.NewGuid().ToString(), Path.GetExtension(File.FileName));
            string fullPath = Path.Combine(filesStorage, randomName);

            return new List<string>() { filesStorage, randomName, fullPath };
        }

        public void DeletFileName(string ImageUrl)
        {
            if (!string.IsNullOrEmpty(ImageUrl))
            {
                string filesStorage = Path.Combine(_hosting.WebRootPath, "FilesStorage");
                string oldName = ImageUrl;
                string oldFullPath = string.Empty;

                if (oldName is not null)
                    oldFullPath = Path.Combine(filesStorage, oldName);

                if (File.Exists(oldFullPath))
                {
                    try
                    {

                        File.Delete(oldFullPath);
                    }
                    catch (Exception ex)
                    { }
                }


            }

        }
    }
}
