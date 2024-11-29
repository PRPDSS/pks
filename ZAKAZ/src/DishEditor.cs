class DishEditor
{
    public static void HandleDishRedaction(Dish dish)
    {
        while (true)
        {
            Console.WriteLine("\nЧто вы хотите изменить?");
            Console.WriteLine("1) Название");
            Console.WriteLine("2) Вес");
            Console.WriteLine("3) Цену");
            Console.WriteLine("4) Категорию");
            Console.WriteLine("5) Время приготовления");
            Console.WriteLine("6) Тип блюда");
            Console.WriteLine("Любое другое) Выйти из редактора");

            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    UpdateName(dish);
                    break;
                case "2":
                    UpdateWeight(dish);
                    break;
                case "3":
                    UpdatePrice(dish);
                    break;
                case "4":
                    UpdateCategory(dish);
                    break;
                case "5":
                    UpdateCookingTime(dish);
                    break;
                case "6":
                    UpdateTypes(dish);
                    break;
                default:
                    Console.WriteLine("Выход из редактора блюда.");
                    return;
            }
        }
    }

    private static void UpdateName(Dish dish)
    {
        Console.WriteLine("Введите новое название для блюда:");
        string? newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
        {
            dish.Name = newName;
            Console.WriteLine("Название обновлено.");
        }
        else
        {
            Console.WriteLine("Название не изменено.");
        }
    }

    private static void UpdateWeight(Dish dish)
    {
        Console.WriteLine("Введите новый вес для блюда (в формате 000/00/00):");
        string? newWeight = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newWeight))
        {
            dish.Weight = newWeight;
            Console.WriteLine("Вес обновлён.");
        }
        else
        {
            Console.WriteLine("Вес не изменён.");
        }
    }

    private static void UpdatePrice(Dish dish)
    {
        Console.WriteLine("Введите новую цену для блюда:");
        if (float.TryParse(Console.ReadLine(), out float newPrice))
        {
            dish.Price = newPrice;
            Console.WriteLine("Цена обновлена.");
        }
        else
        {
            Console.WriteLine("Некорректный ввод цены.");
        }
    }

    private static void UpdateCategory(Dish dish)
    {
        Console.WriteLine("Введите новую категорию для блюда:");
        Console.WriteLine("1) напиток");
        Console.WriteLine("2) салат");
        Console.WriteLine("3) холодная закуска");
        Console.WriteLine("4) теплая закуска");
        Console.WriteLine("5) суп");
        Console.WriteLine("6) второе блюдо");
        Console.WriteLine("7) десерт");

        string? input = Console.ReadLine();
        switch (input)
        {
            case "1":
                dish.Category = Category.drink;
                break;
            case "2":
                dish.Category = Category.salad;
                break;
            case "3":
                dish.Category = Category.coldApetizer;
                break;
            case "4":
                dish.Category = Category.warmApetizer;
                break;
            case "5":
                dish.Category = Category.soup;
                break;
            case "6":
                dish.Category = Category.meal;
                break;
            case "7":
                dish.Category = Category.dessert;
                break;
            default:
                Console.WriteLine("Категория не изменена.");
                return;
        }

        Console.WriteLine("Категория обновлена.");
    }

    private static void UpdateCookingTime(Dish dish)
    {
        Console.WriteLine("Введите новое время приготовления для блюда:");
        if (int.TryParse(Console.ReadLine(), out int newTime))
        {
            dish.GetType()
                .GetProperty("CookingTime", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(dish, newTime);
            Console.WriteLine("Время приготовления обновлено.");
        }
        else
        {
            Console.WriteLine("Некорректный ввод времени приготовления.");
        }
    }
    private static void UpdateTypes(Dish dish)
    {
        Console.WriteLine("Введите новые типы блюда через запятую:");
        string? input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            string[] types = input.Split(',', StringSplitOptions.TrimEntries);
            dish.GetType()
                .GetField("Type", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(dish, types);

            Console.WriteLine("Типы блюда обновлены.");
        }
        else
        {
            Console.WriteLine("Типы блюда не изменены.");
        }
    }
}