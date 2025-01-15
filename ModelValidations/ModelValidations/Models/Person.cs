using System.ComponentModel.DataAnnotations;

namespace ModelValidations.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Dear user, Enter your name!")]
        [Display(Name = "Person Name")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "{0} should be bet'n {2} to {1} characters long.")]
        [RegularExpression("^[A-Za-z.]*$", ErrorMessage = "{0} should only contain alphabets!")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage ="Improper {0}!")]
        public  string? Email { get; set; }
        [Phone(ErrorMessage ="Enter proper phone no.!")]
        public  string? Phone { get; set; }
        public  string? Password { get; set; }
        public  string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage ="{0} should be minimum {1} & max: {2}")]
        public  double? Price { get; set; }


        public override string ToString()
        {
            return $"Person Object- Person name: {PersonName}, Email: {Email}" +
                $"Phone : {Phone}, Password: {Password}, Confirm Pass: {ConfirmPassword}," +
                $"Price: {Price}";
        }
    }
}
