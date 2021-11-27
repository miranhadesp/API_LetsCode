using DomainValidation.Validation;
using Hotel_Passagem.Models;
using Hotel_Passagem.Validations.PassagemValidation;

namespace Hotel_Passagem.Validations
{
    public class PassagemValidations : Validator<Passagem>
    {
        public PassagemValidations()
        {
            Add("DestinoNullOrWhiteSpace", new Rule<Passagem>(new DestinoNullOrWhiteSpace(), "Campo destino em branco"));
            Add("EmbarqueNullOrWhiteSpace", new Rule<Passagem>(new EmbarqueNullOrWhiteSpace(), "Campo embarque em branco"));
            Add("DatareservaNullOrWhiteSpace", new Rule<Passagem>(new DestinoNullOrWhiteSpace(), "Campo data está errado"));
            Add("PrecoNullOrWhiterSpace", new Rule<Passagem>(new PrecoNullOrWhiterSpace(), "Campo preco em branco"));

        }
    }
}



