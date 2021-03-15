using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyDoc.API.PostModels
{
    public class CreateBookingPostModel
    {
        [Required]
        public DateTime DateTimeOfBooking { get; set; }
        [Required]
        public string ApplicantFullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage="Please enter a valid email address")]
        public string ApplicantEmailAddress { get; set; }
        [StringLength(10, ErrorMessage="Please enter your 10 character NHS Number")]
        public string NHSNumber { get; set; }
        [Required]
        public string DoctorFullName { get; set; }
        [Required]
        public string DoctorAddress { get; set; }
        [Required]
        public string PlaceId { get; set; }
    }
}
