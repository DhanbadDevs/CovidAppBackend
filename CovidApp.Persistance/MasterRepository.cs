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
    public class MasterRepository : IMasterRepository
    {
        readonly CovidAppDbContext dbContext;
        readonly ILogger<MasterRepository> logger;
        readonly IMapper mapper;

        public MasterRepository(CovidAppDbContext dbContext, ILogger<MasterRepository> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<CityModel> AddCity(CityModel cityModel)
        {
            /*var city = new City
            {
                CityName = cityModel.CityName,
                UpdatedOn = cityModel.UpdatedOn,
                CreatedOn = cityModel.CreatedOn,
                State=cityModel.State
            };*/
            var city = mapper.Map<CityModel, City>(cityModel);
            await dbContext.Cities.AddAsync(city);
            await dbContext.SaveChangesAsync();
            return (cityModel);
        }

        public async Task<LocationModel> AddLocation(LocationModel locationModel)
        {
            try
            {
                var location = mapper.Map<LocationModel, Location>(locationModel);
                await dbContext.Locations.AddAsync(location);
                await dbContext.SaveChangesAsync();
                return locationModel;
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Add Location", ex);
                return null;
            }
        }

        public async Task<IList<CityModel>> GetCities()
        {
            try
            {
                var result=await dbContext.Cities.OrderByDescending(x => x.UpdatedOn)
                                            .ToListAsync();
                return mapper.Map<List<City>,List<CityModel>>(result);

            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Get Vaccine", ex);
                return null;
            }
        }

        public async Task<IList<LocationModel>> GetLocations(long cityId)
        {
            var result = await dbContext.Locations.Where(x => x.CityId == cityId)
                                                   .OrderByDescending(x => x.Votes)
                                                   .ThenBy(x => x.LocationName)
                                                   .ToListAsync();

            return mapper.Map<List<Location>, List<LocationModel>>(result);
        }
    }
}
