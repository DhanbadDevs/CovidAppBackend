using CovidApp.Common.Constants;
using CovidApp.Core.API.Delegates;
using CovidApp.Core.API.Services;
using CovidApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Core.Delegates
{
    public class MasterDelegate : IMasterDelegate
    {
        readonly IMasterService masterService;
        public MasterDelegate(IMasterService masterService)
        {
            this.masterService = masterService;
        }
        public async Task<ServerResponse<CityModel>> AddCity(CityModel cityModel)
        {
            if (cityModel == null || String.IsNullOrWhiteSpace(cityModel.CityName) || String.IsNullOrWhiteSpace(cityModel.State))
                return new ServerResponse<CityModel> { Message = Messages.InvalidInput };

            var city = await masterService.AddCity(cityModel);

            if (city == null)
                return new ServerResponse<CityModel> { Message = Messages.ErrorOccured };
            return new ServerResponse<CityModel> { Message = Messages.OperationSuccessful, Payload = city };
        }

        public async Task<ServerResponse<FeedbackModel>> AddFeedback(FeedbackModel feedbackModel)
        {
            if (feedbackModel == null ||  feedbackModel.CityId == 0)
                return new ServerResponse<FeedbackModel> { Message = Messages.InvalidInput };

            var result = await masterService.AddFeedback(feedbackModel);

            if (result == null)
                return new ServerResponse<FeedbackModel> { Message = Messages.ErrorOccured };

            return new ServerResponse<FeedbackModel> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<HelplineModel>> AddHelpline(HelplineModel helplineModel)
        {
            if (helplineModel == null || String.IsNullOrWhiteSpace(helplineModel.HelplineName) 
                || (String.IsNullOrWhiteSpace(helplineModel.Phone) && String.IsNullOrWhiteSpace(helplineModel.Link)))
                return new ServerResponse<HelplineModel> { Message = Messages.InvalidInput };

            var helpline = await masterService.AddHelpline(helplineModel);

            if (helpline == null)
                return new ServerResponse<HelplineModel> { Message = Messages.ErrorOccured };
            return new ServerResponse<HelplineModel> { Message = Messages.OperationSuccessful, Payload = helpline };
        }

        public async Task<ServerResponse<LocationModel>> AddLocation(LocationModel locationModel)
        {
            if (locationModel == null || String.IsNullOrWhiteSpace(locationModel.LocationName) || String.IsNullOrWhiteSpace(locationModel.Address)
                    || locationModel.CityId == 0 || locationModel.LocationTypeId == 0)
                return new ServerResponse<LocationModel> { Message =  Messages.InvalidInput };

            var result = await masterService.AddLocation(locationModel);

            if (result == null)
                return new ServerResponse<LocationModel> { Message = Messages.ErrorOccured };

            return new ServerResponse<LocationModel> { Message = Messages.OperationSuccessful, Payload = result };
            
        }

        public async Task<ServerResponse<VolunteerModel>> AddVolunteer(VolunteerModel volunteerModel)
        {
            if (volunteerModel == null || String.IsNullOrWhiteSpace(volunteerModel.VolunteerName))
                return new ServerResponse<VolunteerModel> { Message = Messages.InvalidInput };

            var result = await masterService.AddVolunteer(volunteerModel);

            if (result == null)
                return new ServerResponse<VolunteerModel> { Message = Messages.ErrorOccured };

            return new ServerResponse<VolunteerModel> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<IList<CityModel>>> GetCities()
        {
            IList<CityModel> result = await masterService.GetCities();
            if (result == null)
                return new ServerResponse<IList<CityModel>> { Message = Messages.ErrorOccured };
            else if (!result.Any())
                return new ServerResponse<IList<CityModel>> { Message = Messages.NoCityFound };
            else
                return new ServerResponse<IList<CityModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<IList<FeedbackModel>>> GetFeedback(long cityId)
        {
            IList<FeedbackModel> result = await masterService.GetFeedback(cityId);
            if (result == null)
                return new ServerResponse<IList<FeedbackModel>> { Message = Messages.ErrorOccured };
            else if (!result.Any())
                return new ServerResponse<IList<FeedbackModel>> { Message = Messages.NoFeedbacksFound };
            else
                return new ServerResponse<IList<FeedbackModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<IList<HelplineModel>>> GetHelpline(long cityId)
        {
            var result = await masterService.GetHelpline(cityId);
            if (result == null)
                return new ServerResponse<IList<HelplineModel>> { Message = Messages.ErrorOccured };
            else if (!result.Any())
                return new ServerResponse<IList<HelplineModel>> { Message = Messages.NoHelplinesFound };
            else
                return new ServerResponse<IList<HelplineModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<IList<LocationModel>>> GetLocations(long cityId, long locationTypeId)
        {
            var result = await masterService.GetLocations(cityId, locationTypeId);
            if (result == null)
                return new ServerResponse<IList<LocationModel>> { Message = Messages.ErrorOccured };
            else if (!result.Any())
                return new ServerResponse<IList<LocationModel>> { Message = Messages.NoLocationFound };
            else
                return new ServerResponse<IList<LocationModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }

        public async Task<ServerResponse<IList<VolunteerModel>>> GetVolunteer()
        {
            var result = await masterService.GetVolunteer();
            if (result == null)
                return new ServerResponse<IList<VolunteerModel>> { Message = Messages.ErrorOccured };
            else if (!result.Any())
                return new ServerResponse<IList<VolunteerModel>> { Message = Messages.NoVolunteersFound };
            else
                return new ServerResponse<IList<VolunteerModel>> { Message = Messages.OperationSuccessful, Payload = result };
        }
    }
}
