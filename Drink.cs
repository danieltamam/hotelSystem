using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
    public class Drink
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != "" || value != null)
                    _name = value;
            }
        }
        private double _price;
        public double Price
        {
            get { return _price; }
            set { if (value > 0) { _price = value; } }
        }

        public Drink(string name, double price)
        {
            _name = name;
            _price = price;
        }
        public override string ToString()
        {
            return $"name:{_name}\nprice:{_price}";
        }

        public override bool Equals(object obj)
        {
            return obj is Drink drink &&
                   _name == drink._name &&
                   Name == drink.Name &&
                   _price == drink._price &&
                   Price == drink.Price;
        }

        public override int GetHashCode()
        {
            int hashCode = -1022559636;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + _price.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
}
