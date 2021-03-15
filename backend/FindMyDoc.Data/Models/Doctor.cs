using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindMyDoc.Data.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string PlaceId { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(300)]
        public string Address { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }
    }
}
