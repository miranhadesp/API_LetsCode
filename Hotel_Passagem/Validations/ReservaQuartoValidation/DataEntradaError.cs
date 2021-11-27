using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.ReservaQuartoValidation
{
    public class DataEntradaError : ISpecification<ReservaQuarto>
    {
        public bool IsSatisfiedBy(ReservaQuarto entity)
        {
            return !string.IsNullOrWhiteSpace(entity.DataEntrada) && entity.DataEntrada.Length < 11 && entity.DataEntrada.Contains("/");
        }
    }
}