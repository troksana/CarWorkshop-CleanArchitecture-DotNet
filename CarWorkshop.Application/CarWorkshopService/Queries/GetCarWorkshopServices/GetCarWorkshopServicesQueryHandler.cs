using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Queries.GetCarWorkshopServices
{
    //komunikuje sie z baza danych 
    public class GetCarWorkshopServicesQueryHandler : IRequestHandler<GetCarWorkshopServicesQuery, IEnumerable<CarWorkshopServiceDto>>
    {
        private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;   
        private readonly IMapper _mapper;

        public GetCarWorkshopServicesQueryHandler(ICarWorkshopServiceRepository carWorkshopServiceRepository, IMapper mapper)
        {
            _carWorkshopServiceRepository = carWorkshopServiceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarWorkshopServiceDto>> Handle(GetCarWorkshopServicesQuery request, CancellationToken cancellation)
        {
            var result = await _carWorkshopServiceRepository.GetAllByEncodedName(request.EncodedName);
            var dtos = _mapper.Map<IEnumerable<CarWorkshopServiceDto>>(result);

            return dtos;
        }
    }
}
