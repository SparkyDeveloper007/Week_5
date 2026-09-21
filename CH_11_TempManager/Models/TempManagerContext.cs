using Microsoft.EntityFrameworkCore;

namespace CH_11_TempManager.Models
{
    public class TempManagerContext : DbContext
    {
        public TempManagerContext(DbContextOptions<TempManagerContext> options)
            : base(options)
        { }

        public DbSet<Temp> Temps { get; set; } = null!;
    }
}
