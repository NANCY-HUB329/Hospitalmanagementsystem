using ConsoleApp6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp6.Data
{
    public  class HospContext : DbContext
    {

        public DbSet<Patient>? Patients { get; set; }
        public DbSet<Doctor>? Doctors { get; set; }
        public DbSet<Appointment>? Appointments { get; set; }
        public DbSet<Room>? Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=DESKTOP-GNVRFJ8;Database=HospmgtSystem;Integrated Security=True;");

        }


    }
    


    
}
