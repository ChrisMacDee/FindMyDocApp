using FindMyDoc.Data.DBContext;
using FindMyDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMyDoc.Data.Repositories
{
    public class BookingRepository : IRepository<Booking>
    {
        private readonly FindMyDocDbContext _context;

        public BookingRepository(FindMyDocDbContext context)
        {
            _context = context;
        }

        public Guid Add(Booking entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.LastUpdated = DateTime.Now;
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }        

        public Booking Get(Guid id)
        {
            return _context.Bookings.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        public void Update(Booking entity)
        {
            var existing = Get(entity.Id);
            if(existing != null)
            {
                existing.DoctorId = entity.DoctorId;
                existing.ApplicantId = entity.ApplicantId;
                existing.BookingDateAndTime = entity.BookingDateAndTime;
                existing.LastUpdated = DateTime.Now;
                _context.Update(existing);
                _context.SaveChanges();
            }
        }
    }
}
