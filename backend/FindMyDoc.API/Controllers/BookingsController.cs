using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyDoc.API.PostModels;
using FindMyDoc.Data.Models;
using FindMyDoc.Data.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindMyDoc.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IRepository<Booking> _bookingsRepository;
        private readonly IRepository<BookingApplicant> _applicantRepository;
        private readonly IRepository<Doctor> _doctorRepository;

        public BookingsController(IRepository<Booking> repository, IRepository<BookingApplicant> applicantRepo, IRepository<Doctor> doctorRepo)
        {
            _bookingsRepository = repository;
            _applicantRepository = applicantRepo;
            _doctorRepository = doctorRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookingsRepository.GetAll());
        }

        [EnableCors("CorsPolicy")]
        [HttpPost]
        public IActionResult Post([FromBody] CreateBookingPostModel booking)
        {
            if (booking == null)
            {
                return BadRequest("Data is invalid please check values.");
            }

            // First we make sure that the applicant and doctor aren't already in the system.
            var applicant = ((BookingApplicantRepository)_applicantRepository).GetByEmailAddress(booking.ApplicantEmailAddress);
            if (applicant == null)
            {
                applicant = new BookingApplicant()
                {
                    Email = booking.ApplicantEmailAddress,
                    FullName = booking.ApplicantFullName,
                    NHSNumber = booking.NHSNumber
                };
                _applicantRepository.Add(applicant);
            }

            var doctor = ((DoctorRepository)_doctorRepository).GetByPlaceId(booking.PlaceId);
            if (doctor == null)
            {
                doctor = new Doctor()
                {
                    FullName = booking.DoctorFullName,
                    Address = booking.DoctorAddress,
                    PlaceId = booking.PlaceId
                };
                _doctorRepository.Add(doctor);
            }

            var newBooking = new Booking()
            {
                ApplicantId = applicant.Id,
                DoctorId = doctor.Id,
                BookingDateAndTime = booking.DateTimeOfBooking,
            };
            var bookingId = _bookingsRepository.Add(newBooking);

            if (bookingId != Guid.Empty)
            {
                // TODO: Send email via Gmail SMTP
            }


            return Ok(bookingId);
        }

        public IActionResult ResendEmail(Guid id)
        {
            // Here would resend email.
            return Ok("Email resent");
        }
    }
}
