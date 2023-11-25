using Domain.Entities;

namespace CustomSysApi.Models.Response.Cliente
{
    public class ClienteGetByIdResponse
    {
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public string? Cgc { get; set; }
        public string? Sexo { get; set; }
        public ClienteEnderecoByIdResponse? Endereco { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Obs { get; set; }
        public bool Excluido { get; set; }
        public ClienteTipoClienteByIdResponse? TipoCliente { get; set; }
        public ClienteSituacaoClienteByIdResponse? SituacaoCliente { get; set; }
        public ClienteNacionalidadeByIdResponse? Nacionalidade { get; set; }
        public DateTime DtNasc { get; set; }
        public DateTime DtCad { get; set; }
        public int CdUsuCad { get; set; }
        public DateTime? DtAlt { get; set; }
        public int? CdUsualt { get; set; }

        public List<ClienteGetByIdResponse> ClienteToClienteGetByIdResponse(List<Clientes> clientes) 
        {
            try
            {
                List<ClienteGetByIdResponse> clientesResponse = new List<ClienteGetByIdResponse>();

                foreach (var cliente in clientes)
                {
                    ClienteGetByIdResponse clienteResponse = new ClienteGetByIdResponse();

                    clienteResponse.Id = cliente.Clid;
                    clienteResponse.Nome = cliente.Clnome;
                    clienteResponse.Cgc = cliente.Clcgc;
                    clienteResponse.Sexo = cliente.Clsexo;
                    clienteResponse.Endereco = ReturnEndereco(cliente.ClcdenderecoNavigation);
                    clienteResponse.Email = cliente.Clemail;
                    clienteResponse.Telefone = cliente.Cltelefone;
                    clienteResponse.Obs = cliente.Clobs;
                    clienteResponse.Excluido = cliente.Clexcluido;
                    clienteResponse.TipoCliente = ReturnTipoCliente(cliente.ClcdtipoclienteNavigation);
                    clienteResponse.SituacaoCliente = ReturnSituacaoCliente(cliente.ClcdsituacaoNavigation);
                    clienteResponse.Nacionalidade = ReturnNacionalidade(cliente.ClnacionalidadeNavigation);
                    clienteResponse.DtNasc = cliente.Cldtnasc;
                    clienteResponse.DtCad = cliente.Cldtcad;
                    clienteResponse.CdUsuCad = cliente.Clcdusucad;
                    clienteResponse.DtAlt = cliente.Cldtalt;
                    clienteResponse.CdUsualt = cliente.Clcdusualt;

                    clientesResponse.Add(clienteResponse);
                }

                return clientesResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao converter para a classe de ClienteGetByIdResponse: " + ex.Message);
            }
        }

        private ClienteEnderecoByIdResponse ReturnEndereco(Enderecos endereco) 
        {
            try
            {
                ClienteEnderecoByIdResponse end = new ClienteEnderecoByIdResponse();

                end.Id = endereco.Edid;
                end.Logradouro = endereco.Edlogradouro;
                end.Numero = endereco.Ednumero;
                end.Bairro = endereco.Edbairro;
                end.Cidade = endereco.Edcidade;
                end.UF = endereco.Eduf;
                end.Cep = endereco.Edcep;

                return end;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao tentar retornar o endereço: " + ex.Message);
            }
        }
        private ClienteTipoClienteByIdResponse ReturnTipoCliente(TipoCliente tipoCliente)
        {
            try
            {
                ClienteTipoClienteByIdResponse tp = new ClienteTipoClienteByIdResponse();

                tp.Id = tipoCliente.Tcid;
                tp.Nome = tipoCliente.Tcnome;
                tp.Descricao = tipoCliente.Tcdescricao;

                return tp;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar o tipo de cliente para a classe de ClienteResponse Get by id: " + ex.Message);
            }
        }

        private ClienteSituacaoClienteByIdResponse ReturnSituacaoCliente(SituacaoCliente situacaoCliente) 
        {
            try
            {
                ClienteSituacaoClienteByIdResponse st = new ClienteSituacaoClienteByIdResponse();

                st.Id = situacaoCliente.Scid;
                st.Nome = situacaoCliente.Scnome;
                st.Descricao = situacaoCliente.Scdescricao;

                return st;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar a Situação do Cliente para a classe de ClienteResponse Get by id: " + ex.Message);
            }
        }

        private ClienteNacionalidadeByIdResponse ReturnNacionalidade(Nacionalidades nacionalidades) 
        {
            try
            {
                ClienteNacionalidadeByIdResponse nacio = new ClienteNacionalidadeByIdResponse();

                nacio.Id = nacionalidades.Ncid;
                nacio.Sigla = nacionalidades.Ncsigla;
                nacio.Nome = nacionalidades.Ncnome;

                return nacio;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar a Nacionalidade para a classe de ClienteResponse Get by id " + ex.Message);
            }
        }

    }

    public class ClienteEnderecoByIdResponse 
    {
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
        public string? Cep { get; set; }

    }

    public class ClienteTipoClienteByIdResponse 
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set;}
    }

    public class ClienteSituacaoClienteByIdResponse 
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set;}
    }

    public class ClienteNacionalidadeByIdResponse 
    { 
        public int Id { get; set; }
        public string? Sigla { get; set; }
        public string? Nome { get; set; }
    }
}
