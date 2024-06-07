namespace WebApplication1.Data.Model
{
    public class RoomFilter
    {
        public int RoomTypeId { get; set; } = 0;
        public decimal PriceFrom { get; set; } = 0;
        public decimal PriceTo { get; set; } = 0;
        public int MaximumGuests { get; set; } = 0;
        public DateTime? CheckIn { get; set; } = null;
        public DateTime? CheckOut { get; set; } = null;
    }
}
