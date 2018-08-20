using System.ComponentModel.DataAnnotations;

namespace DataDomain.DbEntities
{
    public class Post : Page
    {
        public string Description { get; set; }
        public string CoverImagePath { get; set; }
        [Required]
        public User Author { get; set; }
    }
}
