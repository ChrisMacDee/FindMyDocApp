using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindMyDoc.Data.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public DateTime BookingDateAndTime { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ApplicantId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }

        public BookingApplicant Applicant { get; set; }
        public Doctor Doctor { get; set; }

    }
}
