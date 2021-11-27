using DomainValidation.Validation;
using Hotel_Passagem.Models;
using Hotel_Passagem.Validations.ClienteValidation;

namespace Hotel_Passagem.Validations
{
    public class ClienteValidations : Validator<Cliente>
    {
        public ClienteValidations()
        {
            Add("NomeVazio", new Rule<Cliente>(new NomeVazio(), "Campo nome incoretto"));
            Add("CpfIncorreto", new Rule<Cliente>(new CpfIncorreto(), "Campo CPF incorreto"));
        }
    }
}
