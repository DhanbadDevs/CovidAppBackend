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
    public class OxygenRepository : IOxygenRepository
    {
        readonly CovidAppDbContext dbContext;
        readonly ILogger<OxygenRepository> logger;
        readonly IMapper mapper;

        public OxygenRepository(CovidAppDbContext dbContext, ILogger<OxygenRepository> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<OxygenModel> AddOxygen(OxygenModel oxygenModel)
        {
            try
            {
                var oxygen = mapper.Map<OxygenModel, Oxygen>(oxygenModel);
                await dbContext.Oxygens.AddAsync(oxygen);
                await dbContext.SaveChangesAsync();
                return mapper.Map<Oxygen, OxygenModel>(oxygen);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to Add Oxygen", ex);
                return null;
            }
        }

        public async Task<IList<OxygenModel>> GetOxygens(int cityId)
        {
            try
            {
                var oxygen = await dbContext.Oxygens
                                            .Where(x=>x.CityId==cityId)
                                            .Include(x => x.Location)
                                            .ToListAsync();
                oxygen = oxygen.GroupBy(x => x.LocationId)
                                            .Select(x => x.OrderByDescending(y => y.UpdatedOn).FirstOrDefault())
                                            .OrderByDescending(x=>x.Stock)
                                            .ThenByDescending(x => x.IsVerified)
                                            .ThenByDescending(x => x.Votes)
                                            .ToList();


                return mapper.Map<List<Oxygen>, List<OxygenModel>>(oxygen);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to Get Oxygen", ex);
                return null;
            }
        }
    }
}
