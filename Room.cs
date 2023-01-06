using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HotelProject
{
    public class Room
    {
        private MiniBar _minibar;
        public MiniBar MiniBar
        {
            get { return _minibar; }
            set { if (value != null) _minibar = value; }
        }
        private int _roomNumber;
        public int RoomNumber
        {
            //room  number strat from 100 and floor number start from 1
            get { return _roomNumber; }
            set
            {
                while (value < 10 && value > 0)
                {
                    value = value / 10;
                }
                if (this.Floor == value)
                   _roomNumber = value;
            }
        }
        private int _floor;
        public int Floor
        {
            get { return _floor; }
            set
            {
                while (_roomNumber > 0 && _roomNumber < 10)
                {
                    _roomNumber = _roomNumber / 10;
                }
                if (value > 0 && _roomNumber == value) _floor = value;
            }
        }
        private IList<Customer> _customers;
        public IList<Customer> Customers
        {
            get { return _customers; }
            set { if (value != null) _customers = value; }
        }
        private int _cleanLevel;
        public int CleanLevel
        {
            get { return _cleanLevel; }
            set
            {
                if (value > 0 && value < 11) _cleanLevel = value;
            }
        }
        private int _roomRate;
        public int RoomRate
        {
            get { return _roomRate; }
            set
            {
                if (value > 0 && value < 4) _roomRate = value;
            }
        }
        private double _satisfaction;
        public double Satisfaction
        {
            get { return _satisfaction; }
            set
            {
                if (value >= 1.0 && value <= 5.0) _satisfaction = value;
            }
        }

        public Room(MiniBar miniBar, int roomNumber, int floor)
        {
            _minibar = miniBar;
            _roomNumber = roomNumber;
            _floor = floor;
            this._cleanLevel = 0;
            this._satisfaction = 0;
            this._roomRate = 0;
            this.Customers=new List<Customer>();//can convert to array if it needed
        }

        public override string ToString()
        {
            return $"mini bar:{_minibar}\nroom number:{_roomNumber}\n floor:{_floor}\ncustomers:{string.Join(" ,",_customers)}\nclean level:{_cleanLevel}\nroom rate:{_roomRate}\nSatisfaction:{_satisfaction}";
        }

        public override bool Equals(object obj)
        {
            return obj is Room room &&
                   EqualityComparer<MiniBar>.Default.Equals(_minibar, room._minibar) &&
                   EqualityComparer<MiniBar>.Default.Equals(MiniBar, room.MiniBar) &&
                   _roomNumber == room._roomNumber &&
                   RoomNumber == room.RoomNumber &&
                   _floor == room._floor &&
                   Floor == room.Floor &&
                   EqualityComparer<IList<Customer>>.Default.Equals(_customers, room._customers) &&
                   EqualityComparer<IList<Customer>>.Default.Equals(Customers, room.Customers) &&
                   _cleanLevel == room._cleanLevel &&
                   CleanLevel == room.CleanLevel &&
                   _roomRate == room._roomRate &&
                   RoomRate == room.RoomRate &&
                   _satisfaction == room._satisfaction &&
                   Satisfaction == room.Satisfaction;
        }

        public override int GetHashCode()
        {
            int hashCode = -269166473;
            hashCode = hashCode * -1521134295 + EqualityComparer<MiniBar>.Default.GetHashCode(_minibar);
            hashCode = hashCode * -1521134295 + EqualityComparer<MiniBar>.Default.GetHashCode(MiniBar);
            hashCode = hashCode * -1521134295 + _roomNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + RoomNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + _floor.GetHashCode();
            hashCode = hashCode * -1521134295 + Floor.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Customer>>.Default.GetHashCode(_customers);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Customer>>.Default.GetHashCode(Customers);
            hashCode = hashCode * -1521134295 + _cleanLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + CleanLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + _roomRate.GetHashCode();
            hashCode = hashCode * -1521134295 + RoomRate.GetHashCode();
            hashCode = hashCode * -1521134295 + _satisfaction.GetHashCode();
            hashCode = hashCode * -1521134295 + Satisfaction.GetHashCode();
            return hashCode;
        }
    }
}
