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
            CreateMap<VaccinationCentreModel, VaccinationCentre>();
            CreateMap<Location, LocationModel>();
            CreateMap<LocationModel, Location>();
            CreateMap<LocationType, LocationTypeModel>();
            CreateMap<LocationTypeModel, LocationType>();
            CreateMap<City, CityModel>();
            CreateMap<Ambulance, AmbulanceModel>();
            CreateMap<AmbulanceModel, Ambulance>(); 
            CreateMap<CityModel, City>();
            CreateMap<HospitalBedModel, HospitalBed>();
            CreateMap<HospitalBed, HospitalBedModel>();
            CreateMap<MedicineEquipment, MedicineEquipmentModel>();
            CreateMap<MedicineEquipmentModel, MedicineEquipment>();
            CreateMap<MedicineEquipmentMaster, MedicineEquipmentMasterModel>();
            CreateMap<MedicineEquipmentMasterModel, MedicineEquipmentMaster>();
            CreateMap<Doctor, DoctorModel>();
            CreateMap<DoctorModel, Doctor>();
            CreateMap<OxygenModel, Oxygen>();
            CreateMap<Oxygen, OxygenModel>();
            CreateMap<Helpline, HelplineModel>();
            CreateMap<HelplineModel, Helpline>();
            CreateMap<FeedBack, FeedbackModel>();
            CreateMap<FeedbackModel, FeedBack>();
            CreateMap<Volunteer, VolunteerModel>();
            CreateMap<VolunteerModel, Volunteer>();
        }
    }
}
