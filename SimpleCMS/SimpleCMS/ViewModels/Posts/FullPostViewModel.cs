using DataDomain.DbEntities;
using SimpleCms.ViewModels.Pages;

namespace SimpleCms.ViewModels.Posts
{
    public class FullPostViewModel : FullPageViewModel
    {
        public string Description { get; set; }
        public string CoverImagePath { get; set; }
        public User Author { get; set; }
    }
}
