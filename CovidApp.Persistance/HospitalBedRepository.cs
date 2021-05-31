using AutoMapper;
using CovidApp.Model;
using CovidApp.Persistance.API;
using CovidApp.Persistance.CovidAppContext;
using CovidApp.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Persistance
{
    public class HospitalBedRepository : IHospitalBedRepository
    {
        readonly CovidAppDbContext dbContext;
        readonly ILogger<HospitalBedRepository> logger;
        readonly IMapper mapper;

        public HospitalBedRepository(CovidAppDbContext dbContext, ILogger<HospitalBedRepository> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task AddOrUpdateHospitalBed(IList<HospitalBedModel> hospitalBedModel)
        {
            try
            {
                var hospitalBed = mapper.Map<IList<HospitalBedModel>, IList<HospitalBed>>(hospitalBedModel);
                foreach(var beds in hospitalBed)
                    await dbContext.HospitalBeds.AddAsync(beds);
                await dbContext.SaveChangesAsync();
                logger.LogInformation("Added Hospital Beds at " + DateTime.UtcNow);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Add Hospital Beds", ex);
            }
        }

        public async Task<IList<HospitalBedModel>> GetHospitalBeds(int cityId)
        {
            try
            {
                var hospitalBeds = await dbContext.HospitalBeds
                                            .Where(x => x.CityId == cityId)
                                            .Include(x => x.Location)
                                            .OrderByDescending(x => x.IsVerified)
                                            .ThenByDescending(x => x.Votes)
                                            .ToListAsync();

                return mapper.Map<List<HospitalBed>, List<HospitalBedModel>>(hospitalBeds);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Get Hospital Beds", ex);
                return null;
            }
        }
    }
}
