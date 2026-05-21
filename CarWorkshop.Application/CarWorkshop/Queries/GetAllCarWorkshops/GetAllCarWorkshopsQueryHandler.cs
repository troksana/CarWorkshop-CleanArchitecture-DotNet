using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops
{
    public class GetAllCarWorkshopsQueryHandler : IRequestHandler<GetAllCarWorkshopsQuery, IEnumerable<CarWorkshopDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICarWorkshopRepository _carWorkshopRepository;
       public GetAllCarWorkshopsQueryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper) 
        {
            _mapper = mapper; //Zapisuje przekazany mapper do pola prywatnego
            _carWorkshopRepository = carWorkshopRepository;

        }
        public async Task<IEnumerable<CarWorkshopDto>> Handle(GetAllCarWorkshopsQuery request, CancellationToken cancellationToken)
        {
            var carWorkshops = await _carWorkshopRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);

            return dtos;
        }
    }
}
