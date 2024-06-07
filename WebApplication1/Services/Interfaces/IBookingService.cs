using WebApplication1.Data.DTO;
using WebApplication1.Data.Model;

namespace WebApplication1.Services.Interfaces
{
    public interface IBookingService
    {
        Task<bool> Add(string userId, BookingAddDto bookedDate);
        Task<bool> Delete(int id);
        Task<List<Booking>?> GetAll(string userId, bool isAdmin);
    }
}