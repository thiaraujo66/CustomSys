namespace CustomSysApi.Models.Error
{
    public class ClienteValidationFailure
    {
        public ClienteValidationFailure(string propertyName, string errorMessage) 
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
