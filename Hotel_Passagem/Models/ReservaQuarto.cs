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
        public decimal? Valor { get; set; }
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Quarto IdQuartoNavigation { get; set; }
    }
}
