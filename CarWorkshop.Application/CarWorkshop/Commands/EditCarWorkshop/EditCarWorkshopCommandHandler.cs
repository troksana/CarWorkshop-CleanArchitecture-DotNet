using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshsop;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
            private readonly ICarWorkshopRepository _repository;
            private readonly IUserContext _userContext;

        public EditCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IUserContext userContext)
            {

            _repository = carWorkshopRepository;
            _userContext = userContext;

            } 
            public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
            {

            var carWorkshop = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var IsEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!IsEditable) 
            {
                return Unit.Value;
            }
            carWorkshop.Description = request.Description;
            carWorkshop.About = request.About;

            carWorkshop.ContactDetails.City = request.City;
            carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            carWorkshop.ContactDetails.Street = request.Street;

            await _repository.Commit();

            return Unit.Value;

            }
        }
    }

