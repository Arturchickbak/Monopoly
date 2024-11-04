using System;

public class Program
{
    public static void Main()
    {
        var service = new WarehouseService();

        // Пример генерации данных для теста
        var box1 = new Box(0.5, 0.3, 0.4, 2, productionDate: DateTime.Today.AddDays(-50));
        var box2 = new Box(0.4, 0.4, 0.4, 3, expirationDate: DateTime.Today.AddDays(30));
        var box3 = new Box(0.3, 0.3, 0.3, 1, productionDate: DateTime.Today.AddDays(-20));

        var pallet1 = new Pallet(1, 1, 1);
        pallet1.Boxes.Add(box1);
        pallet1.Boxes.Add(box2);

        var pallet2 = new Pallet(1.5, 1, 1);
        pallet2.Boxes.Add(box3);

        service.Pallets.Add(pallet1);
        service.Pallets.Add(pallet2);

        // Группировка паллет по сроку годности и вывод результата
        Console.WriteLine("Паллеты, сгруппированные по сроку годности:");
        foreach (var group in service.GroupPalletsByExpirationDate())
        {
            Console.WriteLine($"Срок годности: {group.Key?.ToShortDateString() ?? "Нет данных"}");
            foreach (var pallet in group)
            {
                Console.WriteLine($" - Паллет ID: {pallet.Id}, Вес: {pallet.Weight} кг");
            }
        }

        // Вывод паллет с наибольшим сроком годности коробок, отсортированных по объему
        Console.WriteLine("\n3 паллеты с наибольшим сроком годности:");
        foreach (var pallet in service.GetTopPalletsByBoxExpiration())
        {
            Console.WriteLine($"Паллет ID: {pallet.Id}, Объем: {pallet.Volume} куб.м, Наибольший срок годности коробки: {pallet.ExpirationDate?.ToShortDateString()}");
        }
    }
}
