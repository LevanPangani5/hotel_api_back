namespace WebApplication1.Data.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
