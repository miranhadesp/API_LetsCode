using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Passagem.Models
{
    public partial class VendaPassagem
    {
        public int Id { get; set; }
        public int? IdPassagem { get; set; }
        public int? IdCliente { get; set; }
    }
}
