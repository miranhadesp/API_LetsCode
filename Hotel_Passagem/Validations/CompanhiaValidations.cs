using DomainValidation.Validation;
using Hotel_Passagem.Models;
using Hotel_Passagem.Validations.CompanhiaValidation;

namespace Hotel_Passagem.Validations
{
    public class CompanhiaValidations : Validator<Companhia>
    {
        public CompanhiaValidations() 
        {
            Add("NomeNullOrWhiteSpace", new Rule<Companhia>(new NomeNullOrWhiteSpace(), "Campo nome em branco"));
        }

    }
}
