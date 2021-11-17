using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations.HotelValidation
{
    public class NomeNullOrWhiteSpace : ISpecification<Hotel>
    {
        public bool IsSatisfiedBy(Hotel entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Nome);
        }
    }
}
