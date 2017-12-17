using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliamHill.Data.Models;

namespace WilliamHill.Tests
{
    [TestClass]
    public class HorseTests
    {

        List<Horse> horses;
        List<Bet> bets;

        [TestCleanup]
        public void Clean()
        {
            horses = null;
            bets = null;
        }

        [TestInitialize]
        public void Init()
        {
            horses = new List<Horse>
            {
                new Horse { ID = 1, Name = "Liberty", Odds = 5.5 },
                new Horse { ID = 2, Name = "Thunderbolt", Odds = 1.3 },
                new Horse { ID = 3, Name = "Jigsaw", Odds = 3.2 },
                new Horse { ID = 4, Name = "Rainheart", Odds = 3.4 },
                new Horse { ID = 5, Name = "Legacy", Odds = 0.5 },
                new Horse { ID = 6, Name = "Quicksilver", Odds = 8.7 },
                new Horse { ID = 7, Name = "Bullet", Odds = 7.0 },
                new Horse { ID = 8, Name = "Prudince", Odds = 4.1 },
                new Horse { ID = 9, Name = "Baron", Odds = 5.7 },
                new Horse { ID = 10, Name = "Windrunner", Odds = 9.9 }
            };

            bets = new List<Bet>
            {
                new Bet { HorseID = 1, Stake = 50},
                new Bet { HorseID = 1, Stake = 30},
                new Bet { HorseID = 1, Stake = 40},
                new Bet { HorseID = 2, Stake = 20},
                new Bet { HorseID = 2, Stake = 20},
                new Bet { HorseID = 2, Stake = 30},
                new Bet { HorseID = 3, Stake = 40},
                new Bet { HorseID = 3, Stake = 44},
                new Bet { HorseID = 3, Stake = 55},
                new Bet { HorseID = 4, Stake = 120},
                new Bet { HorseID = 4, Stake = 250},
                new Bet { HorseID = 4, Stake = 330},
                new Bet { HorseID = 5, Stake = 234},
                new Bet { HorseID = 5, Stake = 432},
                new Bet { HorseID = 5, Stake = 12},
                new Bet { HorseID = 6, Stake = 5},
                new Bet { HorseID = 6, Stake = 3},
                new Bet { HorseID = 6, Stake = 4},
                new Bet { HorseID = 6, Stake = 50},
                new Bet { HorseID = 7, Stake = 50},
                new Bet { HorseID = 7, Stake = 50},
                new Bet { HorseID = 7, Stake = 50},
                new Bet { HorseID = 7, Stake = 50},
                new Bet { HorseID = 8, Stake = 50},
                new Bet { HorseID = 8, Stake = 50},
                new Bet { HorseID = 9, Stake = 50},
                new Bet { HorseID = 9, Stake = 50},
                new Bet { HorseID = 10, Stake = 50},
                new Bet { HorseID = 10, Stake = 50},
                new Bet { HorseID = 10, Stake = 50},
                new Bet { HorseID = 10, Stake = 50},
                new Bet { HorseID = 10, Stake = 50},
            };
        }

        [TestMethod]
        public void TestHorseTotalBets()
        {
            var expected = 3;
            var actual = horses[0].GetTotalBets(bets);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHorsePayout()
        {
            var expected = 120 * 5.5;
            var actual = horses[0].GetPayout(bets);
            Assert.AreEqual(actual, expected);
        }
    }
}
