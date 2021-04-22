using FindMyDoc.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyDoc.Data.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData(
                new Doctor()
                {
                    Id = Guid.Parse("33B61872-8744-427F-8EED-967878A97B98"),
                    Address = "123 Fake Street",
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    FullName = "Dr Who",
                    PlaceId = "12345"
                });
        }
    }
}
