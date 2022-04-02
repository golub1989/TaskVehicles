using Microsoft.EntityFrameworkCore;
using VehicleProject.Models;

namespace VehicleProject.Context
{
    public class MVCContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MVCContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        public DbSet<VehicleMake> Vehicles { get; set; }
        public DbSet<VehicleModel> Models { get; set; }

    }
}
