using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliamHill.Data.Models;

namespace WilliamHill.Tests
{
    [TestClass]
    public class RaceTests
    {
        List<Bet> bets;
        List<Race> races;

        [TestCleanup]
        public void Clean()
        {
            races = null;
            bets = null;
        }

        [TestInitialize]
        public void Init()
        {
            races = new List<Race>
            {
                new Race { ID = 1, Name = "Melbourne Cup" },
                new Race { ID = 2, Name = "Australia Cup" },
                new Race { ID = 3, Name = "Red Oaks" },
            };

            bets = new List<Bet>
            {
                new Bet { RaceID = 1, HorseID = 1, Stake = 50},
                new Bet { RaceID = 1, HorseID = 1, Stake = 30},
                new Bet { RaceID = 1, HorseID = 1, Stake = 40},
                new Bet { RaceID = 2, HorseID = 2, Stake = 20},
                new Bet { RaceID = 2, HorseID = 2, Stake = 20},
                new Bet { RaceID = 3, HorseID = 2, Stake = 30}
            };
        }

        [TestMethod]
        public void TestRaceTotalMoneyPlaced()
        {
            var expected = 120;
            var actual = races[0].GetTotalMoneyPlaced(bets);
            Assert.AreEqual(expected, actual);
        }
    }
}
