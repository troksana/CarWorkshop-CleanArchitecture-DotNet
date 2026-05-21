using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    //jej zadanie to walidacja konkretnych pól
    public class CreateCarWorkshopServiceCommandValidator:AbstractValidator<CreateCarWorkshopServiceCommand>
    {
        public CreateCarWorkshopServiceCommandValidator() 
        {
            RuleFor(s => s.Cost).NotEmpty().NotNull();
            RuleFor(s => s.Description).NotEmpty().NotNull();
            RuleFor(s => s.CarWorkshopEncodedName).NotEmpty().NotNull();

        }
    }
}
