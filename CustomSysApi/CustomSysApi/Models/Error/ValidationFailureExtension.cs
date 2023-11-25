using FluentValidation.Results;

namespace CustomSysApi.Models.Error
{
    public static class ValidationFailureExtension
    {
        public static IList<ClienteValidationFailure> ToClienteValidationFailure(this IList<ValidationFailure> failures) 
        {
            return failures.Select(f => new ClienteValidationFailure(f.PropertyName, f.ErrorMessage)).ToList();
        }

    }
}
