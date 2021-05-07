using AutoMapper;
using CovidApp.Model;
using CovidApp.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Persistance.AutoMapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<VaccinationCentre, VaccinationCentreModel>();
            CreateMap<VaccinationCentreModel, VaccinationCentre>().ForMember(x => x.Location, opt => opt.Ignore())
                                                                  .ForMember(x => x.City, opt => opt.Ignore());
            CreateMap<Location, LocationModel>();
            CreateMap<LocationModel, Location>().ForMember(x => x.LocationType, opt => opt.Ignore())
                                                .ForMember(x => x.City, opt => opt.Ignore());
            CreateMap<LocationType, LocationTypeModel>();
            CreateMap<LocationTypeModel, LocationType>();
            CreateMap<City, CityModel>();
            CreateMap<Ambulance, AmbulanceModel>();
            CreateMap<AmbulanceModel, Ambulance>();
            CreateMap<CityModel, City>();

        }
    }
}
