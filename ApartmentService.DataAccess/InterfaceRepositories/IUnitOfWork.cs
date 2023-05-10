using ApartmentService.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentService.DataAccess.InterfaceRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ISettingRoomRepository SettingRoom { get; }
        IBillingRepository Billing  { get; }
        void Save();
    }
}
