using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CovidApp.Model;
using CovidApp.Persistance.API;
using CovidApp.Persistance.CovidAppContext;
using CovidApp.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CovidApp.Persistance
{
    public class AmbulanceRepository :IAmbulanceRepository 
    {
        readonly CovidAppDbContext dbContext;
        readonly ILogger<AmbulanceRepository> logger;
        readonly IMapper mapper;

        public AmbulanceRepository(CovidAppDbContext dbContext, ILogger<AmbulanceRepository> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<Tuple<AmbulanceModel>> AddAmbulance(AmbulanceModel ambulanceModel)
        {
            /*var ambulance = new Ambulance {
                AmbulanceName=ambulanceModel.AmbulanceName,
                IsAirConditioned=ambulanceModel.IsAirConditioned,
                OxygenAvailable=ambulanceModel.OxygenAvailable,
                ProvidesOutstationService=ambulanceModel.ProvidesOutstationService,
                AcceptsCovidPatient = ambulanceModel.AcceptsCovidPatient,
                Charges = ambulanceModel.Charges,
                IsVerified = ambulanceModel.IsVerified,
                Timing = ambulanceModel.Timing,
                Notes = ambulanceModel.Notes,
                UpdatedOn=ambulanceModel.UpdatedOn,
                Phone=ambulanceModel.Phone,
                Votes=ambulanceModel.Votes,
                CreatedOn=ambulanceModel.CreatedOn,
                CityId=ambulanceModel.CityId
            };*/
           
            var ambulance =mapper.Map<AmbulanceModel, Ambulance>(ambulanceModel);
            await dbContext.Ambulances.AddAsync(ambulance);
            await dbContext.SaveChangesAsync();
            return Tuple.Create(ambulanceModel);
        }

        public async Task<IList<AmbulanceModel>> GetAmbulances()
        {
            try
            {
                var results = await dbContext.Ambulances
                                            .Include(x => x.City)
                                            .OrderByDescending(x => x.IsVerified)
                                            .ToListAsync();
                return mapper.Map<List<Ambulance>, List<AmbulanceModel>>(results);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to Get Vaccine", ex);
                return null;
            }
        }
    }
}
