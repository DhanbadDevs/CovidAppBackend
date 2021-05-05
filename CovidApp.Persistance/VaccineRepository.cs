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

namespace CovidApp.Persistance
{
    public class VaccineRepository : IVaccineRepository
    {
        readonly CovidAppDbContext dbContext;
        readonly ILogger<VaccineRepository> logger;

        public VaccineRepository(CovidAppDbContext dbContext, ILogger<VaccineRepository> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        public async Task<VaccineModel> GetVaccine()
        {
            var vaccines = await dbContext.Vaccines.Where(x => x.IsAvailable == true).ToListAsync();
            return null;
        }
    }
}
