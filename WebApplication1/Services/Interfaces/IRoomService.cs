using WebApplication1.Data.DTO;
using WebApplication1.Data.Model;

namespace WebApplication1.Services.Interfaces
{
    public interface IRoomService
    {
        Task<List<Room>?> GetAll();
        Task<Room?> GetById(int id);
        Task<List<RoomTypeGetDto>?> GetRoomTypes();
        Task<List<Room>?> GetFiltered(RoomFilter filter);
        Task<List<Room>?> GetFiltered(DateFilter filter);
        Task<bool> AddRoom(RoomAddDto room);
        Task<bool> DeleteRoom(int id);
    }
}