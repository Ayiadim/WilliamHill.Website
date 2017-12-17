using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WilliamHill.Data.Models
{
    public class Race
    {

        private IEnumerable<Horse> _horses;

        public IEnumerable<Horse> Horses
        {
            get
            {
                return _horses;
            }
            set
            {
                _horses = value;
            }
        }

        private int _id;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string _status;

        public string Status
        {
            get
            {
                return char.ToUpper(_status[0]) + _status.Substring(1);
            }
            set
            {
                _status = value;
            }
        }

        private DateTime _start;

        public DateTime Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }

        private double _totalMoneyPlaced;

        public double TotalMoneyPlaced
        {
            get
            {
                return _totalMoneyPlaced;
            }
            set
            {
                _totalMoneyPlaced = value;
            }
        }

        public double GetTotalMoneyPlaced(IEnumerable<Bet> bets)
        {
            var totalBets = bets.Where(b => b.RaceID == ID).ToList();

            double total = 0;
            foreach(var bet in totalBets)
            {
                total += bet.Stake;
            }

            return total;
        }

    }
}
