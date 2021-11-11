using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Passagem.Models
{
    public partial class Companhia
    {
        public int Id { get; set; }
        public int? IdPassagem { get; set; }
        public string Nome { get; set; }

        public virtual Passagem IdPassagemNavigation { get; set; }
    }
}
