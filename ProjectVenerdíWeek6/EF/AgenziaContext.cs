using Microsoft.EntityFrameworkCore;
using ProjectVenerdíWeek6.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenerdíWeek6
{
    public class AgenziaContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Polizza> Polizze { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
		    Database=AgenziaDiAssicurazione;Trusted_Connection=True;");
        }


    }
}
