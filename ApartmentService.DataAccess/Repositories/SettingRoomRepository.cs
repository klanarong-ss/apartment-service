using ApartmentService.DataAccess.InterfaceRepositories;
using ApartmentService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentService.DataAccess.Repositories
{
    internal class SettingRoomRepository : RepositoryBase<SettingRoom>, ISettingRoomRepository
    {
        public SettingRoomRepository(DataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
