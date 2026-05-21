using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Application.CarWorkshopService;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Mappings
{
    public class CarWorkshopMappingProfile : Profile
    {
        public CarWorkshopMappingProfile(IUserContext userContext) 
        {
            var user = userContext.GetCurrentUser();
            //mapowanie gdy uzytkownik wpisuje dane i one ida do bazy danych (CarWorkshopDto ->Domain.Entities.CarWorkshop)
            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(e => e.ContactDetails, otp => otp.MapFrom(scr => new CarWorkshopContactDetails()
                {
                    City = scr.City,
                    PhoneNumber = scr.PhoneNumber,
                    PostalCode = scr.PostalCode,
                    Street = scr.Street,
                }));
            //mapowanie gdy chcemy z bazy danych dane chcemy wyswietlic po stronie interface dla uzytkownika zeby widzial
            //reszta jest mapowana automatycznie bo typy sie pokrywaja
            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(scr => user != null 
                                && (scr.CreatedById == user.Id || user.IsInRole("Moderator"))))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(scr => scr.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(scr => scr.ContactDetails.City))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(scr => scr.ContactDetails.PhoneNumber))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(scr => scr.ContactDetails.PostalCode));

            CreateMap<CarWorkshopDto, EditCarWorkshopCommand>();

            CreateMap<CarWorkshopServiceDto,Domain.Entities.CarWorkshopService>().ReverseMap();
        }

    }
}
