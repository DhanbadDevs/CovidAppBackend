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
    public class DoctorRepository : IDoctorRepository
    {
        readonly CovidAppDbContext dbContext;
        readonly ILogger<DoctorRepository> logger;
        readonly IMapper mapper;

        public DoctorRepository(CovidAppDbContext dbContext, ILogger<DoctorRepository> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<DoctorModel> AddDoctor(DoctorModel doctorModel)
        {
            try
            {
                var doctor = mapper.Map<DoctorModel, Doctor>(doctorModel);
                await dbContext.AddAsync(doctor);
                await dbContext.SaveChangesAsync();
                return mapper.Map<Doctor, DoctorModel>(doctor);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to Add Doctor", ex);
                return null;
            }
        }

        public async Task<IList<DoctorModel>> GetDoctors(int cityId)
        {
            try
            {
                var results = await dbContext.Doctors.Where(x => x.CityId == cityId)
                                                .OrderByDescending(x => x.IsVerified)
                                                .ThenByDescending(x => x.Votes)
                                                .ToListAsync();

                return mapper.Map<List<Doctor>, List<DoctorModel>>(results);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to Get Cities", ex);
                return null;
            }
        }
    }
}
