using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Passagem.Models
{
    public partial class Passagem
    {
        public Passagem()
        {
            Companhia = new HashSet<Companhia>();
            VendaPassagems = new HashSet<VendaPassagem>();
        }

        public int Id { get; set; }
        public string Destino { get; set; }
        public string Embarque { get; set; }
        public string DataReserva { get; set; }
        public decimal? Valor { get; set; }

        public virtual ICollection<Companhia> Companhia { get; set; }
        public virtual ICollection<VendaPassagem> VendaPassagems { get; set; }
    }
}
