using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Model;

namespace WebApplication1.Entities
{
    public class RoomTypeConfiguration: IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasData(
                new RoomType
                {
                    Id = 1,
                    Name = "Single Room"
                },
                 new RoomType
                 {  
                     Id=2,
                     Name = "Double  Room"
                 },
                  new RoomType
                  {   
                      Id=3,
                      Name = "Deluxe  Room"
                  }
                ); ;
        }
    }
}
