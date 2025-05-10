using System.Text.RegularExpressions;

namespace Domain.ValueObjects;
public sealed class Dni : ValueObject
{
    public string Value { get; private init; }
    private Dni(string value)
    {
        Value = value;
    }
    public static Result<Dni> Create(string value)
    {
        var regExp = @"^\d{8}$";
        bool validate = Regex.IsMatch(value, regExp);
        if (!validate)
        {
            return Result.Failure<Dni>(DomainErrors.Customer.InvalidDni);
        }
        //add validation
        return Result.Success(new Dni(value));
    }

    //comvierte implicitamente el dni a un string
    public static implicit operator string(Dni dni) => dni.Value;
    public override string ToString()
    {
        return Value;
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

}