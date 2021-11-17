using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.QuartoValidation
{
    public class InfoQuartoValidation : ISpecification<Quarto>
    {
        public bool IsSatisfiedBy(Quarto entity)
        {
            return entity.InfoQuarto.Length <= 500;
        }
    }
}
