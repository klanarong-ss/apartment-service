using ApartmentService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentService.Business.InterfaceServices
{
    public interface ISettingRoomService
    {
        Task<IEnumerable<SettingRoom>> GetAll();
        Task<String> Add(List<SettingRoom> roomList);
        Task<String> Delete(SettingRoom room);
        Task<String> Update(SettingRoom room);
    }
}
