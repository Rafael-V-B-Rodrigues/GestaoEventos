using System.ComponentModel.DataAnnotations;

namespace GestaoEventos.Application.Validations
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var texto = value.ToString();
            if (texto!.Length > 0 && !char.IsUpper(texto[0]))
            {
                return new ValidationResult("A primeira letra deve ser maiúscula.");
            }

            return ValidationResult.Success;
        }
    }
}