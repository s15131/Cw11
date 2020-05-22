using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw11.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly CodeFirstContext _context;

        public DoctorController(CodeFirstContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctor()
        {
            return Ok(_context.Doctor.ToList());
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            int z; 
            while (_context.Prescription.Where(x => x.IdDoctor == id).Any()==true) {
                z = _context.Prescription.Where(x => x.IdDoctor == id).FirstOrDefault().IdPrescription;
                _context.PrescriptionMedicament.Remove(_context.PrescriptionMedicament.Where(x => x.IdPrescription == z).FirstOrDefault());
                _context.Prescription.Remove(_context.Prescription.Where(x => x.IdPrescription == z).FirstOrDefault()) ;
                _context.SaveChanges();
            }
            _context.Doctor.Remove(_context.Doctor.Where(x => x.IdDoctor == id).FirstOrDefault());
            _context.SaveChanges();
            return Ok("Usunięto lekarza " + id);
        }

        [HttpPost("add")]
        public IActionResult AddDoctor(Doctor d)
        {
            _context.Add(new Doctor { IdDoctor = d.IdDoctor, FirstName = d.FirstName, LastName = d.LastName, Email = d.Email });
            _context.SaveChanges();
            return Ok("Dodano nowego lekarza");
        }
        [HttpPost("update")]
        public IActionResult UpdateDoctor(Doctor d)
        {
            var doctor = _context.Doctor.Where(x => x.IdDoctor == d.IdDoctor).FirstOrDefault();
            if (d.FirstName != null)
            {
             doctor.FirstName = d.FirstName;
            }
            if (d.LastName != null)
            {
                doctor.LastName = d.LastName;
            }
            if (d.Email != null)
            {
                doctor.Email = d.Email;
            }

            _context.SaveChanges();
            return Ok("Zaktualizowano lekarza " + d.IdDoctor);
        }
    }
}