using FluentValidation;
using Pindorama.Models;

namespace Pindorama.Services.Validation
{
    public class SizeValidation : AbstractValidator<Usuario>
    {
        public SizeValidation()
        {
            RuleFor(u => u.cnpj).Length(18).Unless(u => u.cpf is not null).WithMessage("CNPJ deve ter 18 caracteres!");
            RuleFor(u => u.cep).Length(9).WithMessage("CEP deve ter 9 caracteres!!");
            RuleFor(u => u.cpf).Length(14).Unless(u => u.cnpj is not null).WithMessage("CPF deve ter 14 caracteres!");
        }
    }
}
