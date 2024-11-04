using System;
using System.Collections.Generic;
using System.Linq;

public class WarehouseService
{
    public List<Pallet> Pallets { get; set; } = new List<Pallet>();

    // Метод для группировки паллет по сроку годности и сортировки по весу
    public IEnumerable<IGrouping<DateTime?, Pallet>> GroupPalletsByExpirationDate()
    {
        return Pallets
            .Where(p => p.ExpirationDate.HasValue)
            .GroupBy(p => p.ExpirationDate)
            .OrderBy(g => g.Key);
    }

    // Метод для получения топ паллет по сроку годности коробок
    public IEnumerable<Pallet> GetTopPalletsByBoxExpiration(int count = 3)
    {
        return Pallets
            .Where(p => p.Boxes.Any())
            .OrderByDescending(p => p.Boxes.Max(b => b.ExpirationDate))
            .Take(count)
            .OrderBy(p => p.Volume);
    }
}
