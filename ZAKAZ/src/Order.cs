class Order
{
    static int idCounter;
    public readonly int Id = ++idCounter;
    public int TableId { set; get; }
    public Dish[] Dishes = Array.Empty<Dish>();
    public string Commentary { set; get; }
    public string OpenTime { set; get; }
    public int WaiterId { set; get; }
    public string? CloseTime { set; get; }
    public float GrossTotal { set; get; }

    public Order(in int tableId, in string commentary, in string openTime, in int waiterId)
    {
        TableId = tableId;
        Commentary = commentary;
        OpenTime = openTime;
        WaiterId = waiterId;
        GrossTotal = 0;
    }

    public void Redact(in Dish[] menu) => OrderEditor.HandleOrderRedaction(this, menu);

    public void CloseOrder()
    {
        if (CloseTime != null)
        {
            Console.WriteLine("Заказ уже закрыт.");
            return;
        }

        CloseTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        GrossTotal = Dishes.Sum(dish => dish.Price);

        Console.WriteLine("Заказ успешно закрыт.");
    }

    public void PrintReceipt()
    {
        if (CloseTime == null)
        {
            Console.WriteLine("Чек нельзя вывести, пока заказ не закрыт.");
            return;
        }

        Console.WriteLine("\n=== ЧЕК ===");
        Console.WriteLine($"ID заказа: {Id}");
        Console.WriteLine($"ID стола: {TableId}");
        Console.WriteLine($"Официант ID: {WaiterId}");
        Console.WriteLine($"Время принятия: {OpenTime}");
        Console.WriteLine($"Время закрытия: {CloseTime}");
        Console.WriteLine("\nБлюда:");

        foreach (Dish dish in Dishes)
        {
            Console.WriteLine($"  - {dish.Name}: {dish.Price:F2} ₽");
        }

        Console.WriteLine($"\nИтоговая стоимость: {GrossTotal:F2} ₽");
        Console.WriteLine("===================");
    }
}