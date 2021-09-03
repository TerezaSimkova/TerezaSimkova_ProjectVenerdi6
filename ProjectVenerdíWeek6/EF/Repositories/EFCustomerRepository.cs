using ProjectVenerdíWeek6.Core.Interfaces;
using ProjectVenerdíWeek6.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenerdíWeek6.EF.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly AgenziaContext Atx;
        public EFCustomerRepository()
        {
            Atx = new AgenziaContext();
        }

        public bool Add(Customer customer)
        {
            if (customer == null)
                return false;

            try
            {
                Atx.Customers.Add(new Customer
                {
                    CodiceFiscale = customer.CodiceFiscale,
                    Nome = customer.Nome,
                    Cognome = customer.Cognome,

                });

                Atx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Customer item)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Fetch()
        {
            return Atx.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            var c = Atx.Customers.Where(c => c.Id == id).FirstOrDefault();
            return c;
        }

        public bool Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
