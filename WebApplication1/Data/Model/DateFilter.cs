namespace WebApplication1.Data.Model
{
    public class DateFilter
    {
        public DateTime CheckIn { get; set; } = DateTime.MinValue;
        public DateTime CheckOut { get; set; } = DateTime.MinValue;
    }
}
