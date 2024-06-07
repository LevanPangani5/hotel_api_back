using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Model;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class BookingService : IBookingService
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingService> _logger;

        public BookingService(ApplicationDbContext db, IMapper mapper, ILogger<BookingService> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<Booking>?> GetAll(string userId, bool isAdmin)
        {     _logger.LogInformation("zzzzzzzzzzzzzzzzz");
            _logger.LogInformation(userId);
            _logger.LogInformation("fffffffffffff");
            try
            {
                if (!isAdmin)
                {
                    var bookedDates = await _db.BookedDates.Where(b => b.UserId == userId).ToListAsync();
                    _logger.LogInformation("dddddddddddd");
                    _logger.LogInformation(bookedDates.Count.ToString());
                    return bookedDates;
                }
                else
                {
                    var bookedDates = await _db.BookedDates.ToListAsync();
                    return bookedDates;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Add(string userId, BookingAddDto bookedDate)
        {
            try
            {
                var wrong = await _db.BookedDates
                           .Where(b => b.RoomId == bookedDate.RoomId)
                           .Where(b => b.CheckOut >= bookedDate.CheckOut && b.CheckIn <= bookedDate.CheckIn)
                           .Where(b => b.CheckOut >= bookedDate.CheckIn && b.CheckOut <= bookedDate.CheckOut)
                           .Where(b => b.CheckIn >= bookedDate.CheckIn && b.CheckIn <= bookedDate.CheckOut)
                           .FirstOrDefaultAsync();

                if (wrong is not null)
                {
                    return false;
                }

                var newBookedDate = _mapper.Map<Booking>(bookedDate);
                newBookedDate.UserId = userId;
                await _db.BookedDates.AddAsync(newBookedDate);

                var result = await _db.SaveChangesAsync();

                return result == 1;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var booking = await _db.BookedDates.FindAsync(id);
                if (booking is null)
                    return true;

                _db.BookedDates.Remove(booking);
                var result = await _db.SaveChangesAsync();
                return result == 1;
            }
            catch
            {
                return false;
            }
        }
    }
}
