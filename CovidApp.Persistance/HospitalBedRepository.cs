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

        public async Task<HospitalBedModel> AddOrUpdateHospitalBed(HospitalBedModel hospitalBedModel)
        {
            try
            {
                var hospitalBed = mapper.Map<HospitalBedModel, HospitalBed>(hospitalBedModel);
                await dbContext.HospitalBeds.AddAsync(hospitalBed);
                await dbContext.SaveChangesAsync();
                return mapper.Map<HospitalBed, HospitalBedModel>(hospitalBed);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Add Hospital Bed", ex);
                return null;
            }
        }

        public async Task<IList<HospitalBedModel>> GetHospitalBeds(string bedType)
        {
            try
            {
                var hospitalBeds = await dbContext.HospitalBeds
                                            .Where(x => x.BedType == bedType)
                                            .Include(x => x.Location)
                                            .ToListAsync();
                hospitalBeds = hospitalBeds.GroupBy(x => x.LocationId)
                                            .Select(x => x.OrderByDescending(y => y.UpdatedOn).FirstOrDefault())
                                            .OrderByDescending(x => x.IsVerified)
                                            .ThenByDescending(x => x.BedCount)
                                            .ThenByDescending(x => x.Votes)
                                            .ToList();


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
