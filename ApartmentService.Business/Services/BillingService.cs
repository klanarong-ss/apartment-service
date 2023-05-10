using ApartmentService.Business.Common;
using ApartmentService.Business.InterfaceServices;
using ApartmentService.DataAccess.ComplexModels;
using ApartmentService.DataAccess.InterfaceRepositories;
using ApartmentService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentService.Business.Services
{
    public class BillingService: IBillingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BillingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GenerateBillingCurrentMonth()
        {
            var currentDateTime = DateTime.Now;
            int month = currentDateTime.Month;
            int year = currentDateTime.Year;

            bool checkDuplicate = await _unitOfWork.Billing.Any(x => x.Monthly == month && x.Yearly == year);

            if (!checkDuplicate)
            {
                var roomList = await _unitOfWork.SettingRoom.FindAll().ToListAsync();

                if (roomList.Count > 0)
                {
                    var billingList = new List<Billing>();
                    foreach (var room in roomList)
                    {
                        var tmpBilling = new Billing
                        {
                            BillingId = Guid.NewGuid().ToString(),
                            RoomId = room.RoomId,
                            ElectricityCost = room.ElectricityBill,
                            WaterCost = room.WaterBill,
                            Monthly = month,
                            Yearly = year,
                            Paid = false,
                            IsActive = true,
                            CreatedDate = DateTime.Now,
                            CreatedBy = ""
                        };
                        billingList.Add(tmpBilling);
                    }

                    _ = await _unitOfWork.Billing.AddRange(billingList);
                    return ResponseMessage.GenerateBillingSuccess;
                }
                else
                {
                    throw new Exception(ResponseMessage.NotFoundRoomSetting);
                }
            }
            else
            {
                throw new Exception(ResponseMessage.GenerateBillingAlready);
            }
        }

        public async Task<IEnumerable<BillingDetail>> GetAllBilling(DateTime currentDate)
        {
            var data = await _unitOfWork.Billing.GetBillingsByMonthly(currentDate);
            return data;
        }
        
        public async Task<string> UpdateBilling(Billing billing)
        {
            billing.UpdatedDate = DateTime.Now;
            billing.UpdatedBy = "";

            _unitOfWork.Billing.Update(billing);

            return ResponseMessage.UpdateSuccess;
        }

        public async Task<string> UpdatePaid(List<BillingDetail> billingList)
        {
            var billing = new List<Billing>();
            foreach (var item in billingList)
            {
                var tmp = await _unitOfWork.Billing.FindByCondition(x => x.BillingId == item.BillingId).FirstOrDefaultAsync();

                tmp.Paid = true;
                tmp.UpdatedDate = DateTime.Now;
                tmp.UpdatedBy = "";

                billing.Add(tmp);
            }

            var  _ = _unitOfWork.Billing.UpdateRange(billing);

            return ResponseMessage.UpdateSuccess;
        }

    }
}
