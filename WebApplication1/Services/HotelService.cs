using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Model;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class HotelService : IHotelService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<IHotelService> _logger;
        public HotelService(ApplicationDbContext db, IMapper mapper, ILogger<IHotelService> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<Hotel>?> GetAll()
        {
            try
            {
                var hotels = await _db.Hotels.ToListAsync();
                return hotels;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Hotel?> GetById(int id)
        {
            try
            {
                var hotel = await _db.Hotels.Include(h => h.Rooms).ThenInclude(r => r.Images).FirstOrDefaultAsync(h => h.Id == id);
                return hotel;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Hotel>?> GetByCity(string city)
        {
            try
            {
                var hotels = await _db.Hotels.Where(h => h.City == city).ToListAsync();
                return hotels;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<string>?> GetCities()
        {
            try
            {
               // var hotels = await _db.Hotels.FromSqlRaw("select distinct city from hotels").ToListAsync();
               var hotels= await _db.Hotels.Select(h => h.City).Distinct().ToListAsync();
                return hotels;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AddHotel(HotelAddDto hotel)
        {
            try
            {   
                var newHotel= _mapper.Map<Hotel>(hotel);
                await _db.Hotels.AddAsync(newHotel);
               var result = await _db.SaveChangesAsync();
                return result == 1;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RemoveHotel(int id)
        {
            try
            {
                var hotel=await _db.Hotels.FindAsync(id);
                if(hotel == null)
                {
                    return true;
                }
                _db.Hotels.Remove(hotel);
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
