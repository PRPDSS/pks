class Program
{
    static void Main()
    {
        // 1. Создание блюд
        Dish soup1 = new("Суп1", "Курица, картофель, морковь", "300 г", 150, Category.soup, 15, "Основное");
        Dish soup2 = new("Суп2", "Грибы, лук, сливки", "300 г", 180, Category.soup, 20, "Основное");
        Dish drink1 = new("Напиток1", "Яблочный сок", "250 мл", 50, Category.drink, 0, "Напиток");
        Dish dessert1 = new("Десерт1", "Шоколадный торт", "150 г", 200, Category.dessert, 10, "Десерт");

        List<Dish> menu = new() { soup1, soup2, drink1, dessert1 };

        // 2. Вывод меню
        Console.WriteLine("\n--- Меню ---");
        foreach (var dish in menu)
        {
            Console.WriteLine("-= {0}", dish.Name);
        }

        // 3. Создание заказа
        Order order = new(1, "Нет комментариев", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 101)
        {
            Dishes = new Dish[] { soup1, soup2, drink1, dessert1 }
        };
        Console.WriteLine("\n--- Заказ создан ---");

        // 4. Вывод чека (ошибка, заказ ещё не закрыт)
        Console.WriteLine("\n--- Попытка вывода чека ---");
        order.PrintReceipt();

        // 5. Подсчёт количества закрытых заказов по ID официанта (пустой вывод)
        List<Order> orders = new() { order };
        int closedOrdersByWaiter = orders.Count(o => o.WaiterId == 101 && o.CloseTime != null);
        Console.WriteLine($"\nКоличество закрытых заказов официантом ID 101: {closedOrdersByWaiter}");

        // 6. Подсчёт суммы закрытых заказов (пустой вывод)
        float totalClosedOrdersSum = orders.Where(o => o.CloseTime != null).Sum(o => o.GrossTotal);
        Console.WriteLine($"Сумма закрытых заказов: {totalClosedOrdersSum:F2} ₽");

        // 7. Вывод статистики заказов по каждому блюду (пустой вывод)
        Console.WriteLine("\n--- Статистика заказов по блюдам ---");
        foreach (var dish in menu)
        {
            int count = orders.Where(o => o.CloseTime != null).Sum(o => o.Dishes.Count(d => d.Name == dish.Name));
            Console.WriteLine($"{dish.Name}: {count} раз(а)");
        }

        // 8. Закрытие чека
        Console.WriteLine("\n--- Закрытие заказа ---");
        order.CloseOrder();

        // 9. Попытка изменить заказ (ошибка, заказ закрыт)
        Console.WriteLine("\n--- Попытка изменения заказа ---");
        order.Redact(menu.ToArray());

        // 10. Повторение пунктов 5, 6, 7
        Console.WriteLine("\n--- Повторение статистики ---");

        // 10.1 Подсчёт количества закрытых заказов по ID официанта
        closedOrdersByWaiter = orders.Count(o => o.WaiterId == 101 && o.CloseTime != null);
        Console.WriteLine($"Количество закрытых заказов официантом ID 101: {closedOrdersByWaiter}");

        // 10.2 Подсчёт суммы закрытых заказов
        totalClosedOrdersSum = orders.Where(o => o.CloseTime != null).Sum(o => o.GrossTotal);
        Console.WriteLine($"Сумма закрытых заказов: {totalClosedOrdersSum:F2} ₽");

        // 10.3 Вывод статистики заказов по каждому блюду
        Console.WriteLine("\n--- Статистика заказов по блюдам ---");
        foreach (var dish in menu)
        {
            int count = orders.Where(o => o.CloseTime != null).Sum(o => o.Dishes.Count(d => d.Name == dish.Name));
            Console.WriteLine($"{dish.Name}: {count} раз(а)");
        }
    }
}