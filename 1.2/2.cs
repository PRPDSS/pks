using System;


class Bank_O_Mat
{
    private int limit = 150000;
    public void CountBanknotes(int money)
    {
        if (money > limit) {
            Console.WriteLine("Слишком много, идите в отделение банка");
            return;
        }
        if (money%100 != 0) {
            Console.WriteLine("Невозможно выдать имеющимеся купюрами");
            return;
        }

        int counter = 0;
        Console.Write("Необходимо выдать ");
        while (money >= 5000)
        {
            counter++;
            money -= 5000;
        }
        if (counter != 0)
        {
            Console.Write($"{counter} по 5000, ");
            counter = 0;
        } while (money >= 2000)
        {
            counter++;
            money -= 2000;
        }
        if (counter != 0)
        {
            Console.Write($"{counter} по 2000, ");
            counter = 0;
        } while (money >= 1000)
        {
            counter++;
            money -= 1000;
        }
        if (counter != 0)
        {
            Console.Write($"{counter} по 1000, ");
            counter = 0;
        } while (money >= 500)
        {
            counter++;
            money -= 500;
        }
        if (counter != 0)
        {
            Console.Write($"{counter} по 500, ");
            counter = 0;
        } while (money >= 200)
        {
            counter++;
            money -= 200;
        }
        if (counter != 0)
        {
            Console.Write($"{counter} по 200, ");
            counter = 0;
        } while (money >= 100)
        {
            counter++;
            money -= 100;
        }
        if (counter != 0)
        {
            Console.Write($"{counter} по 100.");
            counter = 0;
        }
    }
}

Bank_O_Mat example = new Bank_O_Mat();
while(true){
    Console.Write("Сколько надо снять? ");
    example.CountBanknotes(int.Parse(Console.ReadLine()));
    Console.WriteLine("");
}