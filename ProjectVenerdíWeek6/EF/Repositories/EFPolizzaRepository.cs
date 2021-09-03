using ProjectVenerdíWeek6.Core.Interfaces;
using ProjectVenerdíWeek6.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenerdíWeek6.EF.Repositories
{
    public class EFPolizzaRepository : IPolizzaRepository
    {
        private readonly AgenziaContext polizzaAtx;
        public EFPolizzaRepository()
        {
            polizzaAtx = new AgenziaContext();
        }

        public bool Add(Polizza polizza)
        {
            if (polizza == null)
                return false;

            try
            {
                polizzaAtx.Polizze.Add(new Polizza
                {
                    NumeroPolizza = polizza.NumeroPolizza,
                    DataScadenza = polizza.DataScadenza,
                    RataMensile = polizza.RataMensile,
                    Tipo=polizza.Tipo,
                    CustomerId = polizza.CustomerId
                });

                polizzaAtx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Polizza item)
        {
            throw new NotImplementedException();
        }

        public List<Polizza> Fetch()
        {
            throw new NotImplementedException();
        }

        public Polizza GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Polizza item)
        {
            throw new NotImplementedException();
        }
    }
}
