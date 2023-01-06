using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
    public class Hotel
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(value!=null&&value!="")_name = value;    
            }
        }
        private IList<Room> _rooms;
        public IList<Room> Rooms
        {
            get { return _rooms; }
            set { if (value != null && value.Count > 0) _rooms = value; }
        }

        public Hotel(string name,IList<Room>rooms)
        {
            _name = name;
            _rooms = rooms;
        }

        public void CheckIn(IList<Customer> customers)
        {
            
           foreach(var room in this.Rooms)
            {
                if(room.RoomRate>=2.5)
                    room.Customers = customers;
                break;
            }
            Console.WriteLine($"sorry but all the rooms are not with rank level");
        }
            
        public void TransferToTheBestRoom(IList<Customer> customers)
        {
            double maxRate = 0;
            for( int i = 0; i <this.Rooms.Count; i++)
            {
                if (this.Rooms[i].RoomRate >= maxRate)
                {
                    maxRate = this.Rooms[i].RoomRate;
                    this.Rooms[i].Customers = customers;
                }
            }
        }
        public void CheckOut(Customer customer)
        {
            double payment = 0;
            if (customer.Name == "Guest")
            {
                foreach (var room in Rooms)
                {
                    if (room.Customers.Contains(customer))
                    {
                        room.Customers.Remove(customer);
                        payment = (room.RoomRate * 100 + room.CleanLevel * 50) * room.Customers.Count * room.Floor + room.MiniBar.TotalPrice;
                        Console.WriteLine($"payment:{payment}");
                        break;
                    }
                }
                Console.WriteLine($"the customer:{customer} is not in the hotel");
            }
            else
            {
                throw new IllegalException("IllegalException:sorry you name is not Guest");
            }

        }

        public override string ToString()
        {
            return $"name:{_name}\nrooms:{string.Join(" , ", _rooms)}";
        }

        public override bool Equals(object obj)
        {
            return obj is Hotel hotel &&
                   _name == hotel._name &&
                   EqualityComparer<IList<Room>>.Default.Equals(_rooms, hotel._rooms);
        }

        public override int GetHashCode()
        {
            int hashCode = 123935095;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Room>>.Default.GetHashCode(_rooms);
            return hashCode;
        }
    }
}
