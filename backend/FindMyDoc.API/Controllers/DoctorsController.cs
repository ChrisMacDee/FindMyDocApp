using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyDoc.Data.Models;
using FindMyDoc.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindMyDoc.API.Controllers
{
//    [Route("[controller]")]
//    [ApiController]
//    public class DoctorsController : ControllerBase
//    {
//        private readonly IRepository<Doctor> _doctorRepository;
//        public DoctorsController(IRepository<Doctor> repository)
//        {
//            _doctorRepository = repository;
//        }

//        [HttpGet]
//        public IActionResult Get()
//        {
//            return Ok(_doctorRepository.GetAll());
//        }

//        [HttpGet("{id}", Name = "Get")]
//        public IActionResult Get(Guid id)
//        {
//            var booking = _doctorRepository.Get(id);
//            if(booking != null)
//            {
//                return NotFound("The doctor record you are looking for does not exist.");
//            }
//            return Ok(booking);
//        }
//    }
}
