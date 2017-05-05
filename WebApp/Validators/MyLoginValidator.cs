using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Validators
{
    public class MyLoginValidator : ValidationAttribute
    {
        private int maxLength = 20;
        private int minLength = 5;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string Login = value.ToString();
                if(Login.Count() > maxLength || Login.Count()< minLength)
                {
                    return new ValidationResult("Login musi zawierać od "+ minLength + " do "+ maxLength + " znaków");
                }
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Nie wprowadziłeś Loginu");
            }
        }
    }
}