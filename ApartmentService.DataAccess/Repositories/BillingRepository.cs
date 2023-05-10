using ApartmentService.DataAccess.ComplexModels;
using ApartmentService.DataAccess.InterfaceRepositories;
using ApartmentService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentService.DataAccess.Repositories
{
    internal class BillingRepository : RepositoryBase<Billing>, IBillingRepository
    {
        private readonly DataContext _dataContext;
        public BillingRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<BillingDetail>> GetBillingsByMonthly(DateTime currentDate)
        {
            var billingDetail = await (from a in _dataContext.Billings
                                       join c in _dataContext.SettingRooms
                                          on a.RoomId equals c.RoomId
                                       where a.Monthly == currentDate.Month && a.Yearly == currentDate.Year
                                       select new BillingDetail
                                       {
                                           BillingId = a.BillingId,
                                           Floor = c.Floor,
                                           RoomNumber = c.RoomNumber ?? "",
                                           TotalElectricityBill = (c.ElectricityBill * a.ElectricityCost ?? 1),
                                           TotalWaterBill = (c.WaterBill * a.WaterCost ?? 1),
                                           Rent = c.Rent,
                                           Paid = a.Paid,
                                           TotalRent = ((c.ElectricityBill * a.ElectricityCost ?? 1) + (c.WaterBill * a.WaterCost ?? 1) + c.Rent)
                                       }).ToListAsync();

            return billingDetail;
        }
    }
}
