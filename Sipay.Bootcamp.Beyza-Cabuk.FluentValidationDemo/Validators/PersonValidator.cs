using FluentValidation;
using Sipay.Bootcamp.Beyza_Cabuk.FluentValidationDemo.Models;
using System.Text.RegularExpressions;


namespace Sipay.Bootcamp.Beyza_Cabuk.FluentValidationDemo.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Staff person name is required.")
                .Length(5, 100).WithMessage("The name must be between 5 and 100 characters.");

            RuleFor(p => p.Lastname)
                .NotEmpty().WithMessage("Staff person lastname is required.")
                .Length(5, 100).WithMessage("The lastname must be between 5 and 100 characters.");

            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("Staff person phone number is required.")
                .Must(IsPhoneNumber).WithMessage("The phone number is invalid.");

            RuleFor(p => p.AccessLevel)
                .NotEmpty().WithMessage("Staff person access level is required.")
                .InclusiveBetween(1, 5).WithMessage("Staff person access level must be between 1 and 5.");

            RuleFor(p => p.Salary)
                .NotEmpty().WithMessage("Staff person salary is required")
                .InclusiveBetween(5000, 50000).WithMessage("Staff person salary must be between 5000 and 50.000.")
                .Must((person, salary) => IsValidSalary(person.AccessLevel, salary)).WithMessage("Salary is not valid for the given access level.");
        }

        private bool IsPhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(@"^[0-9]{10}$");
            return regex.IsMatch(phoneNumber);
        }

        private bool IsValidSalary(int accessLevel, decimal salary)
        {
            switch (accessLevel)
            {
                case 1:
                    return salary <= 10000;
                case 2:
                    return salary <= 20000;
                case 3:
                    return salary <= 30000;
                case 4:
                    return salary <= 40000;
                default:
                    return false;
            }
        }
    }
}
