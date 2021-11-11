using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Passagem.Models
{
    public partial class VendaPassagem
    {
        public int Id { get; set; }
        public int? IdPassagem { get; set; }
        public string Nome { get; set; }
        public decimal? Valor { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Passagem IdPassagemNavigation { get; set; }
    }
}
