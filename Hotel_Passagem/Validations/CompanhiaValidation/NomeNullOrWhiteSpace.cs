using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.CompanhiaValidation
{
    public class NomeNullOrWhiteSpace : ISpecification<Companhia>
    { 
        public bool IsSatisfiedBy(Companhia entity)
        {
        return !string.IsNullOrWhiteSpace(entity.Nome);
        }
    }   
}
