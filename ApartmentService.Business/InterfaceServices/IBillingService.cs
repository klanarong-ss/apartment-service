using ApartmentService.DataAccess.ComplexModels;
using ApartmentService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentService.Business.InterfaceServices
{
    public interface IBillingService
    {
        Task<IEnumerable<BillingDetail>> GetAllBilling(DateTime currentDate);
        Task<String> GenerateBillingCurrentMonth();
        Task<String> UpdateBilling(Billing billing);
        Task<String> UpdatePaid(List<BillingDetail> billingList);
    }
}
