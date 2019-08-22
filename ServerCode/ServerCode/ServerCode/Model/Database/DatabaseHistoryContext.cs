using Microsoft.EntityFrameworkCore;
using ServerCode.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Database
{
    public class DatabaseHistoryContext : DbContext
    {
        public DbSet<Advertisement> AdvertisementsHistory { get; set; }
        public DbSet<UserAdvertisement> UserAdvertisementsHistory { get; set; }
        public DatabaseHistoryContext(DbContextOptions<DatabaseHistoryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserAdvertisement>().HasKey(ua => new { ua.UserId, ua.AdvertisementId });
            builder.Entity<UserAdvertisement>().HasOne(ua => ua.User).WithMany(u => u.AdvertisementsAccepted).HasForeignKey(ua => ua.UserId);
            builder.Entity<UserAdvertisement>().HasOne(ua => ua.Advertisement).WithMany(u => u.EagerMembers).HasForeignKey(ua => ua.AdvertisementId);
            builder.Entity<Advertisement>().HasOne(a => a.Localization).WithOne().HasForeignKey<Localization>(a => a.AdvertisementId);
            builder.Entity<Advertisement>().HasOne(a => a.Forum).WithOne().HasForeignKey<Forum>(a => a.AdvertisementId);
            //  builder.Entity<Advertisement>().Property(a => a.Id).ValueGeneratedNever();
        }
    }
}