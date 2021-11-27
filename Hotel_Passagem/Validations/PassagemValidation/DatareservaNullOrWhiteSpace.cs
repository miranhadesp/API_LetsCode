using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.PassagemValidation
{
    public class DatareservaNullOrWhiteSpace : ISpecification<Passagem>
    {
        public bool IsSatisfiedBy(Passagem entity)
        {
            return !string.IsNullOrWhiteSpace(entity.DataReserva) && entity.DataReserva.Length <11 && entity.DataReserva.Contains("/");
        }
    }
}




