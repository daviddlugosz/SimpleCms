using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataDomain.DbEntities;
using DataLogic.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace DataLogic.Services
{
    public class ImageObjectsService : IImageObjectsService
    {
        private readonly DataContext _context;
        private readonly IHostingEnvironment _appEnvironment;

        public ImageObjectsService(DataContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IEnumerable<string> GetAllImagePaths()
        {
            return _context.ImageObjects.Select(io => io.Path);
        }

        public ImageObject UploadImage(string base64FileContent, string fileName, string description, string userName)
        {
            var result = new ImageObject();

            // TODO: Check for correct data type and deal with base64 prefix

            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
                throw new AppException("Error retrieving logged in user!");
            else
                result.UploadedBy = user;

            if (base64FileContent == null || base64FileContent.Length == 0)
                throw new AppException("File you are trying to upload is empty!");

            var path = _appEnvironment.WebRootPath + $"\\Images\\{user.Id}\\" + fileName;

            var file = new FileInfo(path);
            file.Directory.Create(); // Create folder if there is none
            var bytes = Convert.FromBase64String(base64FileContent);
            File.WriteAllBytes(path, bytes);

            result.Name = fileName;
            result.Description = description;
            result.Path = path.Replace(_appEnvironment.WebRootPath, "..").Replace("\\", "/");

            _context.ImageObjects.Add(result);
            _context.SaveChanges();

            return result;
        }
    }
}
