using Newtonsoft.Json;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CustomSysWeb.Models
{
    public class Cliente
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("nome")]
        public string? Nome { get; set; }

        [JsonProperty("cgc")]
        public string? Cgc { get; set; }

        [JsonProperty("sexo")]
        public string? Sexo { get; set; }

        [JsonProperty("endereco")]
        public Enderecos? Endereco { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("telefone")]
        public string? Telefone { get; set; }

        [JsonProperty("obs")]
        public string? Obs { get; set; }

        [JsonProperty("excluido")]
        public bool Excluido { get; set; }

        [JsonProperty("tipoCliente")]
        public TipoCliente? TipoCliente { get; set; }

        [JsonProperty("situacaoCliente")]
        public SituacaoCliente? SituacaoCliente { get; set; }

        [JsonProperty("nacionalidade")]
        public Nacionalidades? Nacionalidade { get; set; }

        [JsonProperty("dtNasc")]
        public DateTime DtNasc { get; set; }

        [JsonProperty("dtCad")]
        public DateTime DtCad { get; set; }

        [JsonProperty("cdUsuCad")]
        public int CdUsuCad { get; set; }

        [JsonProperty("dtAlt")]
        public DateTime? DtAlt { get; set; }

        [JsonProperty("cdUsualt")]
        public int? CdUsualt { get; set; }

        public string? SexoDescricao 
        {
            get
            {
                if (Sexo == "M")
                    return "Masculino";
                else if (Sexo == "F")
                    return "Feminino";
                else if (Sexo == "O")
                    return "Outros";
                else
                    return "Desconhecido";
            }
        }

        public class Root
        {
            public bool IsSucces { get; set; }
            public string Status { get; set; }
            public List<Cliente> Data { get; set; }
        }

    }

    public static class ClienteExtension 
    {
        public static string ToJson(this Cliente cliente) 
        {
            string json = string.Empty;

            try
            {
                json = "{ \"id\": \"" + (string.IsNullOrEmpty(cliente.Id) ? Util.RemoveCaracteresEspeciais(cliente.Cgc) : cliente.Id) + "\", " +
                       " \"nome\": \"" + cliente.Nome + "\", " +
                       " \"cgc\": \"" + cliente.Cgc + "\", " +
                       " \"sexo\": \"" + cliente.Sexo + "\", " +
                       " \"cdEndereco\": \"" + cliente.Endereco.Id + "\", " +
                       " \"email\": \"" + cliente.Email + "\", " +
                       " \"telefone\": \"" + Util.RemoveCaracteresEspeciais(cliente.Telefone) + "\", " +
                       " \"obs\": \"" + cliente.Obs + "\", " +
                       " \"excluido\": " + cliente.Excluido.ToString().ToLower() + ", " +
                       " \"cdTipoCliente\": \"" + cliente.TipoCliente.Id + "\", " +
                       " \"cdSituacao\": \"" + cliente.SituacaoCliente.Id + "\", " +
                       " \"nacionalidade\": \"" + cliente.Nacionalidade.Id + "\", " +
                       " \"dtNasc\": \"" + cliente.DtNasc.ToString("yyyy-MM-ddTHH:mm:ss") + "\", " +
                       " \"dtCad\": \"" + (cliente.DtCad == DateTime.MinValue ? DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss") : cliente.DtCad.ToString("yyyy-MM-ddTHH:mm:ss"))  + "\", " +
                       " \"cdUsuCad\": \"" + (cliente.CdUsuCad == 0 ? "1" : cliente.CdUsuCad) + "\", " +
                       " \"dtAlt\": \"" + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss") + "\", " +
                       " \"cdUsualt\": \"1\"" +
                       "}";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao converter a classe cliente para json: " + ex.Message);
            }

            return json;
        }
    }
}
