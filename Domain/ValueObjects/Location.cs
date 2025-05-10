namespace Domain.ValueObjects;
public class Location : ValueObject
{
    public double Latitude { get; }
    public double Longitude { get; }

    private Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Result<Location> Create(double latitude, double longitude)
    {
        if (latitude is < -90 or > 90)
            return Result.Failure<Location>(DomainErrors.Customer.InvalidLatitud);

        if (longitude is < -180 or > 180)
            return Result.Failure<Location>(DomainErrors.Customer.InvalidLongitud);

        return Result.Success(new Location(latitude, longitude));
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Latitude;
        yield return Longitude;
    }
}
