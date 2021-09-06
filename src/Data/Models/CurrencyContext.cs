using Microsoft.EntityFrameworkCore;

namespace API.Data.Models
{
    public class CurrencyContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }

        public CurrencyContext(DbContextOptions<CurrencyContext> options)
            : base(options)
        {
        }
    }
}