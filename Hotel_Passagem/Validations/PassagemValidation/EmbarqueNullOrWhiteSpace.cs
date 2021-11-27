using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.PassagemValidation
{
    public class EmbarqueNullOrWhiteSpace : ISpecification<Passagem>
    {
        public bool IsSatisfiedBy(Passagem entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Embarque);
        }

    }
}


