using ConsoleApp6.Data;
using ConsoleApp6.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6.Services
{
    public class DoctorService
    {
        private readonly HospContext _context;

        public DoctorService(HospContext context)
        {
            _context = context;
        }

        public List<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return _context.Doctors.Find(doctorId);
        }

        public void AddDoctor(string name, string specialty)
        {
            var doctor = new Doctor
            {
                Name = name,
                Specialty = specialty
            };

            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void UpdateDoctor(int doctorId, string name, string specialty)
        {
            var existingDoctor = _context.Doctors.Find(doctorId);

            if (existingDoctor != null)
            {
                existingDoctor.Name = name;
                existingDoctor.Specialty = specialty;

                _context.SaveChanges();
            }
        }

        public void DeleteDoctor(int doctorId)
        {
            var doctorToDelete = _context.Doctors.Find(doctorId);

            if (doctorToDelete != null)
            {
                _context.Doctors.Remove(doctorToDelete);
                _context.SaveChanges();
            }
        }
    }
}
