using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Data.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool Available { get; set; }
        public int MaximumGuests { get; set; }

        public ICollection<Booking> BookedDates { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
