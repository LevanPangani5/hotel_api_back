using WebApplication1.Data.DTO;
using WebApplication1.Data.Model;

namespace WebApplication1.Services.Interfaces
{
    public interface IHotelService
    {
        Task<List<Hotel>?> GetAll();
        Task<List<Hotel>?> GetByCity(string city);
        Task<Hotel?> GetById(int id);
        Task<List<string>?> GetCities();
        Task<bool> AddHotel(HotelAddDto hotel);
        Task<bool> RemoveHotel(int hotel);
    }
}