using ConsoleApp6.Data;
using ConsoleApp6.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6.Services
{
    public class RoomService
    {
        private readonly HospContext _context;

        public RoomService(HospContext context)
        {
            _context = context;
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public Room GetRoomById(int roomId)
        {
            return _context.Rooms.Find(roomId);
        }

        public void AddRoom(string roomNumber, string roomType)
        {
            var room = new Room
            {
                RoomNumber = roomNumber,
                RoomType = roomType
            };

            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void UpdateRoom(int roomId, string roomNumber, string roomType)
        {
            var existingRoom = _context.Rooms.Find(roomId);

            if (existingRoom != null)
            {
                existingRoom.RoomNumber = roomNumber;
                existingRoom.RoomType = roomType;

                _context.SaveChanges();
            }
        }

        public void DeleteRoom(int roomId)
        {
            var roomToDelete = _context.Rooms.Find(roomId);

            if (roomToDelete != null)
            {
                _context.Rooms.Remove(roomToDelete);
                _context.SaveChanges();
            }
        }
    }
}

