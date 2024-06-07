using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Model;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

       public DbSet<Lector> Lectors =>Set<Lector>();
       public DbSet<Student> Students =>Set<Student>();

       public DbSet<Hotel> Hotels =>Set<Hotel>();
       public DbSet<Room> Rooms =>Set<Room>();
       public DbSet<Booking> BookedDates =>Set<Booking>();
       public DbSet<Image> Images =>Set<Image>();
       public DbSet<RoomType> RoomTypes =>Set<RoomType>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.BookedDates)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Images)
                .WithOne(i => i.Room)
                .HasForeignKey(i => i.RoomId);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
        }   
    }
}
