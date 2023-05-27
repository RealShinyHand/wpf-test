using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using System.Data;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDBContext : DbContext
    {
        public SimpleTraderDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<User> Accounts { get; set; }
        public DbSet<User> AssetTransaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne((a) => a.Stock );
        }
    }
}