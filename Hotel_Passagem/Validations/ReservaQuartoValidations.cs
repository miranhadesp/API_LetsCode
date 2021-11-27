using DomainValidation.Validation;
using Hotel_Passagem.Models;
using Hotel_Passagem.Validations.ReservaQuartoValidation;

namespace Hotel_Passagem.Validations
{
    public class ReservaQuartoValidations : Validator<ReservaQuarto>
    {
        public ReservaQuartoValidations()
        {
            Add("IdClienteError", new Rule<ReservaQuarto>(new IdClienteError(), "Campo id cliente errado"));
            Add("IdQuartoError", new Rule<ReservaQuarto>(new IdQuartoError(), "Campo id quarto errado"));
            Add("DataEntradaError", new Rule<ReservaQuarto>(new DataEntradaError(), "Campo data entrada errado"));
            Add("DataSaidaError", new Rule<ReservaQuarto>(new DataSaidaError(), "Campo data saida errado"));
        }
    }
}


