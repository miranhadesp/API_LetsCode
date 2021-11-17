using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Passagem.Models
{
    public partial class ReservaQuarto
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdQuarto { get; set; }
        public string DataEntrada { get; set; }
        public string DataSaida { get; set; }
    }
}
