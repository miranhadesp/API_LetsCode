using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.ReservaQuartoValidation
{
    public class DataSaidaError : ISpecification<ReservaQuarto>
    {
        public bool IsSatisfiedBy(ReservaQuarto entity)
        {
            return !string.IsNullOrWhiteSpace(entity.DataSaida) && entity.DataSaida.Length < 11 && entity.DataSaida.Contains("/");
        }
    }
}


