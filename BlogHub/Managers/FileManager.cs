using BlogHub.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogHub.Managers
{
    public class FileManager
    {
        readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileManager(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public string UploadedFile(IFormFile pictureFile)
        {
            string uniqueFileName = null;

            if (pictureFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + pictureFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    pictureFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public void RemoveUnneccessaryFiles()
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            List<string> fileList = Directory.GetFiles(uploadsFolder, "*")
                                     .Select(Path.GetFileName)
                                     .Where(x => !x.Equals("null.png"))
                                     .ToList();

            var databaseFiles = _context.Articles.Where(x => !string.IsNullOrEmpty(x.ArticlePicture)).Select(x => x.ArticlePicture).ToList();



            // fileList - veritabaninda olmayanlar.
            var unneccesaryList = fileList.Where(x => !databaseFiles.Contains(x)).ToList();

            foreach (var image in unneccesaryList)
            {
                var uri = new Uri("file:" + Path.Combine(uploadsFolder, image), UriKind.Absolute);
                System.IO.File.Delete(uri.LocalPath);
            }
        }


        public string GetImageName(string imageName)
        {
            string name = "Choose File";
            if (!string.IsNullOrEmpty(imageName))
            {
                //93b56cb5-1bbc-4211-a640-40135d82e885_dosyaismi.jpg
                // _'den itibaren uniqueFileName içerisindeki dosya adını ve uzantısını alır.
                name = imageName.Substring(37);
            }
            return name;
        }
    }
}
