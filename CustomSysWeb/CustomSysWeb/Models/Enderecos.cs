namespace CustomSysWeb.Models
{
    public class Enderecos
    {
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
        public string? Cep { get; set; }

        public string? EnderecoCompleto 
        {
            get 
            {
                return Logradouro + ", N°" + Numero + ", " + Bairro + ", " + Cidade + ", " + UF + ", CEP:" + Cep;
            }
        }
    }
}
