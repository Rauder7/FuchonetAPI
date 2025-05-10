
namespace Domain.ValueObjects;
public class Address : ValueObject
{
    public string HomeAddress { get; private init; }
    public Sector Sector { get; private init; }
    public string Comment { get; private init; }
    public Location Location { get; private init; }

    public Address(string homeAddress, Sector sector, string? comment = null, Location? location = null)
    {
        HomeAddress = homeAddress;
        Sector = sector;
        Comment = comment;
        Location = location;
    }
    public static Result<Address> Create(string homeAddress, Sector sector, string? comment = null, Location? location = null)
    {
        if (string.IsNullOrWhiteSpace(homeAddress))
            return Result.Failure<Address>(DomainErrors.Customer.InvalidHomeAddress);
        if (sector is null)
            return Result.Failure<Address>(DomainErrors.Customer.InvalidSector);
        return Result.Success(new Address(homeAddress, sector, comment, location));
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return HomeAddress;
        yield return Sector;
        yield return Comment;
        yield return Location;
    }
}
