using ApartmentService.DataAccess.InterfaceRepositories;
using ApartmentService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentService.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext;
        private ISettingRoomRepository _settingRoomRepository;
        private IBillingRepository _billingRepository;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ISettingRoomRepository SettingRoom
        {
            get
            {
                if (_settingRoomRepository == null)
                {
                    _settingRoomRepository = new SettingRoomRepository(_dataContext);
                }
                return _settingRoomRepository;
            }
        }
        public IBillingRepository Billing
        {
            get
            {
                if (_billingRepository == null)
                {
                    _billingRepository = new BillingRepository(_dataContext);
                }
                return _billingRepository;
            }
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public void Save()
        {
            _dataContext.SaveChangesAsync();
        }
    }
}
