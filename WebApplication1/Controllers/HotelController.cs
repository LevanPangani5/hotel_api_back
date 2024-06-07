using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using WebApplication1.Data.DTO;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                 var hotels=await  _hotelService.GetAll();
                    return Ok(hotels);
            }catch
            {
                //_logger.LogError(ex, $"something when wrong in the {nameof(Register)}");
                return Problem($"something when wrong in the {nameof(GetAll)}", statusCode: 500);
            }
        }

        [HttpGet("GetHotel/{id}")]
        public async Task<IActionResult> GetByCity(int id)
        {
            try
            {
                var hotels = await _hotelService.GetById(id);
                return Ok(hotels);
            }
            catch
            {
                //_logger.LogError(ex, $"something when wrong in the {nameof(Register)}");
                return Problem($"something when wrong in the {nameof(GetAll)}", statusCode: 500);
            }
        }

        [HttpGet("GetCities")]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                var cities = await _hotelService.GetCities();
                return Ok(cities);
            }
            catch
            {
                //_logger.LogError(ex, $"something when wrong in the {nameof(Register)}");
                return Problem($"something when wrong in the {nameof(GetAll)}", statusCode: 500);
            }
        }
       // [Authorize("Admin")]
        [HttpPost("AddHotel")]
        public async Task<IActionResult> AddHotel([FromBody] HotelAddDto hotel)
        {
            try
            {
                var cities = await _hotelService.AddHotel(hotel);

                return Ok(cities);
            }
            catch { 
                //_logger.LogError(ex, $"something when wrong in the {nameof(Register)}");
                return Problem($"something when wrong in the {nameof(GetAll)}", statusCode: 500);
            }
        }

        [HttpPost("RemoveHotel/{id}")]
        public async Task<IActionResult> RemoveHotel([FromRoute] int id)
        {
            try
            {
                var cities = await _hotelService.RemoveHotel(id);
                return Ok(cities);
            }
            catch 
            {
                //_logger.LogError(ex, $"something when wrong in the {nameof(Register)}");
                return Problem($"something when wrong in the {nameof(GetAll)}", statusCode: 500);
            }
        }


    }
}
