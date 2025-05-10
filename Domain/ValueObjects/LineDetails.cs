using Domain.Constans;

namespace Domain.ValueObjects;
public class LineDetails
{
    public RouterBrand RouterBrand { get; set; }
    public bool IsPingAllowed { get; set; }
    public bool IsRouterAccessible { get; set; }
    public bool IsPlexActive { get; set; }
    public bool IsIptvActive { get; set; }
    public bool IsIpBlokedInWinbox { get; set; }
    public DateTime LastBloquedDateCurrentIp { get; set; }


}
