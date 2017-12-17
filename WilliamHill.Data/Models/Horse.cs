using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WilliamHill.Data.Models
{
    public class Horse
    {

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

        private double _odds;

        public double Odds
        {
            get
            {
                return _odds;
            }
            set
            {
                _odds = value;
            }
        }

        private int _totalBets;

        public int TotalBets
        {
            get
            {
                return _totalBets;
            }
            set
            {
                _totalBets = value;
            }
        }

        private double _payout;

        public double Payout
        {
            get
            {
                return _payout;
            }
            set
            {
                _payout = value;
            }
        }

        public double GetPayout(IEnumerable<Bet> bets)
        {

            var totalBets = bets.Where(b => b.HorseID == ID).ToList();

            double total = 0;
            foreach(var bet in totalBets)
            {
                total += bet.Stake;
            }

            return total * Odds;
        }

        public int GetTotalBets(IEnumerable<Bet> bets)
        {
            return bets.Where(b => b.HorseID == ID).ToList().Count;
        }
    }
}
