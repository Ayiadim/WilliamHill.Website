using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data;
using WilliamHill.Data.Models;

namespace WilliamHill.Tests.Mocks
{
    public class MockBetRepository : IRepository<Bet>
    {

        List<Bet> bets;

        public MockBetRepository()
        {
            bets = new List<Bet>
            {
                new Bet { CustomerID = 1, Stake = 50},
                new Bet { CustomerID = 1, Stake = 30},
                new Bet { CustomerID = 1, Stake = 40},
                new Bet { CustomerID = 2, Stake = 20},
                new Bet { CustomerID = 2, Stake = 20},
                new Bet { CustomerID = 2, Stake = 30},
                new Bet { CustomerID = 3, Stake = 40},
                new Bet { CustomerID = 3, Stake = 234},
                new Bet { CustomerID = 3, Stake = 55},
            };
        }

        public Task<IEnumerable<Bet>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<Bet>>();
            tcs.SetResult(bets);
            return tcs.Task;
        }
    }
}
