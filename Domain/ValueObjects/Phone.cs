using System.Text.RegularExpressions;

namespace Domain.ValueObjects;
public class Phone : ValueObject
{
    public string Number { get; private init; }
    public string CountryCode { get; private init; }
    public bool Status { get; private set; }
    private static readonly Dictionary<string, (Regex Regex, string Prefix)> CountryRules = new()
    {
        { "PE", (new Regex(@"^\+519\d{8}$"), "+51") },
        { "ES", (new Regex(@"^\+34[67]\d{8}$"), "+34") }
        // Agregar mas si es necesario
    };

    private Phone(string number, bool status, string countryCode)
    {
        Number = number;
        CountryCode = countryCode;
        Status = status;
    }
    public static Result<Phone> Create(string number, bool status, string countryCode = "PE")
    {
        var validateResult = Validate(number, countryCode);


        if (validateResult.IsFailure)
        {
            return Result.Failure<Phone>(validateResult.Error);
        }

        return Result.Success<Phone>(new Phone(validateResult.Value, status, countryCode));
    }

    public static Result<string> Validate(string number, string countryCode)
    {
        if (string.IsNullOrWhiteSpace(number))
            return Result.Failure<string>(DomainErrors.Customer.InvalidPhoneNumber);

        if (!CountryRules.TryGetValue(countryCode, out var rule))
            return Result.Failure<string>(DomainErrors.Customer.InvalidCountryCode);

        var cleaned = Regex.Replace(number, @"[^\d+]", "");


        if (cleaned.StartsWith("+") && rule.Regex.IsMatch(cleaned))
            return Result.Success(cleaned);


        if (cleaned.StartsWith(rule.Prefix.TrimStart('+')))
        {
            var prefixed = "+" + cleaned;
            if (rule.Regex.IsMatch(prefixed))
                return Result.Success(prefixed);
        }


        var normalized = rule.Prefix + cleaned;
        if (!rule.Regex.IsMatch(normalized))
            return Result.Failure<string>(DomainErrors.Customer.InvalidPhoneNumber);

        return Result.Success(normalized);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Number;
        yield return CountryCode;
        yield return Status;
    }

    public static implicit operator string(Phone phone) => phone.Number;
    public void SetActive() => Status = true;
    public void SetInactive() => Status = false;

}