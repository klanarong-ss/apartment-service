using ApartmentService.Business.Common;
using ApartmentService.Business.InterfaceServices;
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
    public class SettingRoomService : ISettingRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingRoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(List<SettingRoom> roomList)
        {
            roomList.Select(x =>
            {
                x.CreatedDate = DateTime.Now;
                x.CreatedBy = "";
                x.IsActive = true;
                x.RoomId = Guid.NewGuid().ToString();
                return x;
            }).ToList();

            var t = await _unitOfWork.SettingRoom.AddRange(roomList);

            return ResponseMessage.InsertSuccess;
        }

        public async Task<string> Delete(SettingRoom room)
        {
            room.IsActive = false;
            room.UpdatedDate = DateTime.Now;
            room.UpdatedBy = "";
            _unitOfWork.SettingRoom.Update(room);
            return ResponseMessage.DeleteSuccess;
        }

        public async Task<IEnumerable<SettingRoom>> GetAll()
        {
            var data = await _unitOfWork.SettingRoom.FindByCondition(x=>x.IsActive == true).OrderBy(c=>c.Floor).ToListAsync();
            return data;
        }

        public async Task<string> Update(SettingRoom room)
        {
            room.UpdatedDate = DateTime.Now;
            room.UpdatedBy = "";
            _unitOfWork.SettingRoom.Update(room);

            return ResponseMessage.UpdateSuccess;
        }
    }
}
