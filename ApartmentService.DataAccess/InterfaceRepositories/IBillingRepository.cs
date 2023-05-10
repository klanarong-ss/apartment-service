using ApartmentService.DataAccess.ComplexModels;
using ApartmentService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentService.DataAccess.InterfaceRepositories
{
    public interface IBillingRepository : IRepositoryBase<Billing>
    {
        Task<IEnumerable<BillingDetail>> GetBillingsByMonthly(DateTime currentDate);
    }
}
