using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations
{
    public class CheckInSizeValidation : ISpecification<Hotel>
    {
        public bool IsSatisfiedBy(Hotel entity)
        {
            return entity.CheckIn.Length <= 11;
        }
    }
}

