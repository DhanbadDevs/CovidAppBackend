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
            CreateMap<Vaccine, VaccineModel>();
            CreateMap<VaccineModel, Vaccine>();
            CreateMap<Location, LocationModel>();
            CreateMap<LocationType, LocationTypeModel>();
            CreateMap<City, CityModel>();
        }
    }
}
