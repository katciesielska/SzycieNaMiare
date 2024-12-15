using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SzycieNaMiare.Models;

namespace SzycieNaMiare.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SzycieNaMiare.Models.Garment> GarmentType { get; set; } = default!;
        public DbSet<SzycieNaMiare.Models.Session> Session { get; set; } = default!;
        public DbSet<SzycieNaMiare.Models.Measurement> Measurement { get; set; } = default!;
        public DbSet<SzycieNaMiare.Models.Order> Order { get; set; } = default!;
    }
}
