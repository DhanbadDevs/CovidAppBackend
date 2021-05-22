using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Persistance.API
{
    public interface IMasterRepository
    {
        Task<IList<CityModel>> GetCities();
        Task<CityModel> AddCity(CityModel cityModel);
        Task<IList<LocationModel>> GetLocations(long cityId, long locationTypeId);
        Task<LocationModel> AddLocation(LocationModel locationModel);
        Task<IList<HelplineModel>> GetHelpline(long cityId);
        Task<HelplineModel> AddHelpline(HelplineModel helplineModel);
        Task<IList<FeedbackModel>> GetFeedback(long cityId);
        Task<FeedbackModel> AddFeedback(FeedbackModel feedbackModel);
        Task<IList<VolunteerModel>> GetVolunteer(long cityId);
        Task<VolunteerModel> AddVolunteer(VolunteerModel volunteerModel);
    }
}
