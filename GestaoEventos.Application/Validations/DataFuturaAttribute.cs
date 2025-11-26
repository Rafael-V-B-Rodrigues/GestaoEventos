using System.ComponentModel.DataAnnotations;

namespace GestaoEventos.Application.Validations
{
    public class DataFuturaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            DateTime data = (DateTime)value;

            if (data < DateTime.Now)
            {
                return new ValidationResult("A data do evento deve ser futura.");
            }

            return ValidationResult.Success;
        }
    }
}