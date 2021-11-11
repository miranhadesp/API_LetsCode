using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Passagem.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ReservaQuartos = new HashSet<ReservaQuarto>();
            VendaPassagems = new HashSet<VendaPassagem>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<ReservaQuarto> ReservaQuartos { get; set; }
        public virtual ICollection<VendaPassagem> VendaPassagems { get; set; }
    }
}
