namespace Domain.ValueObjects;
public class LineId : ValueObject
{
    public Guid Value { get; private init; }
    private LineId(Guid value)
    {
        Value = value;
    }
    //metodo factoria para crear un nuevo lineId
    public static LineId CreateUnique()
    {
        return new LineId(Guid.NewGuid());
    }
    public static Result<LineId> Create(Guid value)
    {
        //add validation
        return Result.Success<LineId>(new LineId(value));
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator Guid(LineId lineId) => lineId.Value;
}