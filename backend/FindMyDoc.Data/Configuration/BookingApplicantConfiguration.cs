using FindMyDoc.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyDoc.Data.Configuration
{
    public class BookingApplicantConfiguration : IEntityTypeConfiguration<BookingApplicant>
    {
        public void Configure(EntityTypeBuilder<BookingApplicant> builder)
        {
            builder.HasData(
                new BookingApplicant()
                {
                    Id = Guid.Parse("33B61872-8744-427F-8EED-967878A97B99"),
                    Email = "fakeemail@test.com",
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    FullName = "Joe Bloggs",
                    EmailLastSent = DateTime.Now,
                    NHSNumber = "1234"
                });
        }
    }
}
