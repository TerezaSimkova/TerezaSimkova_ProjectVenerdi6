using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenerdíWeek6.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(16)")]
        public string CodiceFiscale { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Cognome { get; set; }
        public List<Polizza> Polizze { get; set; }

    }
}
