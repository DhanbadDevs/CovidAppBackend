using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.API.Services
{
    public interface IMasterService
    {
        Task<IList<CityModel>> GetCities();
        Task<CityModel> AddCity(CityModel cityModel);
        Task<IList<LocationModel>> GetLocations(long cityId, long locationTypeId);
        Task<LocationModel> AddLocation(LocationModel locationModel);
        Task<IList<HelplineModel>> GetHelpline(long cityId);
        Task<HelplineModel> AddHelpline(HelplineModel helplineModel);
        Task<IList<FeedbackModel>> GetFeedback(long cityId);
        Task<FeedbackModel> AddFeedback(FeedbackModel feedbackModel);
        Task<IList<VolunteerModel>> GetVolunteer();
        Task<VolunteerModel> AddVolunteer(VolunteerModel volunteerModel);
    }
}
