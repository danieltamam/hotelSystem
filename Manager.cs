using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
     public class Manager
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != null || value != "") _name = value;
            }
        }
        public Manager(string name)
        {
            _name = name;
        }
        public bool IsTheRoomFull(Room room)
        {
            if (room.Customers != null&&room.Customers.Count>0) return true;
            else
                return false;
        }
        public Room WhatRoomIsBetter(Room room1, Room room2)
        {
            if (room1.RoomRate > room2.RoomRate) return room1;
            else
                return room2;
        }
        public void AddCustomersToRoom(IList<Customer>customers,Room room)
        {
            if(room.Customers!=null&&room.Customers.Count>0)
            {
                throw new StockException("StockException: this room already full");
            }
            else
            {
                room.Customers= customers;
            }
        }
        public double CheckOut(Room room)
        {
            if (room != null && room.Customers.Count > 0)
            {
                foreach(var customer in room.Customers)
                {
                    room.Customers.Remove(customer);
                }
                return room.RoomRate;
            }
            return -1;   
        }
        public void TransferRoom(Hotel hotel,Room room)
        {
            if (hotel.Rooms.Contains(room))
            {
                foreach(var Room in hotel.Rooms)
                {
                    if (Room.Customers == null || Room.Customers.Count == 0)
                    {
                        Room.Customers = room.Customers;
                        break;
                    }
                }
                throw new StockException("StockException:all the rooms are full , can't transfer sorry");
            }
            throw new IllegalException("IllegalException:the room that you give are not part of this hotel");
        }

        public override string ToString()
        {
            return $"name:{Name}";
        }

        public override bool Equals(object obj)
        {
            return obj is Manager manager &&
                   Name == manager.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
