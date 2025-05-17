using Domain.Constans;

namespace Domain.ValueObjects;
public record class LineDetails
{
    public RouterBrand? RouterBrand { get; init; }
    public bool? IsPingAllowed { get; init; }
    public bool? IsRouterAccessible { get; init; }
    public bool? IsPlexActive { get; init; }
    public bool? IsIptvActive { get; init; }
    public bool? IsIpBlokedInWinbox { get; init; }
    public DateTime? LastBloquedDateCurrentIp { get; init; }
    public DateTime? LastBloquedDateOldIp { get; init; }
    public bool? IsAntenna { get; init; }
}
