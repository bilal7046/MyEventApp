using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyEventApp.Models;
using System.Reflection.Emit;

namespace MyEventApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Member> Member { get; set; }
        public DbSet<Ride> Ride { get; set; }
        public DbSet<Entry> Entry { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Ride>().ToTable("Rides");
            builder.Entity<Entry>().ToTable("Entries");
            builder.Entity<Member>().ToTable("Members");
        }
    }
}