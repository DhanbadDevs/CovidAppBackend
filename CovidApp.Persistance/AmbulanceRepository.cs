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
