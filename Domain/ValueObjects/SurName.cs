namespace Domain.ValueObjects;

public class SurName : ValueObject
{
    public string Value { get; private init; }
    private SurName(string value)
    {
        Value = value;
    }
    public static Result<SurName> Create(string value)
    {
        //add validation
        return Result.Success<SurName>(new SurName(value));
    }
    public static implicit operator string(SurName surName) => surName.Value;


    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}

