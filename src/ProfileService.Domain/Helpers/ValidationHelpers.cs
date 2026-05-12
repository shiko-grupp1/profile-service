using ProfileService.Domain.Exceptions.Custom;

namespace ProfileService.Domain.Helpers;

public static class ValidationHelpers
{
    public static string ValidateString(string value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationDomainException($"{fieldName} is required");
       
        value = value.Trim();

        if (value.Length > 100)
            throw new ValidationDomainException($"{fieldName} cannot exceed 100 characters.");

        return value;
    }

    public static string? ValidateOptionalString(string? value, string fieldName, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        value = value.Trim();

        if (value.Length > maxLength)
            throw new ValidationDomainException($"{fieldName} cannot exceed {maxLength} characters.");

        return value;
    }

    public static bool IsValidUrl(string value)
    {
        return Uri.TryCreate(value, UriKind.Absolute, out Uri? uri)
            && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }

    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        int digitCount = phoneNumber.Count(char.IsDigit);
        return digitCount >= 7;
    }

}
