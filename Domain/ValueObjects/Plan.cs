namespace Domain.ValueObjects;
public class Plan
{
    public PlanName PlanName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Plan(PlanName planName, string description, decimal price)
    {
        PlanName = planName;
        Description = description;
        Price = price;
    }

    public Plan Create(PlanName planName, string description, decimal price)
    {
        if (string.IsNullOrWhiteSpace(planName))
            throw new ArgumentException("Name cannot be empty", nameof(planName));
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty", nameof(description));
        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero", nameof(price));
        return new Plan(planName, description, price);
    }
}
