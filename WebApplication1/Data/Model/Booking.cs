namespace WebApplication1.Data.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool IsConfirmed { get; set; }   
      
        public int RoomId { get; set; }
        public Room Room  { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
