using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace API.Models
{
    public class CurrencyContext : DbContext
    {

        public string DBName { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbName = "/home/umut/src/Currencies.db";
            optionsBuilder.UseSqlite($"Filename={dbName}");
        }
    }
}