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
    public class VaccinationCentreRepository : IVaccinationCentreRepository
    {
        readonly CovidAppDbContext dbContext;
        readonly ILogger<VaccinationCentreRepository> logger;
        readonly IMapper mapper;

        public VaccinationCentreRepository(CovidAppDbContext dbContext, ILogger<VaccinationCentreRepository> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<VaccinationCentreModel> AddVaccinationCentre(VaccinationCentreModel vaccinationCentreModel)
        {
            try
            {
                var vaccinationCentre = mapper.Map<VaccinationCentreModel, VaccinationCentre>(vaccinationCentreModel);
                await dbContext.VaccinationCentres.AddAsync(vaccinationCentre);
                await dbContext.SaveChangesAsync();
                return vaccinationCentreModel;
            }
            catch (Exception ex)
            {
                logger.LogError("Faild to Add Vaccination Centre", ex);
                return null;
            }
        }

        public async Task<IList<VaccinationCentreModel>> GetVaccinationCentre(int cityId)
        {
            try
            {
                var results = await dbContext.VaccinationCentres
                                            .Where(x => x.CityId == cityId)
                                            .Include(x => x.Location)
                                            .OrderByDescending(x => x.IsAvailable)
                                            .ToListAsync();
                return mapper.Map<List<VaccinationCentre>, List<VaccinationCentreModel>>(results);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Get Vaccine", ex);
                return null;
            }
        }
    }
}
