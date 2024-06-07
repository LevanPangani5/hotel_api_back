using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Model;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomService.GetAll();

            if (rooms != null)
            {
                return Ok(rooms);
            }

            return Problem($"problem occured on {nameof(GetAll)}", statusCode: 500);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await _roomService.GetById(id);
            return room != null ? Ok(room) : Problem($"Problem occurred in {nameof(GetAll)}", statusCode: 500);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomTypes()
        {
            var roomTypes = await _roomService.GetRoomTypes();

            return roomTypes != null ? Ok(roomTypes) : Problem($"Problem occurred in {nameof(GetAll)}", statusCode: 500);
        }

        [HttpPost]
        public async Task<IActionResult> GetFiltered([FromBody]RoomFilter filter)
        {
            return Ok( await _roomService.GetFiltered(filter));
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableRooms([FromQuery] DateFilter filter)
        {
            return Created(nameof(GetRoom), await _roomService.GetFiltered(filter));
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoomAddDto room)
        {
            return Created(nameof(GetRoom), await _roomService.AddRoom(room));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roomService.DeleteRoom(id);
            return result ? NoContent() : Problem($"something when wrong in the {nameof(Delete)}", statusCode: 500); ;
        }
    }

}
