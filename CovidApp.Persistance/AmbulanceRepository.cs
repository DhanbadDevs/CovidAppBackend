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

        public async Task<AmbulanceModel> AddAmbulance(AmbulanceModel ambulanceModel)
        {
            try
            {
                var ambulance = mapper.Map<AmbulanceModel, Ambulance>(ambulanceModel);
                await dbContext.Ambulances.AddAsync(ambulance);
                await dbContext.SaveChangesAsync();
                return ambulanceModel;
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Add Ambulance", ex);
                return null;
            }

        }

        public async Task<IList<AmbulanceModel>> GetAmbulances(int cityId)
        {
            try
            {
                var ambulance = await dbContext.Ambulances
                                            .Where(x => x.CityId == cityId)
                                            .OrderByDescending(x => x.IsVerified)
                                            .ThenByDescending(x => x.AcceptsCovidPatient)
                                            .ThenByDescending(x=> x.OxygenAvailable)
                                            .ThenByDescending(x => x.ProvidesOutstationService)
                                            .ToListAsync();
                return mapper.Map<List<Ambulance>, List<AmbulanceModel>>(ambulance);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to Get Ambulance", ex);
                return null;
            }
        }
    }
}
