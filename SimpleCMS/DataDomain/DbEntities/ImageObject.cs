using System.ComponentModel.DataAnnotations;

namespace DataDomain.DbEntities
{
    public class ImageObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public User UploadedBy { get; set; }
        [Required]
        public string Path { get; set; }
    }
}
