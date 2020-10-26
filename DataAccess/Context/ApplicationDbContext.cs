using DataAccess.Models;
using DataAccess.Seeder;
using Entities.Modules.Core;
using Entities.Modules.Lookups;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace DataAccess.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionDetail> AuctionDetails { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Trim> Trims { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>()
                .HasOne(auction => auction.AuctionDetail)
                .WithOne(auctionDetail => auctionDetail.Auction)
                .HasForeignKey<AuctionDetail>(auctionDetail => auctionDetail.AuctionId);

            // Seed data.
            DataSeeder seeder = new DataSeeder();

            List<Make> makes = seeder.GenerateCarMakes();
            modelBuilder.Entity<Make>().HasData(makes);

            List<Model> models = seeder.GenerateCarModels();
            modelBuilder.Entity<Model>().HasData(models);

            List<Trim> trims = seeder.GenerateCarTrims();
            modelBuilder.Entity<Trim>().HasData(trims);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                using (StreamReader reader = new StreamReader("appsettings.json"))
                {
                    string json = reader.ReadToEnd();
                    ApplicationSettingsModel settings = JsonConvert.DeserializeObject<ApplicationSettingsModel>(json);
                    optionsBuilder.UseSqlServer(settings.ApplicationSettings.ConnectionString);
                }
            }
        }
    }
}
