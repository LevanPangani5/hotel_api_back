using WebApplication1.Data.Model;

namespace WebApplication1.Data.DTO
{
    public class RoomAddDto
    {
        public string Name { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public decimal PricePerNight { get; set; }
        public bool Available { get; set; }
        public int MaximumGuests { get; set; }
    }
}
