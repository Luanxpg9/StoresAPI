using FluentValidation;
using StoresAPI.Domain.Models;

namespace StoresAPI.Manager.UserManager
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            #region Name
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null")
                .MinimumLength(3).WithMessage("Minimum name length is 3 characters")
                .MaximumLength(450).WithMessage("Max length is 450 characters")
                .Matches(@"(^[\w\s]*$)").WithMessage("Please enter a valid name without special characters");
            #endregion

            #region CPF
            RuleFor(user => user.CPF)
                .NotEmpty().WithMessage("CPF can't be empty")
                .NotNull().WithMessage("CPF can't be null")
                .Matches(@"([0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2})+$").WithMessage("Please enter a valid CPF");
            #endregion

            #region Username
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username can't be empty")
                .MaximumLength(30).WithMessage("Max username length is 30 characters")
                .MinimumLength(5).WithMessage("Minimum username length is 5 characters")
                .Matches(@"^[a-zA-Z0-9-._]+$").WithMessage("Please enter a valid username");
            #endregion

            #region Password
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password can't be empty")
                .NotNull().WithMessage("Password can't be null")
                .MinimumLength(8).WithMessage("Password must have at least 8 characters")
                .MaximumLength(100).WithMessage("Max password length is 100 characters")
                .Matches(@"^^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$").WithMessage("Password must contain one uppercase, one lowercase and one digit from 0-9");
            #endregion
        }
    }
}
