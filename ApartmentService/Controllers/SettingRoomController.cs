using ApartmentService.Business.InterfaceServices;
using ApartmentService.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingRoomController : ControllerBase
    {
        private readonly ISettingRoomService _settingRoomService;
        public SettingRoomController(ISettingRoomService settingRoomService)
        {
            _settingRoomService = settingRoomService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _settingRoomService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        //[Route("Insert")]
        public async Task<IActionResult> Insert(List<SettingRoom> room)
        {
            return Ok(await _settingRoomService.Add(room));
        }

        [HttpPut]
        //[Route("Update")]
        public async Task<IActionResult> Update(SettingRoom room)
        {
            return Ok(await _settingRoomService.Update(room));
        }

        [HttpDelete]
        //[Route("Delete")]
        public async Task<IActionResult> Delete(SettingRoom room)
        {
            return Ok(await _settingRoomService.Delete(room));
        }
    }
}
