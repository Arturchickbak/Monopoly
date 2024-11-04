using System;

public class Box
{
    public Guid Id { get; } = Guid.NewGuid();
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double Weight { get; set; }
    public DateTime? ExpirationDate { get; private set; }
    public DateTime? ProductionDate { get; private set; }

    public Box(double width, double height, double depth, double weight, DateTime? expirationDate = null, DateTime? productionDate = null)
    {
        Width = width;
        Height = height;
        Depth = depth;
        Weight = weight;
        SetDates(expirationDate, productionDate);
    }

    public void SetDates(DateTime? expirationDate, DateTime? productionDate)
    {
        if (expirationDate.HasValue)
        {
            ExpirationDate = expirationDate.Value.Date;
        }
        else if (productionDate.HasValue)
        {
            ProductionDate = productionDate.Value.Date;
            ExpirationDate = ProductionDate?.AddDays(100);
        }
        else
        {
            throw new ArgumentException("Either expiration date or production date must be provided.");
        }
    }

    public double Volume => Width * Height * Depth;
}
