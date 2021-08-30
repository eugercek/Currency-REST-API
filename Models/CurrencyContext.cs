using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace API.Models
{
    public class CurrencyContext : DbContext
    {

        public string DBName { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public CurrencyContext(DbContextOptions<CurrencyContext> options)
            : base(options)
        {
        }
    }
}