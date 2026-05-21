using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopValidator()
        {
            RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Please enter description");

            RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .MinimumLength(8).WithMessage("Name should have atleast 8 characters")
            .MaximumLength(12).WithMessage("Name should have atleast 12 characters");
        }
    }
}
