using DomainValidation.Validation;
using Hotel_Passagem.Models;
using Hotel_Passagem.Validations.QuartoValidation;

namespace Hotel_Passagem.Validations
{
    public class QuartoValidations : Validator<Quarto>
    {
        public QuartoValidations()
        {
            Add("InfoQuarto", new Rule<Quarto>(new InfoQuartoValidation(), "Erro no campo info quarto"));
            Add("Tipo", new Rule<Quarto>(new TipoValidation(), "Erro no campo tipo"));        
        }
    }
}

