using Application;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<DeliveryMan> DeliveryMen { get; set; }
        public DbSet<DeliveryRequest> DeliveryRequests { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Lga> Lgas { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Location> Locations { get; set; }  

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            User admin = new User("admin@gmail.com", "Admin123", AppStatics.AdminRole);
            modelBuilder.Entity<User>().HasData(admin);
        }

    }
}
