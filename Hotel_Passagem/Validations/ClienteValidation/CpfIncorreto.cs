using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations
{
    public class CpfIncorreto : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Cpf) && entity.Cpf.Length <= 12;
        }
    }
}
