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
            CreateMap<VaccinationCentre, VaccineModel>();
            CreateMap<VaccineModel, VaccinationCentre>();
            CreateMap<Location, LocationModel>();
            CreateMap<LocationType, LocationTypeModel>();
            CreateMap<City, CityModel>();
        }
    }
}
