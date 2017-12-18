using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data;
using WilliamHill.Data.Models;

namespace WilliamHill.Service
{
    public interface IRaceService
    {
        Task<IEnumerable<Race>> GetRaces();
    }

    public class RaceService : IRaceService
    {

        IRepository<Race> _raceRepository;
        IRepository<Bet> _betRepository;

        public RaceService(IRepository<Race> raceRepository, IRepository<Bet> betRepository)
        {
            _raceRepository = raceRepository;
            _betRepository = betRepository;
        }

        public async Task<IEnumerable<Race>> GetRaces()
        {
            var races = await _raceRepository.GetAll();
            var bets = await _betRepository.GetAll();

            // Could use LINQ instead
            foreach (var race in races)
            {
                race.TotalMoneyPlaced = race.GetTotalMoneyPlaced(bets);
                foreach (var horse in race.Horses)
                {
                    horse.TotalBets = horse.GetTotalBets(bets);
                    horse.Payout = horse.GetPayout(bets);
                }
            }

            return races;
        }
    }
}
