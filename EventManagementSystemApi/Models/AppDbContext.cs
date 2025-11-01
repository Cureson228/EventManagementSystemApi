using Microsoft.EntityFrameworkCore;

namespace EventManagementSystemApi.Models
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        DbSet<Event> Events { get; set; }

        DbSet<Participant> Participants { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: _configuration.GetConnectionString("AppDbConnection"));
        }


    }
}
