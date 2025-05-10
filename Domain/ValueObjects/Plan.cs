namespace Domain.ValueObjects;
public class Plan
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Plan(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public Plan Create(string name, string description, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty", nameof(description));
        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero", nameof(price));
        return new Plan(name, description, price);
    }
}
