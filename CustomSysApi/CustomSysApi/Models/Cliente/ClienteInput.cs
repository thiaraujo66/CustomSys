using Domain.Entities;

namespace CustomSysApi.Models.Cliente
{
    public class ClienteInput
    {
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public string? Cgc { get; set; }
        public string? Sexo { get; set; }
        public int CdEndereco { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Obs { get; set; }
        public bool Excluido { get; set; }
        public int CdTipoCliente { get; set; }
        public int CdSituacao { get; set; }
        public int Nacionalidade { get; set; }
        public DateTime DtNasc { get; set; }
        public DateTime DtCad { get; set; }
        public int CdUsuCad { get; set; }
        public DateTime? DtAlt { get; set; }
        public int? CdUsualt { get; set; }

        public Clientes ConvertInputToClientes(ClienteInput input) 
        {
            try
            {
                Clientes cli = new Clientes();

                cli.Clid = input.Id;
                cli.Clnome = input.Nome;
                cli.Clcgc = input.Cgc;
                cli.Clsexo = input.Sexo;
                cli.Clcdendereco = input.CdEndereco;
                cli.Clemail = input.Email;
                cli.Cltelefone = input.Telefone;
                cli.Clobs = input.Obs;
                cli.Clexcluido = input.Excluido;
                cli.Clcdtipocliente = input.CdTipoCliente;
                cli.Clcdsituacao = input.CdSituacao;
                cli.Clnacionalidade = input.Nacionalidade;
                cli.Cldtnasc = input.DtNasc;
                cli.Cldtcad = input.DtCad;
                cli.Clcdusucad = input.CdUsuCad;
                cli.Cldtalt = input.DtAlt;
                cli.Clcdusualt = input.CdUsualt;

                return cli;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
