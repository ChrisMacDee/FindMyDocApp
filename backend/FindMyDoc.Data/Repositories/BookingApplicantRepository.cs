using FindMyDoc.Data.DBContext;
using FindMyDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMyDoc.Data.Repositories
{
    public class BookingApplicantRepository : IRepository<BookingApplicant>
    {
        private readonly FindMyDocDbContext _context;

        public BookingApplicantRepository(FindMyDocDbContext context)
        {
            _context = context;
        }

        public Guid Add(BookingApplicant entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.LastUpdated = DateTime.Now;
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }        

        public BookingApplicant Get(Guid id)
        {
            return _context.BookingApplicants.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<BookingApplicant> GetAll()
        {
            return _context.BookingApplicants.ToList();
        }

        public void Update(BookingApplicant entity)
        {
            var existing = Get(entity.Id);
            if(existing != null)
            {
                existing.FullName = entity.FullName;
                existing.Email = entity.Email;
                existing.EmailLastSent = entity.EmailLastSent;
                existing.NHSNumber = entity.NHSNumber;
                existing.LastUpdated = DateTime.Now;

                _context.Update(existing);
                _context.SaveChanges();
            }
        }

        public BookingApplicant GetByEmailAddress(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                return null;
            }
            return _context.BookingApplicants.FirstOrDefault(n => n.Email.Equals(email.Trim())); ;
        }
    }
}
