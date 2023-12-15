using Microsoft.EntityFrameworkCore;
using PousadaVidaPlena.Models;

namespace PousadaVidaPlena.Data
{
    public class PousadaContext : DbContext
    {
        public PousadaContext(DbContextOptions<PousadaContext> options) : base(options) { }

        public DbSet<Room> Room { get; set; } = default!;
    }
}
