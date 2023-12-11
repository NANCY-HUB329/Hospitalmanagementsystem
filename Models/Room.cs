using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string? RoomType { get; set; }
        public Room()
        {
            RoomNumber = string.Empty; // Initialize RoomNumber to a non-null value
        }
    }
}
