using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WhereToEat.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<ChoiceGroup> ChoiceGroups { get; set; }
        public DbSet<ChoiceMember> ChoiceMembers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Connection>()
                .HasOne(u => u.Sender)
                .WithMany(c => c.Connections)
                .HasForeignKey(u => u.SenderId);
            
            modelBuilder.Entity<Connection>()
                .HasOne(u => u.Receiver)
                .WithMany()
                .HasForeignKey(u => u.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}