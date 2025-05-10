using System.Text.RegularExpressions;

namespace Domain.ValueObjects;
public class Ip : ValueObject
{
    public string Value { get; private init; }
    public Ip(string value)
    {
        Value = value;
    }
    public static Result<Ip> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            Result.Failure<Ip>(DomainErrors.Customer.InvalidIp);
        if (Validate(value).IsFailure)
            return Result.Failure<Ip>(DomainErrors.Customer.InvalidIp);
        return Result.Success(new Ip(value));
    }
    private static Result Validate(string ip)
    {
        var regex = new Regex(@"^192\.168\.\d\.(2[0-4]\d|25[0-4]|[3-9]\d|\d)$");
        if (!regex.IsMatch(ip))
        {
            return Result.Failure(DomainErrors.Customer.InvalidIp);
        }
        return Result.Success();
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
