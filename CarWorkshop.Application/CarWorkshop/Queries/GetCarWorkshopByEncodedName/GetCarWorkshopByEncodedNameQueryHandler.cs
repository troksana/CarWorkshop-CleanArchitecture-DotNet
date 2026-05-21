using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName
{
    //na podstawie wartosci przekazanej przez klienta w sciezce zapytania przekazuje sie nazwe warsztatu do handlera i tu z bazy danych
    //uzyskujemy konkretny warsztat samochodowy ktory potem mapujemy
    public class GetCarWorkshopByEncodedNameQueryHandler : IRequestHandler<GetCarWorkshopByEncodedNameQuery, CarWorkshopDto>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;
        public GetCarWorkshopByEncodedNameQueryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper) 
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }
        public async Task<CarWorkshopDto> Handle(GetCarWorkshopByEncodedNameQuery request, CancellationToken cancellationToken)
        {
           var carWorkshop =await _carWorkshopRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<CarWorkshopDto>(carWorkshop);

            return dto;
        }
    }
}
