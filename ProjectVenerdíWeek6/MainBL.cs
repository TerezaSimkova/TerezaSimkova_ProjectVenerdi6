using ProjectVenerdíWeek6.Core.Interfaces;
using ProjectVenerdíWeek6.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenerdíWeek6
{
    class MainBL
    {
        private ICustomerRepository _customerRepo;
        private IPolizzaRepository _polizzaRepo;
        public MainBL(ICustomerRepository customerRepository, IPolizzaRepository polizzaRepository)
        {
            _customerRepo = customerRepository;
            _polizzaRepo = polizzaRepository;
        }

        internal bool AddCustomer(Customer customer)
        {
            bool add = _customerRepo.Add(customer);
            return add;
        }

        internal List<Customer> FetchAllClients()
        {
            return _customerRepo.Fetch();
        }

        internal bool AddPolizza(Polizza polizza)
        {
            bool add = _polizzaRepo.Add(polizza);
            return add;
        }

        internal Customer GetByCode(int num)
        {
            var customer = _customerRepo.GetById(num);
            return customer;
        }
    }
}
