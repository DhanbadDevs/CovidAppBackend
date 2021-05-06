using CovidApp.Model;
using CovidApp.Persistance.API;
using Microsoft.Extensions.Logging;
using CovidApp.Persistance.CovidAppContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using CovidApp.Persistance.Entities;

namespace CovidApp.Persistance
{
    public class VaccineRepository : IVaccineRepository
    {
       readonly CovidAppDbContext dbContext;
        readonly ILogger<VaccineRepository> logger;
        readonly IMapper mapper;

        public VaccineRepository(CovidAppDbContext dbContext, ILogger<VaccineRepository> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<IList<VaccineModel>> GetVaccine()
        {
            try
            {
                var results = await dbContext.VaccinationCentres
                                            .Include(x => x.Location)
                                            .OrderByDescending(x => x.IsAvailable)
                                            .ToListAsync();
                return mapper.Map<List<VaccinationCentre>, List<VaccineModel>>(results);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Get Vaccine", ex);
                return null;
            }
        }
    }
}
