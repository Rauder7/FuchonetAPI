using Domain.Constans;

namespace Domain.ValueObjects;
public class Modo : ValueObject
{
    public ModoName ModoName { get; private set; }
    public string Description { get; private set; }
    public Modo(ModoName modoName, string description)
    {
        ModoName = modoName;
        Description = description;
    }
    public static Result<Modo> Create(ModoName modoName, string description)
    {
        //validaciones
        return Result.Success<Modo>(new Modo(modoName, description));
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return ModoName;
        yield return Description;
    }
}
