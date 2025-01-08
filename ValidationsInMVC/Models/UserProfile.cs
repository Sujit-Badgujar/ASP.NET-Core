using ValidationsInMVC.Utility;

namespace ValidationsInMVC.Models
{
    public class UserProfile
    {
        public string Name { get; set; }

        [AllowedExtensions(new string[] { ".jpg",".jpeg",".png"})]
        public IFormFile Image { get; set; }
    }
}
