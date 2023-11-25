using FluentValidation;

namespace CustomSysApi.Models.Cliente
{
    public class ClienteInputValidator : AbstractValidator<ClienteInput>
    {
        public ClienteInputValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Nome).NotEmpty();
            RuleFor(c => c.Cgc).NotEmpty();
            RuleFor(c => c.Sexo).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.CdEndereco).NotEmpty();
            RuleFor(c => c.CdTipoCliente).NotEmpty();
            RuleFor(c => c.CdSituacao).NotEmpty();
            RuleFor(c => c.Nacionalidade).NotEmpty();
            RuleFor(c => c.DtNasc).NotEmpty();
            RuleFor(c => c.DtCad).NotEmpty();
            RuleFor(c => c.CdUsuCad).NotEmpty();
        }
    }
}
