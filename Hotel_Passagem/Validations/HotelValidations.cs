using DomainValidation.Validation;
using Hotel_Passagem.Models;
using Hotel_Passagem.Validations.HotelValidation;

namespace Hotel_Passagem.Validations
{
    public class HotelValidations : Validator<Hotel>
    {
        public HotelValidations()
        {
            Add("NomeNullOrWhiteSpace", new Rule<Hotel>(new NomeNullOrWhiteSpace(), "Campo nome em branco"));
            Add("CheckInSize", new Rule<Hotel>(new CheckInSizeValidation(), "Data do check in incorreta"));
            Add("CheckOutSize", new Rule<Hotel>(new CheckOutSizeValidation(), "Data do check out incorreta"));
        }
    }
}
