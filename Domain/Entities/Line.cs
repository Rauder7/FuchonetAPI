using Domain.ValueObjects;

namespace Domain.Entities;
public class Line : Entity<LineId>
{
    public Ip CurrentIp { get; private set; }
    public Ip OldIp { get; private set; }
    public bool IsIpUpdated { get; set; }
    public Address Address { get; private set; }
    public LineDetails LineDetails { get; private set; }
    public GroupLine GroupLine { get; private set; }
    public Plan Plan { get; private set; }
    public decimal Discount { get; private set; }
    public Modo Modo { get; private set; }
    public DateOnly InstallationDate { get; private set; }

}
