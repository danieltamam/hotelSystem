using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
    public class Customer
    {
        private string _name;
        public string Name
        {
            get { return this._name; }
            set { if (value != null && value != "") this._name = value; }
        }
        private Room _room;
        public Room Room
        {
            get { return this._room; }
            set { if (value != null) this._room = value; }
        }
        public void AddDrink(Drink drink)
        {
            if (drink != null)
            {
                this.Room.MiniBar.Drinks.Add(drink);
                this.Room.MiniBar.TotalPrice += drink.Price;
            }
            else
            {
                throw new StockException("StockException:this drink are not in stock");
            }

        }
        public void AddSnack(Snack snack)
        {
            if (snack != null)
            {
                this.Room.MiniBar.Snacks.Add(snack);
                this.Room.MiniBar.TotalPrice += snack.Price;
            }
            else
            {
                throw new StockException("StockException:this snack are not in stock");
            }
        }
        public Customer(string name, Room room)
        {
            _name = name;
            _room= room;
        }

        public override string ToString()
        {
            return $"name:{Name}";
        }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   Name == customer.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
