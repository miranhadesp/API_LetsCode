using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.VendaPassagemValidation
{
    public class IdPassagemNullOrWhiteSpace : ISpecification<VendaPassagem>
    {
        public bool IsSatisfiedBy(VendaPassagem entity)
        {
            return entity.IdPassagem != null;
        }
    }
}


