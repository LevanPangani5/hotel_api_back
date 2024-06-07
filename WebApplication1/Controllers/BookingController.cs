using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.DTO;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookedService)
        {
            _bookingService = bookedService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst("Id")?.Value;
            var isAdminClaim = User.FindFirst("IsAdmin")?.Value;
            var isAdmin = isAdminClaim != null && bool.Parse(isAdminClaim);

            return Ok(await _bookingService.GetAll(userId!,isAdmin));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BookingAddDto booking)
        {
            var userId = User.FindFirst("Id")?.Value;
            return Created(nameof(Add), await _bookingService.Add(userId!,booking));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookingService.Delete(id);

            return result ? NoContent() : Problem($"error occured during deleting on {nameof(Delete)}",statusCode:500);
        }
    }
}
