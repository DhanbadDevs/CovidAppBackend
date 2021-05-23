using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.API.Delegates
{
    public interface IMasterDelegate
    {
        Task<ServerResponse<IList<CityModel>>> GetCities();
        Task<ServerResponse<CityModel>> AddCity(CityModel cityModel);
        Task<ServerResponse<IList<LocationModel>>> GetLocations(long cityId, long locationTypeId);
        Task<ServerResponse<LocationModel>> AddLocation(LocationModel locationModel);
        Task<ServerResponse<IList<HelplineModel>>> GetHelpline(long cityId);
        Task<ServerResponse<HelplineModel>> AddHelpline(HelplineModel helplineModel);
        Task<ServerResponse<IList<FeedbackModel>>> GetFeedback(long cityId);
        Task<ServerResponse<FeedbackModel>> AddFeedback(FeedbackModel feedbackModel);
        Task<ServerResponse<IList<VolunteerModel>>> GetVolunteer();
        Task<ServerResponse<VolunteerModel>> AddVolunteer(VolunteerModel volunteerModel);
    }
}
