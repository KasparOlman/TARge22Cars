using Microsoft.EntityFrameworkCore;
using TARge22Cars.Core.Domain;

namespace TARge22Cars.Data
{
    public class TARge22CarsContext : DbContext
    {
        public TARge22CarsContext(DbContextOptions<TARge22CarsContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
    }
}
