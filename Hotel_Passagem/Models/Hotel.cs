using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Passagem.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Quartos = new HashSet<Quarto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool? Estacionamento { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }

        public virtual ICollection<Quarto> Quartos { get; set; }
    }
}
