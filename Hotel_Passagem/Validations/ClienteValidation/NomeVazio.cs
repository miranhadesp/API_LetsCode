using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.ClienteValidation
{
    public class NomeVazio : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Nome);
        }
    }
}
