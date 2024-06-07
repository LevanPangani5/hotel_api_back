using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.Data.Model
{
    public class Error
    {
        public int  StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
