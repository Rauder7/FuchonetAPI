using Domain.ValueObjects;
namespace Domain.Entities;

public class Customer : AggregateRoot<CustomerId>
{
    public Name Name { get; private set; }
    public SurName SurName { get; private set; }
    public Dni Dni { get; private set; }
    private List<Phone> _phones = new();
    public IReadOnlyCollection<Phone> Phones => _phones.AsReadOnly();

    private Customer(CustomerId id, Name name, SurName surName, Dni dni) : base(id)
    {
        Name = name;
        SurName = surName;
        Dni = dni;
    }

    public static Result<Customer> Create(CustomerId customerId, Name name, SurName surName, Dni dni)
    {
        //add validation

        return Result.Success<Customer>(new Customer(customerId, name, surName, dni));
    }
    public static Result<Customer> Create(Name name, SurName surName, Dni dni, List<Phone>? phones = null)
    {

        return Result.Success<Customer>(new Customer(CustomerId.CreateUnique(), name, surName, dni));
    }
    public string GetFullName()
    {
        return $"{Name} {SurName}";
    }
    public Result UpdateName(Name name)
    {
        if (name is null)
            return Result.Failure(DomainErrors.Customer.InvalidName);
        Name = name;
        return Result.Success();
    }
    public Result UpdateSurName(SurName surName)
    {
        if (surName is null)
            return Result.Failure(DomainErrors.Customer.InvalidName);
        SurName = surName;
        return Result.Success();
    }
    public Result UpdateDni(Dni dni)
    {
        if (dni is null)
            return Result.Failure(DomainErrors.Customer.InvalidDni);
        Dni = dni;
        return Result.Success();
    }

    public Result AddPhone(Phone phone)
    {
        if (phone is null)
            return Result.Failure(DomainErrors.Customer.InvalidPhoneNumber);

        if (_phones.Any(p => p.Number == phone.Number))
            return Result.Failure(DomainErrors.Customer.PhoneAlreadyExists);

        _phones.Add(phone);
        return Result.Success();
    }
    public Result SetPhoneActive(Phone phone)
    {
        if (!_phones.Any())
            return Result.Failure(DomainErrors.Customer.NoPhonesRegistered);

        if (!_phones.Any(p => p.Number == phone.Number))
            return Result.Failure(DomainErrors.Customer.PhoneNotFound);

        _phones = _phones
            .Select(p => Phone.Create(p.Number, p.Number == phone.Number, p.CountryCode).Value)
            .ToList();

        return Result.Success();
    }
    public Result DeletePhone(Phone phone)
    {
        if (!_phones.Any())
            return Result.Failure(DomainErrors.Customer.NoPhonesRegistered);
        if (!_phones.Any(p => p.Number == phone.Number))
            return Result.Failure(DomainErrors.Customer.PhoneNotFound);
        _phones.Remove(phone);
        return Result.Success();
    }
}

