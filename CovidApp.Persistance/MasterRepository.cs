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
            try
            {
                var city = mapper.Map<CityModel, City>(cityModel);
                await dbContext.AddAsync(city);
                await dbContext.SaveChangesAsync();
                return cityModel;
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to Add City", ex);
                return null;
            }
        }

        public async Task<FeedbackModel> AddFeedback(FeedbackModel feedbackModel)
        {
            try
            {
                var feedback = mapper.Map<FeedbackModel, FeedBack>(feedbackModel);
                await dbContext.AddAsync(feedback);
                await dbContext.SaveChangesAsync();
                return mapper.Map<FeedBack, FeedbackModel>(feedback);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Add Feedback", ex);
                return null;
            }
        }

        public async Task<HelplineModel> AddHelpline(HelplineModel helplineModel)
        {
            try
            {
                var helpline = mapper.Map<HelplineModel, Helpline>(helplineModel);
                await dbContext.AddAsync(helpline);
                await dbContext.SaveChangesAsync();
                return mapper.Map<Helpline, HelplineModel>(helpline);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Add Helpline", ex);
                return null;
            }
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

        public async Task<VolunteerModel> AddVolunteer(VolunteerModel volunteerModel)
        {
            try
            {
                var volunteer = mapper.Map<VolunteerModel, Volunteer>(volunteerModel);
                await dbContext.AddAsync(volunteer);
                await dbContext.SaveChangesAsync();
                return mapper.Map<Volunteer, VolunteerModel>(volunteer);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to Add Volunteer", ex);
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
                logger.LogError("Failed to Get Cities", ex);
                return null;
            }
        }

        public async Task<IList<FeedbackModel>> GetFeedback(long cityId)
        {
            try
            {
                IQueryable<FeedBack> feedbacks = dbContext.FeedBacks;
                if (cityId != 0)
                    feedbacks.Where(x => x.CityId == cityId);
                var result = await feedbacks.OrderByDescending(x => x.UpdatedOn)
                                            .ToListAsync();

                return mapper.Map<List<FeedBack>, List<FeedbackModel>>(result);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Get Feedback", ex);
                return null;
            }
        }

        public async Task<IList<HelplineModel>> GetHelpline(long cityId)
        {
            var result = await dbContext.Helplines
                                           .Where(x => x.CityId == cityId || cityId == 0)
                                           .ToListAsync();
            return mapper.Map<List<Helpline>, List<HelplineModel>>(result);
        }

        //Needs Refactoring
        public async Task<IList<LocationModel>> GetLocations(long cityId, long locationTypeId)
        {
            try
            {
                List<Location> result;
                if (locationTypeId == 0)
                    result = await dbContext.Locations.Where(x => x.CityId == cityId)
                                                        .OrderByDescending(x => x.Votes)
                                                        .ThenBy(x => x.LocationName)
                                                        .ToListAsync();
                else
                    result = await dbContext.Locations.Where(x => x.CityId == cityId && x.LocationTypeId == locationTypeId)
                                                       .OrderByDescending(x => x.Votes)
                                                       .ThenBy(x => x.LocationName)
                                                       .ToListAsync();

                return mapper.Map<List<Location>, List<LocationModel>>(result);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Get Location", ex);
                return null;
            }
        }

        public async Task<IList<VolunteerModel>> GetVolunteer()
        {
            try
            {
                var result = await dbContext.Volunteers.OrderByDescending(x => x.UpdatedOn)
                                            .ToListAsync();

                return mapper.Map<List<Volunteer>, List<VolunteerModel>>(result);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to Get Volunteers", ex);
                return null;
            }
        }
    }
}
