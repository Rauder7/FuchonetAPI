using Domain.Constans;
namespace Domain.ValueObjects;
public class Sector : ValueObject
{
    public string Value { get; private init; }


    private Sector(string value)
    {
        Value = value;
    }
    public static Result<Sector> Create(string value)
    {
        value = value.Trim().ToUpper();
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Sector>(DomainErrors.Customer.InvalidSector);
        if (!AllowedSectors.Names.Contains(value))
            return Result.Failure<Sector>(DomainErrors.Customer.SectorNotNotFoundInAllowedSectors);

        return Result.Success<Sector>(new Sector(value));
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
