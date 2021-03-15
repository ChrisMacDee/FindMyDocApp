using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindMyDoc.Data.Models
{
    public class BookingApplicant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [StringLength(10)]
        public string NHSNumber { get; set; }
        public DateTime EmailLastSent { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }
    }
}
