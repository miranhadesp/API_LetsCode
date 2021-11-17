using DomainValidation.Interfaces.Specification;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Validations
{
    public class CheckOutSizeValidation : ISpecification<Hotel>
    {
        public bool IsSatisfiedBy(Hotel entity)
        {
            return entity.CheckOut.Length <= 11;
        }
    }
}

