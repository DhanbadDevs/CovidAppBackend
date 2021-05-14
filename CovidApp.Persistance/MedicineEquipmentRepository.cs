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
    public class MedicineEquipmentRepository : IMedicineEquipmentRepository
    {
        readonly CovidAppDbContext dbContext;
        readonly ILogger<MedicineEquipmentRepository> logger;
        readonly IMapper mapper;

        public MedicineEquipmentRepository(CovidAppDbContext dbContext, ILogger<MedicineEquipmentRepository> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<MedicineEquipmentModel> AddMedicineEquipmentShop(MedicineEquipmentModel medicineEquipmentModel)
        {
            try
            {
                var medicineEquipmentShop = mapper.Map<MedicineEquipmentModel, MedicineEquipment>(medicineEquipmentModel);
                await dbContext.MedicineEquipments.AddAsync(medicineEquipmentShop);
                await dbContext.SaveChangesAsync();
                return mapper.Map<MedicineEquipment, MedicineEquipmentModel>(medicineEquipmentShop);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to Add Medicine/Equipment Shop", ex);
                return null;
            }
        }

        public async Task<IList<MedicineEquipmentModel>> GetMedicineEquipmentShop(int cityId, int medicineEquippmentId)
        {
            try
            {
                var medicineEquipmentShops = await dbContext.MedicineEquipments
                                            .Where(x => x.CityId == cityId  && x.MedicineEquipmentId == medicineEquippmentId)
                                            .Include(x => x.Location)
                                            .Include(x =>x.MedicineEquipmentNavigation)
                                            .ToListAsync();
                medicineEquipmentShops = medicineEquipmentShops.GroupBy(x => x.LocationId)
                                            .Select(x => x.OrderByDescending(y => y.UpdatedOn).FirstOrDefault())
                                            .OrderByDescending(x => x.IsVerified)
                                            .ThenByDescending(x => x.Stock)
                                            .ThenByDescending(x => x.Votes)
                                            .ToList();


                return mapper.Map<List<MedicineEquipment>, List<MedicineEquipmentModel>>(medicineEquipmentShops);
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to Get Medicine/Equipment Shop", ex);
                return null;
            }
        }

        public async Task<IList<MedicineEquipmentMasterModel>> GetAllMedicines()
        {
            try
            {
                var medicinesEquipment = await dbContext.MedicineEquipmentMasters
                                                        .OrderBy(x => x.MedicineEquipmentName)
                                                        .ToListAsync();
                return mapper.Map<List<MedicineEquipmentMaster>, List<MedicineEquipmentMasterModel>>(medicinesEquipment);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Get Medicines/Equipments ", ex);
                return null;
            }
        }

        public async Task<MedicineEquipmentMasterModel> AddMedicineEquipment(MedicineEquipmentMasterModel medicineEquipmentMasterModel)
        {
            try
            {
                var medicineEquipment = mapper.Map<MedicineEquipmentMasterModel, MedicineEquipmentMaster>(medicineEquipmentMasterModel);
                await dbContext.MedicineEquipmentMasters.AddAsync(medicineEquipment);
                await dbContext.SaveChangesAsync();
                return mapper.Map<MedicineEquipmentMaster, MedicineEquipmentMasterModel>(medicineEquipment);
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Add Medicine/Equipment", ex);
                return null;
            }
        }
    }
}
