using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Database
{
    public class DatabaseContext: IdentityDbContext
    {
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<SportName> SportNames { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<UserAdvertisement> UserAdvertisements { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<AdvertisementArch> AdvertisementArches { get; set; }
   

        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            DbInitializer.Seed(builder);
            base.OnModelCreating(builder);
            builder.Entity<User>().HasMany(c => c.Achievements).WithOne().HasForeignKey(c => c.UserId);
            builder.Entity<User>().HasMany(c => c.PrefferedSports).WithOne().HasForeignKey(c => c.UserId);
            builder.Entity<Chat>().HasMany(c => c.Messages).WithOne().HasForeignKey(c => c.ChatId);
            builder.Entity<Event>().HasMany(c => c.Sponsors).WithOne().HasForeignKey(c => c.EventId);
            builder.Entity<UserAdvertisement>().HasKey(ua => new { ua.UserId, ua.AdvertisementId });
            builder.Entity<UserAdvertisement>().HasOne(ua => ua.User).WithMany(u => u.AdvertisementsAccepted).HasForeignKey(ua => ua.UserId);
            builder.Entity<UserAdvertisement>().HasOne(ua => ua.Advertisement).WithMany(u => u.EagerMembers).HasForeignKey(ua => ua.AdvertisementId);
            builder.Entity<Advertisement>().HasOne(a => a.Localization).WithOne().HasForeignKey<Localization>(a => a.AdvertisementId);
            builder.Entity<AdvertisementArch>().ToTable("AdvertisementArchs");

        }
    }
}
