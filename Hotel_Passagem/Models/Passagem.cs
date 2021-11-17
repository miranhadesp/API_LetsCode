using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Passagem.Models
{
    public partial class Passagem
    {
        public int Id { get; set; }
        public string Destino { get; set; }
        public string Embarque { get; set; }
        public string DataReserva { get; set; }
        public decimal? Valor { get; set; }
        public int? IdCompanhia { get; set; }
    }
}
