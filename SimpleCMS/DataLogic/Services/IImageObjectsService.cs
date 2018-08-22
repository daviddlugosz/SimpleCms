using DataDomain.DbEntities;
using System.Collections.Generic;

namespace DataLogic.Services
{
    public interface IImageObjectsService
    {
        ImageObject UploadImage(string base64FileContent, string fileName, string description, string userName);
        IEnumerable<string> GetAllImagePaths();
    }
}
