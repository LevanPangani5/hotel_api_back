using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Model;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<RoomService> _logger;
        private readonly IMapper _mapper;

        public RoomService(ApplicationDbContext db, ILogger<RoomService> logger, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<Room>?> GetAll()
        {
            try
            {
                var rooms = await _db.Rooms.Include(r=>r.Images).ToListAsync();
                return rooms;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Room?> GetById(int id)
        {
            try
            {
                var room = await _db.Rooms.Include(r => r.Images).Include(r=>r.Hotel).Include(r=>r.RoomType).FirstOrDefaultAsync(h => h.Id == id);
                return room;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<RoomTypeGetDto>?> GetRoomTypes()
        {
            try
            {
                var roomTypes = await _db.RoomTypes.ToListAsync();

                return _mapper.Map<List<RoomTypeGetDto>>(roomTypes); ;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Room>?> GetFiltered(RoomFilter filter)
        {
            try
            {
                var query = _db.Rooms.AsQueryable();

                if (filter.RoomTypeId > 0)
                {
                    query = query.Where(r => r.RoomTypeId == filter.RoomTypeId);
                }

                if (filter.PriceFrom > 0)
                {
                    query = query.Where(r => r.PricePerNight >= filter.PriceFrom);
                }

                if (filter.PriceTo > 0)
                {
                    query = query.Where(r => r.PricePerNight <= filter.PriceTo);
                }

                if (filter.MaximumGuests > 0)
                {
                    query = query.Where(r => r.MaximumGuests >= filter.MaximumGuests);
                }

                if (filter.CheckIn != null && filter.CheckOut != null)
                {
                    query = query.Where(r => !r.BookedDates.Any(bd =>
                    (filter.CheckOut >= bd.CheckIn && filter.CheckIn <= bd.CheckOut) ||
                    (filter.CheckIn <= bd.CheckIn && filter.CheckOut >= bd.CheckIn) ||
                    (filter.CheckIn <= bd.CheckIn && filter.CheckOut >= bd.CheckOut)));
                }
                return await query.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Room>?> GetFiltered(DateFilter filter)
        {
            var roomFilter = _mapper.Map<RoomFilter>(filter);
            return await GetFiltered(roomFilter);
        }

        public async Task<bool> AddRoom(RoomAddDto room)
        {
            try
            {
                var newRoom = _mapper.Map<Room>(room);
                await _db.Rooms.AddAsync(newRoom);
                int result = await _db.SaveChangesAsync();

                return result == 1;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteRoom(int id)
        {
            try
            {
                var room = await _db.Rooms.FindAsync(id);
                if (room == null)
                    return true;

                 _db.Rooms.Remove(room);

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
