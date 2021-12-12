using Microsoft.AspNetCore.Identity;

namespace Pindorama.Services.Validation
{
    public class ErrorDescriber : IdentityErrorDescriber
    {

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = "InvalidUserName",
                Description = $"Nome de usuário inválido {userName}, deve conter apenas letras e digitos."
            };
        }
        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code = "InvalidEmail",
                Description = $"Email {email} inválido."
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = "DuplicateUserName",
                Description = $"Já existe um usuário utilizando o nome {userName}."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "É necessário a inserção de caracteres maíusculos na senha!"
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = "PasswordTooShort",
                Description = "Senha muito pequena! Ela deve conter de 6 a 100 caracteres."
            };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError
            {
                Code = "PasswordRequiresUniqueChars",
                Description = "Sua senha deve possuir caracteres únicos!"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = @"Sua senha deve possuir caracteres não-alfanúmericos como ""_ e -"""        
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresDigit",
                Description = "Sua senha deve possuir números!"      
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresLower",
                Description = "Sua senha deve possuir caracteres minúsculos!"     
            };
        }
    }
}
