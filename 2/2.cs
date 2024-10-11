using System;

class LuckChecker
{
    public bool check(int number)
    {
        // Обрабатывакем только шестизначные
        if (number < 100000 || number > 999999)
        {
            Console.WriteLine("Ошибка: число не является шестизначным.");
            return false;
        }

        int firstHalf = number / 1000;
        int secondHalf = number % 1000;

        int firstSum = firstHalf / 100 + (firstHalf / 10) % 10 + firstHalf % 10;
        int secondSum = secondHalf / 100 + (secondHalf / 10) % 10 + secondHalf % 10;

        return firstSum == secondSum;
    }
}

LuckChecker checker = new LuckChecker();
Console.WriteLine("Введите нУмер билета (шестизначный!)");
int num = int.Parse(Console.ReadLine());
Console.WriteLine(checker.check(num) ? $"Число {num} счастливое" : $"Число {num} не счастливое")