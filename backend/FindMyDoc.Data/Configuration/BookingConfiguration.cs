using FindMyDoc.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyDoc.Data.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(
                new Booking()
                {
                    Id = Guid.NewGuid(),
                    ApplicantId = Guid.Parse("33B61872-8744-427F-8EED-967878A97B99"),
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    BookingDateAndTime = DateTime.Now,
                    DoctorId = Guid.Parse("33B61872-8744-427F-8EED-967878A97B98")
                });
        }
    }
}
