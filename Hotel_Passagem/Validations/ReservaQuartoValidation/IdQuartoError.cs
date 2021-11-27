using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.ReservaQuartoValidation
{
    public class IdQuartoError: ISpecification <ReservaQuarto>
    {
        public bool IsSatisfiedBy(ReservaQuarto entity)
        {
            return entity.IdQuarto != null;
        }

    }
}

