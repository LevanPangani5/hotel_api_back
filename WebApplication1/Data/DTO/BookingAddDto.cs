using WebApplication1.Data.Model;

namespace WebApplication1.Data.DTO
{
    public class BookingAddDto
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool IsConfirmed { get; set; }
        public double totalPrice { get; set; }
        public int RoomId { get; set; }
    }
}
