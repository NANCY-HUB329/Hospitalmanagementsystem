using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }

        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }  // Make DoctorId nullable
        

        [ForeignKey("Patient")]
        public int? PatientId { get; set; }  // Make PatientId nullable
       
    }
}
