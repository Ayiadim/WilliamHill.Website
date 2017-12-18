using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data;
using WilliamHill.Data.Models;

namespace WilliamHill.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<int> GetTotalBets(int id);
        Task<double> GetTotalBetAmount(int id);
        Task<Dictionary<int, double>> GetTotalBetAmount();
        Task<IEnumerable<Customer>> GetRiskyCustomers();
    }

    public class CustomerService : ICustomerService
    {

        IRepository<Customer> _customerRepository;
        IRepository<Bet> _betRepository;
        private const int RISKY_THRESHOLD = 200;

        public CustomerService(IRepository<Customer> customerRepository, IRepository<Bet> betRepository)
        {
            _customerRepository = customerRepository;
            _betRepository = betRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAll();

            return customers;
        }

        public async Task<int> GetTotalBets(int id)
        {
            var bets = await _betRepository.GetAll();

            var totalBets = bets.Where(b => b.CustomerID == id).ToList();

            return totalBets.Count;
        }

        public async Task<double> GetTotalBetAmount(int id)
        {
            var bets = await _betRepository.GetAll();

            var totalBets = bets.Where(b => b.CustomerID == id).ToList();

            double total = 0;

            foreach (var bet in totalBets)
            {
                total += bet.Stake;
            }

            return total;
        }

        public async Task<Dictionary<int, double>> GetTotalBetAmount()
        {
            var customers = await _customerRepository.GetAll();
            var bets = await _betRepository.GetAll();

            var result = new Dictionary<int, double>();

            foreach (var customer in customers)
            {
                var totalBetAmount = await GetTotalBetAmount(customer.ID);
                result.Add(customer.ID, totalBetAmount);
            }

            return result;
        }

        public async Task<IEnumerable<Customer>> GetRiskyCustomers()
        {
            var customers = await _customerRepository.GetAll();
            var bets = await _betRepository.GetAll();

            var riskyCustomers = new List<Customer>();
            foreach (var customer in customers)
            {
                var totalAmount = await GetTotalBetAmount(customer.ID);
                if (totalAmount > RISKY_THRESHOLD)
                {
                    riskyCustomers.Add(customer);
                }
            }

            return riskyCustomers;
        }
    }
}
