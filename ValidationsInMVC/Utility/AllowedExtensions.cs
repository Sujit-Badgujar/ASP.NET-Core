using System.ComponentModel.DataAnnotations;

namespace ValidationsInMVC.Utility
{
    public class AllowedExtensions : ValidationAttribute
    {
        private readonly string[] _allowedExtensions;
        public AllowedExtensions(string[] extension)
        {
            _allowedExtensions = extension;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null) 
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_allowedExtensions.Contains(extension.ToLower())) 
                {
                    return new ValidationResult($"This image file extension is not allowed!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
