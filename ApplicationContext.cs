using Microsoft.EntityFrameworkCore;

namespace HotelApp
{
	class ApplicationContext : DbContext
	{
		public DbSet<Room> Rooms => Set<Room>();
		public ApplicationContext() => Database.EnsureCreated();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=HotelApp.db");
		}
	}
}
