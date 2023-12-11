using ConsoleApp6.Data;
using ConsoleApp6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6.Services
{
    public class PatientService
    {
        private readonly HospContext _context;

        public PatientService(HospContext context)
        {
            _context = context;
        }

        public List<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient GetPatientById(int patientId)
        {
            return _context.Patients.Find(patientId);
        }

        public void AddPatient(string firstName, string lastName, string email, int roomId)
        {
            var patient = new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                RoomId = roomId
            };

            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatient(int patientId, string firstName, string lastName, string email, int roomId)
        {
            var existingPatient = _context.Patients.Find(patientId);

            if (existingPatient != null)
            {
                existingPatient.FirstName = firstName;
                existingPatient.LastName = lastName;
                existingPatient.Email = email;
                existingPatient.RoomId = roomId;

                _context.SaveChanges();
            }
        }

        public void DeletePatient(int patientId)
        {
            var patientToDelete = _context.Patients.Find(patientId);

            if (patientToDelete != null)
            {
                _context.Patients.Remove(patientToDelete);
                _context.SaveChanges();
            }
        }
    }
}
