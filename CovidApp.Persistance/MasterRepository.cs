using AutoMapper;
using CovidApp.Model;
using CovidApp.Persistance.API;
using CovidApp.Persistance.CovidAppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Persistance
{
    public class MasterRepository : IMasterRepository
    {
        readonly CovidAppDbContext dbContext;
        readonly ILogger<MasterRepository> logger;
        readonly IMapper mapper;
        public Task<Tuple<CityModel>> AddCity()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<CityModel>> GetCities()
        {
            try
            {
                var result=await dbContext.Cities.OrderByDescending(x => x.UpdatedOn)
                                            .ToListAsync();


            }
            catch(Exception e)
            {
                logger.LogError("Failed to Get Vaccine", ex);
                return null;
            }
        }
    }
}
