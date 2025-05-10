namespace Domain.Common;

public abstract class ValueObject : IEquatable<ValueObject>
{
    //metodo que implementaran todas los valueObject y dentro definiran cuales son las props que componen la estructura de valuOject
    //definir las props que se compararán

    public abstract IEnumerable<object> GetAtomicValues();

    public override int GetHashCode()
    {
        return GetAtomicValues().Aggregate(default(int), HashCode.Combine);
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && ValuesAreEquals(other);
    }
    private bool ValuesAreEquals(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEquals(other);
    }
}

