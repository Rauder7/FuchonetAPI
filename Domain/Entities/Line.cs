using Domain.Constans;
using Domain.ValueObjects;

namespace Domain.Entities;
public class Line : Entity<LineId>
{
    public Ip CurrentIp { get; private set; }
    public Ip OldIp { get; private set; }
    public Address Address { get; private set; }
    public LineDetails LineDetails { get; private set; }
    public FechaCorte FechaCorte { get; private set; }
    public Plan Plan { get; private set; }
    public decimal Descount { get; private set; }
    public bool IsActive { get; private set; }
    public Modo Modo { get; private set; }






}
