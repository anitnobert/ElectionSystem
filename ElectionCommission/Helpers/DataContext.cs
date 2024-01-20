using ElectionCommission.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ElectionCommission.Helpers
{
    public class DataContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("ECDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Voter>().ToTable("Voters");
            modelBuilder.Entity<Commissioner>().ToTable("Officials");
            modelBuilder.Entity<Party>().ToTable("Party");
            modelBuilder.Entity<StateDetail>().ToTable("States");
            modelBuilder.Entity<Constituency>().ToTable("Constituency");
        }

        public DbSet<Voter> Voters { get; set; }
        public DbSet<Commissioner> Officials { get; set; }

        public DbSet<Party> Parties { get; set; }
        public DbSet<StateDetail> States { get; set; }
        public DbSet<Constituency> Constituencies { get; set; }

    }

}