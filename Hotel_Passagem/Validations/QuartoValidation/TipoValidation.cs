using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.QuartoValidation
{
    public class TipoValidation : ISpecification<Quarto>
    {
        public bool IsSatisfiedBy(Quarto entity)
        {
            return entity.Tipo.Length <= 50;
        }
    }
}
