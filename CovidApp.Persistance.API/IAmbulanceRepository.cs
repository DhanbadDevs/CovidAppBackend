using System.Collections.Generic;
using System.Threading.Tasks;
using CovidApp.Model;
namespace CovidApp.Persistance.API
{
    public interface IAmbulanceRepository
    {
        Task<IList<AmbulanceModel>> GetAmbulances();
    }
}
