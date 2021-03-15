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
            
            // TODO: Add seeding option to config
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingApplicant> Applicants { get; set; }
    }
}
