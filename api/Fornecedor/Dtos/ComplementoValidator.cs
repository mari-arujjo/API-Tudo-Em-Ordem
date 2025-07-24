using System.ComponentModel.DataAnnotations;

namespace api.Fornecedor.Dtos
{
    public class ComplementoValidador : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var complemento = value as string;

            if (string.IsNullOrWhiteSpace(complemento))
                return ValidationResult.Success;

            if (complemento.Length < 5)
                return new ValidationResult("O complemento deve ter no mínimo 5 caracteres.");

            if (complemento.Length > 50)
                return new ValidationResult("Limite de caracteres: 50");

            return ValidationResult.Success;
        }
    }

}