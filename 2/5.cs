using System;

class CoffeeMaker
{
    int water, milk;

    public CoffeeMaker()
    {
        Console.Write("Введите количество воды в мл: ");
        water = int.Parse(Console.ReadLine());
        Console.Write("Введите количество молока в мл: ");
        milk = int.Parse(Console.ReadLine());
    }

    public void serve()
    {
        int americas = 0, lattes = 0, money = 0;
        while (water >= 300 || (water >= 30 && milk >= 270))
        {
            Console.Write("Выберите напиток (1 - американо, 2 - латте): ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                if (water < 300)
                {
                    Console.Write("Не хватает воды");
                    continue;
                }
                water -= 300;
                money += 150;
                americas++;
                continue;
            }
            if (choice == "2")
            {
                if (milk < 270)
                {
                    Console.WriteLine("Не хватает молока");
                    continue;
                }
                water -= 30;
                milk -= 270;
                money += 170;
                lattes++;
                continue;
            }
            Console.WriteLine("Некорректный ввод, попробуйте еще раз");
        }
        Console.WriteLine("*Отчет*");
        Console.WriteLine("Ингредиентов осталось:");
        Console.WriteLine($"\tВода: {water}мл");
        Console.WriteLine($"\tМолоко: {milk}мл");
        Console.WriteLine($"Кружек американо продано: {americas}");
        Console.WriteLine($"Кружек латте продано: {lattes}");
        Console.WriteLine($"Итого: {money} рублей.");
    }
}

CoffeeMaker c = new CoffeeMaker();
c.serve();