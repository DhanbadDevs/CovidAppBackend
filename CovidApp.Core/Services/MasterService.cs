using CovidApp.Core.API.Services;
using CovidApp.Model;
using CovidApp.Persistance.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Services
{
    public class MasterService : IMasterService
    {
        readonly IMasterRepository masterRepository;

        public MasterService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public async Task<CityModel> AddCity(CityModel cityModel)
        {
            cityModel.CreatedOn = DateTime.UtcNow;
            cityModel.UpdatedOn = DateTime.UtcNow;
            return await masterRepository.AddCity(cityModel);
        }

        public async Task<FeedbackModel> AddFeedback(FeedbackModel feedbackModel)
        {
            feedbackModel.CreatedOn = DateTime.UtcNow;
            feedbackModel.UpdatedOn = DateTime.UtcNow;
            return await masterRepository.AddFeedback(feedbackModel);
        }

        public async Task<HelplineModel> AddHelpline(HelplineModel helplineModel)
        {
            helplineModel.CreatedOn = DateTime.UtcNow;
            helplineModel.UpdatedOn = DateTime.UtcNow;
            return await masterRepository.AddHelpline(helplineModel);
        }

        public async Task<LocationModel> AddLocation(LocationModel locationModel)
        {
            locationModel.CreatedOn = DateTime.UtcNow;
            locationModel.UpdatedOn = DateTime.UtcNow;
            return await masterRepository.AddLocation(locationModel);
        }

        public async Task<VolunteerModel> AddVolunteer(VolunteerModel volunteerModel)
        {
            volunteerModel.CreatedOn = DateTime.UtcNow;
            volunteerModel.UpdatedOn = DateTime.UtcNow;
            return await masterRepository.AddVolunteer(volunteerModel);
        }

        public async Task<IList<CityModel>> GetCities()
        {
            return await masterRepository.GetCities();    
        }

        public async Task<IList<FeedbackModel>> GetFeedback(long cityId)
        {
            return await masterRepository.GetFeedback(cityId);
        }

        public async Task<IList<HelplineModel>> GetHelpline(long cityId)
        {
            return await masterRepository.GetHelpline(cityId);
        }

        public async Task<IList<LocationModel>> GetLocations(long cityId, long locationTypeId)
        {
            return await masterRepository.GetLocations(cityId, locationTypeId);
        }

        public async Task<IList<VolunteerModel>> GetVolunteer()
        {
            return await masterRepository.GetVolunteer();
        }
    }
}
