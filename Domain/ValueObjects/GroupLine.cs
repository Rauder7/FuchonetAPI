using Domain.Constans;

namespace Domain.ValueObjects;
public class GroupLine : ValueObject
{
    public GroupName GroupName { get; private set; }
    public int DayOfCut { get; private set; }


    public GroupLine(GroupName groupName, int dayOfCut)
    {

        GroupName = groupName;
        DayOfCut = dayOfCut;
    }
    public static Result<GroupLine> Create(GroupName groupName, int dayOfCut)
    {
        //validaciones
        if (!IsValidDate(groupName, dayOfCut))
            return Result.Failure<GroupLine>(DomainErrors.Customer.InvalidDayOfCut);
        return Result.Success<GroupLine>(new GroupLine(groupName, dayOfCut));
    }

    private static bool IsValidDate(GroupName groupName, int dayOfCut)
    {
        return groupName switch
        {
            GroupName.GRUPO01 => dayOfCut >= 1 && dayOfCut <= 7,
            GroupName.GRUPO08 => dayOfCut >= 8 && dayOfCut <= 14,
            GroupName.GRUPO15 => dayOfCut >= 15 && dayOfCut <= 21,
            GroupName.GRUPO22 => dayOfCut >= 22 && dayOfCut <= 31,
            _ => true
        };
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return GroupName;
        yield return DayOfCut;
    }
}
