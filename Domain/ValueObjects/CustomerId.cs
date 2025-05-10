namespace Domain.ValueObjects;

public class CustomerId : ValueObject
{
    public Guid Value { get; private init; }
    private CustomerId(Guid value)
    {
        Value = value;
    }
    //metodo factoria para crear un nuevo customterId
    public static CustomerId CreateUnique()
    {
        return new CustomerId(Guid.NewGuid());
    }
    public static Result<CustomerId> Create(Guid value)
    {
        //add validation
        return Result.Success<CustomerId>(new CustomerId(value));
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator Guid(CustomerId customerId) => customerId.Value;
}

