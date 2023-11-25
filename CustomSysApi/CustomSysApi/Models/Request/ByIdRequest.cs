namespace CustomSysApi.Models.Request
{
    public class ByIdRequest<T>
    {
        public ByIdRequest() { }

        public T? Id { get; set; }
    }
}
