using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.PassagemValidation
{
    public class PrecoNullOrWhiterSpace : ISpecification<Passagem>
    {
        public bool IsSatisfiedBy(Passagem entity)
        {
            return entity.Valor > 0 && entity.Valor != null;
        }
    }
}


