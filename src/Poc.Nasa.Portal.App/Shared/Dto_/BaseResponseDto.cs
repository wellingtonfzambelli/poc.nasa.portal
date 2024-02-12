using FluentValidation.Results;

namespace Poc.Nasa.Portal.App.Shared;

public abstract class BaseResponseDto
{
    protected IList<ErrorResponse> Errors { get; private set; }

    public BaseResponseDto() =>
        Errors = new List<ErrorResponse>();

    public void AddErrorValidationResult(ValidationResult validation)
    {
        foreach (ValidationFailure item in validation.Errors)
            Errors.Add(new ErrorResponse(item.PropertyName, item.ErrorMessage));
    }

    public void SetError(ErrorResponse error) =>
        Errors.Add(error);

    public void SetErrors(IList<ErrorResponse> errors)
    {
        foreach (ErrorResponse error in errors)
            Errors.Add(error);
    }

    public bool IsValid() =>
        !Errors.Any();

    public IList<ErrorResponse> GetErrors() =>
        Errors;
}

public sealed class ErrorResponse
{
    public string Code { get; private set; }
    public string Message { get; private set; }

    public ErrorResponse(string code, string message)
    {
        Code = code;
        Message = message;
    }
}