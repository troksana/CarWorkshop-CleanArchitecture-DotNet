using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
    {
        private readonly IUserContext _usercontext;
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;

        public CreateCarWorkshopCommandHandler(IUserContext usercontext, ICarWorkshopRepository carWorkshopRepository,
            ICarWorkshopServiceRepository carWorkshopServiceRepository)
        {
            _usercontext = usercontext;
            _carWorkshopRepository = carWorkshopRepository;
            _carWorkshopServiceRepository = carWorkshopServiceRepository;
        }
        public async Task<Unit> Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.CarWorkshopEncodedName!);

            var user = _usercontext.GetCurrentUser();
            var IsEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!IsEditable)
            {
                return Unit.Value;
            }
            //tworzymy obiekt na podstawie pobranych danych z przegladarki od zalogowanego uzytkownika
            var carWorkshopService = new Domain.Entities.CarWorkshopService()
            {
                Cost = request.Cost,
                Description = request.Description,
                CarWorkshopId= carWorkshop.Id,

            };

            await _carWorkshopServiceRepository.Create(carWorkshopService);
            return Unit.Value;
        }
    }
}
