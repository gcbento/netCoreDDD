using JogosAPI.Domain.Entities;
using JogosAPI.Infra.Data.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace JogosAPI.Infra.Data.Context
{
    public class JogosAPIContext : DbContext
    {
        public JogosAPIContext(DbContextOptions<JogosAPIContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<WishGame> WishGames { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameConfig());
            modelBuilder.ApplyConfiguration(new AccountConfig());
            modelBuilder.ApplyConfiguration(new PurchaseConfig());
            modelBuilder.ApplyConfiguration(new SaleConfig());
            modelBuilder.ApplyConfiguration(new WishGameConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}