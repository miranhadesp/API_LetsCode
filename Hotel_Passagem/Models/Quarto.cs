using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel_Passagem.Models
{
    public partial class Quarto
    {
        public int Id { get; set; }
        public int? IdHotel { get; set; }
        public string Tipo { get; set; }
        public int? Valor { get; set; }
        public string InfoQuarto { get; set; }

        public virtual Hotel IdHotelNavigation { get; set; }
    }
}
