using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI_HO.Models
{
    public partial class HovedOpgavenContext : DbContext
    {
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Pilots> Pilots { get; set; }

        public HovedOpgavenContext(DbContextOptions<HovedOpgavenContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingDate).HasColumnType("date");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PilotId).HasColumnName("PilotID");

                entity.Property(e => e.Place)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Bookings__Custom__3B75D760");

                entity.HasOne(d => d.Pilot)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PilotId)
                    .HasConstraintName("FK__Bookings__PilotI__3C69FB99");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Customers__Booki__3D5E1FD2");
            });

            modelBuilder.Entity<Pilots>(entity =>
            {
                entity.HasKey(e => e.PilotId);

                entity.Property(e => e.PilotId).HasColumnName("PilotID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Pilots)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Pilots__BookingI__3E52440B");
            });
        }
    }
}
