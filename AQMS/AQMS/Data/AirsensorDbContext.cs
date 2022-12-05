using AQMS.Models;
using Microsoft.EntityFrameworkCore;

namespace AQMS.Data
{
    public class AirsensorDbContext : DbContext
    {
        
        public AirsensorDbContext(DbContextOptions<AirsensorDbContext> options) : base(options)
        {

        }
        public DbSet<Airsensor> Airsensors { get; set; }
    }
}

