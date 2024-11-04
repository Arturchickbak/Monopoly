using System;
using System.Collections.Generic;
using System.Linq;

public class Pallet
{
    public Guid Id { get; } = Guid.NewGuid();
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public List<Box> Boxes { get; set; } = new List<Box>();

    public Pallet(double width, double height, double depth)
    {
        Width = width;
        Height = height;
        Depth = depth;
    }

    public double Weight => Boxes.Sum(b => b.Weight) + 30.0;

    public double Volume => Boxes.Sum(b => b.Volume) + (Width * Height * Depth);

    public DateTime? ExpirationDate => Boxes.Min(b => b.ExpirationDate);

    public bool CanContain(Box box) => box.Width <= Width && box.Depth <= Depth;
}
