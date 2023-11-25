namespace CustomSysApi.Models.Response.Padrao
{
    public class BaseReturn<T>
    {
        /// <summary>
        /// Informa se a requisição foi feita com sucesso
        /// </summary>
        public bool IsSucces { get; set; }

        /// <summary>
        /// Informa o status da requisição
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Informa o Retorno da Requisição
        /// </summary>
        public List<T>? Data { get; set; }
    }
}
