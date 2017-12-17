using System;
using System.Collections.Generic;
using System.Text;

namespace WilliamHill.Data.Models
{
    public class Bet
    {
        private int _customerId;

        public int CustomerID
        {
            get
            {
                return _customerId;
            }
            set
            {
                _customerId = value;
            }
        }

        private int _horseId;

        public int HorseID
        {
            get
            {
                return _horseId;
            }
            set
            {
                _horseId = value;
            }
        }

        private int _raceId;

        public int RaceID
        {
            get
            {
                return _raceId;
            }
            set
            {
                _raceId = value;
            }
        }


        private double _stake;

        public double Stake
        {
            get
            {
                return _stake;
            }
            set
            {
                _stake = value;
            }
        }
    }
}
