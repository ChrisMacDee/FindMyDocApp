using FindMyDoc.Data.Configuration;
using FindMyDoc.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyDoc.Data.DBContext
{
    public class FindMyDocDbContext : DbContext
    {
        public FindMyDocDbContext(DbContextOptions options)
            :base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());  
            modelBuilder.ApplyConfiguration(new BookingApplicantConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingApplicant> BookingApplicants { get; set; }
    }
}
