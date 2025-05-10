namespace Domain.ValueObjects;

public sealed class Name : ValueObject
{
    public string Value { get; private init; }
    private Name(string value)
    {
        Value = value;
    }
    public static Result<Name> Create(string value)
    {
        //add validation
        return Result.Success<Name>(new Name(value));
    }
    public static implicit operator string(Name name) => name.Value;
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}

