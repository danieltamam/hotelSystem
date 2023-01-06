using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
    public class MiniBar
    {
        private IList<Drink> _drinks;
        public IList<Drink> Drinks 
        { 
            get { return _drinks; } set { if (value != null) { _drinks = value; } }
        }
        private IList<Snack> _snacks;
        public IList<Snack> Snacks
        {
            get { return _snacks; }
            set { if (value != null) { _snacks = value; } }
        }
        private double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { if (value >0) { _totalPrice = value; } }
        }

        public MiniBar(IList<Drink> drinks, IList<Snack> snacks)
        {
            _drinks = drinks;
            _snacks = snacks;
            _totalPrice = 0;
        }
        

        public override string ToString()
        {
            return $"drinks:{string.Join(",", _drinks)}\nsnacks:{string.Join(",", _snacks)}\ntotal price:{_totalPrice}";
        }

        public override bool Equals(object obj)
        {
            return this._snacks == ((MiniBar)(obj))._snacks && this._drinks == ((MiniBar)(obj))._drinks && this._totalPrice == ((MiniBar)(obj))._totalPrice;
            //return obj is MiniBar bar &&
            //       EqualityComparer<IList<Drink>>.Default.Equals(Drinks, bar.Drinks) &&
            //       EqualityComparer<IList<Snack>>.Default.Equals(Snacks, bar.Snacks) &&
            //       TotalPrice == bar.TotalPrice;
        }

        public override int GetHashCode()
        {
            int hashCode = -1264177966;
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Drink>>.Default.GetHashCode(Drinks);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Snack>>.Default.GetHashCode(Snacks);
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            return hashCode;
        }
    }
}
