class OrderEditor
{
    public static void HandleOrderRedaction(Order order, Dish[] menu)
    {
        if (order.CloseTime != null)
        {
            Console.WriteLine("Невозможно редактировать закрытый заказ");
            return;
        }
        while (true)
        {
            Console.WriteLine("\nЧто вы хотите изменить?");
            Console.WriteLine("1) Добавить блюдо");
            Console.WriteLine("2) Дополнить комментарий");
            Console.WriteLine("3) Изменить официанта");
            Console.WriteLine("Любое другое) Выйти из редактора");

            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddDish(order, menu);
                    break;
                case "2":
                    AddCommentary(order);
                    break;
                case "3":
                    ChangeWaiter(order);
                    break;
                default:
                    Console.WriteLine("Выход из редактора.");
                    return;
            }
        }
    }

    private static void AddDish(Order order, Dish[] menu)
    {
        Console.WriteLine("\nВведите название блюда для добавления:");
        string? dishName = Console.ReadLine();

        Dish? dish = menu.FirstOrDefault(d => d.Name.Equals(dishName, StringComparison.OrdinalIgnoreCase));
        if (dish == null)
        {
            Console.WriteLine("Блюдо не найдено в меню.");
            return;
        }

        order.Dishes = order.Dishes.Append(dish).ToArray();
        Console.WriteLine($"Блюдо \"{dish.Name}\" добавлено в заказ.");
    }

    private static void AddCommentary(Order order)
    {
        Console.WriteLine("\nТекущий комментарий:\n" + order.Commentary);
        Console.WriteLine("Введите дополнение к комментарию:");
        string? addition = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(addition))
        {
            order.Commentary += "\n" + addition + " :: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine("Комментарий обновлён.");
        }
        else
        {
            Console.WriteLine("Комментарий не изменён.");
        }
    }

    private static void ChangeWaiter(Order order)
    {
        Console.WriteLine("\nВведите новый ID официанта:");
        if (int.TryParse(Console.ReadLine(), out int waiterId))
        {
            order.WaiterId = waiterId;
            Console.WriteLine($"ID официанта изменён на {waiterId}.");
        }
        else
        {
            Console.WriteLine("Некорректный ввод ID.");
        }
    }
}