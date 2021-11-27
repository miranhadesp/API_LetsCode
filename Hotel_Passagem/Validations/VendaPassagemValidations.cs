using DomainValidation.Validation;
using Hotel_Passagem.Models;
using Hotel_Passagem.Validations.VendaPassagemValidation;


namespace Hotel_Passagem.Validations
{
    public class VendaPassagemValidations : Validator<VendaPassagem>
    {
        public VendaPassagemValidations()
        {
            Add("IdPassagemNullOrWhiteSpace", new Rule<VendaPassagem>(new IdPassagemNullOrWhiteSpace(), "Campo id passagem errado"));
            Add("IdClienteNullOrWhiteSpace", new Rule<VendaPassagem>(new IdClienteNullOrWhiteSpace(), "Campo id cliente errado"));
        }
    }
}
