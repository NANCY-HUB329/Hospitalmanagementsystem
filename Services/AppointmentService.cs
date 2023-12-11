using ConsoleApp6.Data;
using ConsoleApp6.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6.Services
{
    public class AppointmentService
    {
        private readonly HospContext _context;

        public AppointmentService(HospContext context)
        {
            _context = context;
        }

        public List<Appointment> GetAllAppointments()
        {
            return _context.Appointments.ToList();
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            return _context.Appointments.Find(appointmentId);
        }

        public void AddAppointment(DateTime appointmentDate, int doctorId, int patientId)
        {
            var appointment = new Appointment
            {
                AppointmentDate = appointmentDate,
                DoctorId = doctorId,
                PatientId = patientId
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(int appointmentId, DateTime appointmentDate, int doctorId, int patientId)
        {
            var existingAppointment = _context.Appointments.Find(appointmentId);

            if (existingAppointment != null)
            {
                existingAppointment.AppointmentDate = appointmentDate;
                existingAppointment.DoctorId = doctorId;
                existingAppointment.PatientId = patientId;

                _context.SaveChanges();
            }
        }

        public void DeleteAppointment(int appointmentId)
        {
            var appointmentToDelete = _context.Appointments.Find(appointmentId);

            if (appointmentToDelete != null)
            {
                _context.Appointments.Remove(appointmentToDelete);
                _context.SaveChanges();
            }
        }
    }
}
