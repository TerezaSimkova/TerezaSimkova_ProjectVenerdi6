using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenerdíWeek6.Core.Models
{
    public class Polizza
    {
        public int Id { get; set; }

        [Required]
        public int NumeroPolizza { get; set; }
        public DateTime DataScadenza { get; set; }
        public decimal RataMensile { get; set; }
        public EnumTipo Tipo { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
       
        public enum EnumTipo
        {
            RCAuto = 1,
            Furto = 2,
            Vita = 3
        }
    }
}
