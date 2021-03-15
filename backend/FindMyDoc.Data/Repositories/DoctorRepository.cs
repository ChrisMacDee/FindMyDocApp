using FindMyDoc.Data.DBContext;
using FindMyDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMyDoc.Data.Repositories
{
    public class DoctorRepository : IRepository<Doctor>
    {
        private readonly FindMyDocDbContext _context;

        public DoctorRepository(FindMyDocDbContext context)
        {
            _context = context;
        }

        public Guid Add(Doctor entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.LastUpdated = DateTime.Now;
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public Doctor Get(Guid id)
        {
            return _context.Doctors.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public void Update(Doctor entity)
        {
            var existing = Get(entity.Id);
            if (existing != null)
            {
                existing.FullName = entity.FullName;
                existing.Address = entity.Address;
                existing.PlaceId = entity.PlaceId;
                existing.LastUpdated = DateTime.Now;

                _context.Update(existing);
                _context.SaveChanges();
            }
        }

        public Doctor GetByPlaceId(string placeId)
        {
            if (string.IsNullOrEmpty(placeId))
            {
                return null;
            }
            return _context.Doctors.FirstOrDefault(n => n.PlaceId.Equals(placeId.Trim())); ;

        }
    }
}
