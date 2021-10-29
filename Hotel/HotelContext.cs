using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel
{
    class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options)
    : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderService> OrderServices { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(CustomerConfigure);
            modelBuilder.Entity<Booking>(BookingConfigure);
            modelBuilder.Entity<Employee>(EmployeeConfigure);



        }
        public void CustomerConfigure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers").HasKey(p => p.CustomerId);
            builder.Property(p => p.CustomerName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(30);
        }
        public void BookingConfigure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings").HasKey(p => p.BookingId);

        }
        public void EmployeeConfigure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees").HasKey(p => p.EmployeeId);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.LastName).HasMaxLength(30);
        }



    }
}





