using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using samuraiApp.Domain;

namespace samuraiApp.Data
{
    public class SamuraiContext:DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SamuraiAppData"
                ,options=> options.MaxBatchSize(100))
                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name}, 
                LogLevel.Information)
                .EnableSensitiveDataLogging();
            //base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            
        {
            modelBuilder.Entity<Samurai>()
                .HasMany(s => s.Battles)
                .WithMany(b => b.Samurais)
                .UsingEntity<BattleSamurai>
                  (bs => bs.HasOne<Battle>().WithMany(),
                   bs => bs.HasOne<Samurai>().WithMany())
                  .Property(bs => bs.DateJoined)
                  .HasDefaultValueSql("getdate()");

        }


    }
}