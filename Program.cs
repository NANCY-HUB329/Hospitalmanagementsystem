using System;
using System.Linq;
using ConsoleApp6.Data;
using ConsoleApp6.Models;
using ConsoleApp6.Services;

namespace ConsoleApp6
{
    class Program
    {
        static void Main()
        {
            try
            {
                using (var context = new HospContext())
                {
                    // CRUD operations for Patients
                    var patientService = new PatientService(context);

                    // Add Patient
                    var newPatient = new Patient { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", RoomId = 1 };
                    patientService.AddPatient(newPatient);

                    // Get Patients
                    var retrievedPatients = patientService.GetAllPatients();
                    Console.WriteLine("\nPatients:");
                    foreach (var patient in retrievedPatients)
                    {
                        Console.WriteLine($"ID: {patient.PatientID}, Name: {patient.FirstName} {patient.LastName}, Email: {patient.Email}, Room ID: {patient.RoomId}");
                    }

                    // Update a patient
                    var patientToUpdate = retrievedPatients.FirstOrDefault();
                    if (patientToUpdate != null)
                    {
                        patientToUpdate.Email = "john.updated@example.com";
                        patientService.UpdatePatient(patientToUpdate.PatientID, patientToUpdate);
                    }

                    // Display updated patients
                    Console.WriteLine("\nUpdated Patients:");
                    var updatedPatients = patientService.GetAllPatients();
                    foreach (var patient in updatedPatients)
                    {
                        Console.WriteLine($"ID: {patient.PatientID}, Name: {patient.FirstName} {patient.LastName}, Email: {patient.Email}, Room ID: {patient.RoomId}");
                    }

                    // Delete a patient
                    var patientToDelete = retrievedPatients.FirstOrDefault();
                    if (patientToDelete != null)
                    {
                        patientService.DeletePatient(patientToDelete.PatientID);
                    }

                    // Display remaining patients
                    Console.WriteLine("\nRemaining Patients:");
                    var remainingPatients = patientService.GetAllPatients();
                    foreach (var patient in remainingPatients)
                    {
                        Console.WriteLine($"ID: {patient.PatientID}, Name: {patient.FirstName} {patient.LastName}, Email: {patient.Email}, Room ID: {patient.RoomId}");
                    }

                    // CRUD operations for Doctors
                    var doctorService = new DoctorService(context);

                    // Add Doctor
                    var newDoctor = new Doctor { Name = "Dr. Smith", Specialty = "Cardiology" };
                    doctorService.AddDoctor(newDoctor);

                    // Get Doctors
                    var retrievedDoctors = doctorService.GetAllDoctors();
                    Console.WriteLine("\nDoctors:");
                    foreach (var doctor in retrievedDoctors)
                    {
                        Console.WriteLine($"ID: {doctor.DoctorId}, Name: {doctor.Name}, Specialty: {doctor.Specialty}");
                    }

                    // Update a doctor
                    var doctorToUpdate = retrievedDoctors.FirstOrDefault();
                    if (doctorToUpdate != null)
                    {
                        doctorToUpdate.Specialty = "Orthopedics";
                        doctorService.UpdateDoctor(doctorToUpdate.DoctorId, doctorToUpdate);
                    }

                    // Display updated doctors
                    Console.WriteLine("\nUpdated Doctors:");
                    var updatedDoctors = doctorService.GetAllDoctors();
                    foreach (var doctor in updatedDoctors)
                    {
                        Console.WriteLine($"ID: {doctor.DoctorId}, Name: {doctor.Name}, Specialty: {doctor.Specialty}");
                    }

                    // Delete a doctor
                    var doctorToDelete = retrievedDoctors.FirstOrDefault();
                    if (doctorToDelete != null)
                    {
                        doctorService.DeleteDoctor(doctorToDelete.DoctorId);
                    }

                    // Display remaining doctors
                    Console.WriteLine("\nRemaining Doctors:");
                    var remainingDoctors = doctorService.GetAllDoctors();
                    foreach (var doctor in remainingDoctors)
                    {
                        Console.WriteLine($"ID: {doctor.DoctorId}, Name: {doctor.Name}, Specialty: {doctor.Specialty}");
                    }

                    // CRUD operations for Appointments
                    var appointmentService = new AppointmentService(context);

                    // Add Appointment
                    var newAppointment = new Appointment { AppointmentDate = DateTime.Now, DoctorId = 1, PatientId = 1 };
                    appointmentService.AddAppointment(newAppointment);

                    // Get Appointments
                    var retrievedAppointments = appointmentService.GetAllAppointments();
                    Console.WriteLine("\nAppointments:");
                    foreach (var appointment in retrievedAppointments)
                    {
                        Console.WriteLine($"ID: {appointment.AppointmentId}, Date: {appointment.AppointmentDate}, Doctor ID: {appointment.DoctorId}, Patient ID: {appointment.PatientId}");
                    }

                    // Update an appointment
                    var appointmentToUpdate = retrievedAppointments.FirstOrDefault();
                    if (appointmentToUpdate != null)
                    {
                        appointmentToUpdate.AppointmentDate = DateTime.Now.AddDays(1);
                        appointmentService.UpdateAppointment(appointmentToUpdate.AppointmentId, appointmentToUpdate);
                    }

                    // Display updated appointments
                    Console.WriteLine("\nUpdated Appointments:");
                    var updatedAppointments = appointmentService.GetAllAppointments();
                    foreach (var appointment in updatedAppointments)
                    {
                        Console.WriteLine($"ID: {appointment.AppointmentId}, Date: {appointment.AppointmentDate}, Doctor ID: {appointment.DoctorId}, Patient ID: {appointment.PatientId}");
                    }

                    // Delete an appointment
                    var appointmentToDelete = retrievedAppointments.FirstOrDefault();
                    if (appointmentToDelete != null)
                    {
                        appointmentService.DeleteAppointment(appointmentToDelete.AppointmentId);
                    }

                    // Display remaining appointments
                    Console.WriteLine("\nRemaining Appointments:");
                    var remainingAppointments = appointmentService.GetAllAppointments();
                    foreach (var appointment in remainingAppointments)
                    {
                        Console.WriteLine($"ID: {appointment.AppointmentId}, Date: {appointment.AppointmentDate}, Doctor ID: {appointment.DoctorId}, Patient ID: {appointment.PatientId}");
                    }

                    // CRUD operations for Rooms
                    var roomService = new RoomService(context);

                    // Add Room
                    var newRoom = new Room { RoomNumber = "101", RoomType = "Standard" };
                    roomService.AddRoom(newRoom);

                    // Get Rooms
                    var retrievedRooms = roomService.GetAllRooms();
                    Console.WriteLine("\nRooms:");
                    foreach (var room in retrievedRooms)
                    {
                        Console.WriteLine($"ID: {room.RoomId}, Number: {room.RoomNumber}, Type: {room.RoomType}");
                    }

                    // Update a room
                    var roomToUpdate = retrievedRooms.FirstOrDefault();
                    if (roomToUpdate != null)
                    {
                        roomToUpdate.RoomNumber = "102";
                        roomToUpdate.RoomType = "Deluxe";
                        roomService.UpdateRoom(roomToUpdate.RoomId, roomToUpdate);
                    }

                    // Display updated rooms
                    Console.WriteLine("\nUpdated Rooms:");
                    var updatedRooms = roomService.GetAllRooms();
                    foreach (var room in updatedRooms)
                    {
                        Console.WriteLine($"ID: {room.RoomId}, Number: {room.RoomNumber}, Type: {room.RoomType}");
                    }

                    // Delete a room
                    var roomToDelete = retrievedRooms.FirstOrDefault();
                    if (roomToDelete != null)
                    {
                        roomService.DeleteRoom(roomToDelete.RoomId);
                    }

                    // Display remaining rooms
                    Console.WriteLine("\nRemaining Rooms:");
                    var remainingRooms = roomService.GetAllRooms();
                    foreach (var room in remainingRooms)
                    {
                        Console.WriteLine($"ID: {room.RoomId}, Number: {room.RoomNumber}, Type: {room.RoomType}");
                    }

                    // If the CRUD operations succeeded, the connection is working
                    Console.WriteLine("\nCRUD operations successful!");
                }
            }
            catch (Exception ex)
            {
                // If an exception occurs, print the error message
                Console.WriteLine($"Database connection or CRUD operations error: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
