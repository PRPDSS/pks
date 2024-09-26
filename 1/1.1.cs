using System;

class Calculator
{
    private double memory = 0;

    public double Add(double a, double b) => a + b;
    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль!");
            return double.NaN;
        }
        return a / b;
    }
    public double Modulus(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль!");
            return double.NaN;
        }
        return a % b;
    }
    public double Reciprocal(double a)
    {
        if (a == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль!");
            return double.NaN;
        }
        return 1 / a;
    }
    public double Square(double a) => a * a;
    public double SquareRoot(double a)
    {
        if (a < 0)
        {
            Console.WriteLine("Ошибка: корень из отрицательного числа!");
            return double.NaN;
        }
        return Math.Sqrt(a);
    }

    // Операции с памятью
    public void MPlus(double a) => memory += a;
    public void MMinus(double a) => memory -= a;
    public double MR() => memory;
    public void ClearMemory() => memory = 0;
}


Calculator calc = new Calculator();
bool exit = false;

while (!exit)
{
    Console.WriteLine("Выберите операцию:");
    Console.WriteLine("1: Сложение (+)");
    Console.WriteLine("2: Вычитание (-)");
    Console.WriteLine("3: Умножение (*)");
    Console.WriteLine("4: Деление (/)");
    Console.WriteLine("5: Остаток от деления (%)");
    Console.WriteLine("6: 1/x");
    Console.WriteLine("7: x^2");
    Console.WriteLine("8: √x");
    Console.WriteLine("9: Добавить в память (M+)");
    Console.WriteLine("10: Вычесть из памяти (M-)");
    Console.WriteLine("11: Показать память (MR)");
    Console.WriteLine("12: Очистить память");
    Console.WriteLine("13: Выход");

    Console.Write("Введите номер операции: ");
    int choice = int.Parse(Console.ReadLine());

    double x, y;

    switch (choice)
    {
        case 1:
            Console.Write("Введите первое число: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            y = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {calc.Add(x, y)}");
            break;

        case 2:
            Console.Write("Введите первое число: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            y = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {calc.Subtract(x, y)}");
            break;

        case 3:
            Console.Write("Введите первое число: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            y = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {calc.Multiply(x, y)}");
            break;

        case 4:
            Console.Write("Введите первое число: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            y = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {calc.Divide(x, y)}");
            break;

        case 5:
            Console.Write("Введите первое число: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            y = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {calc.Modulus(x, y)}");
            break;

        case 6:
            Console.Write("Введите число: ");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {calc.Reciprocal(x)}");
            break;

        case 7:
            Console.Write("Введите число: ");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {calc.Square(x)}");
            break;

        case 8:
            Console.Write("Введите число: ");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {calc.SquareRoot(x)}");
            break;

        case 9:
            Console.Write("Введите число для добавления в память: ");
            x = double.Parse(Console.ReadLine());
            calc.MPlus(x);
            Console.WriteLine("Число добавлено в память.");
            break;

        case 10:
            Console.Write("Введите число для вычитания из памяти: ");
            x = double.Parse(Console.ReadLine());
            calc.MMinus(x);
            Console.WriteLine("Число вычтено из памяти.");
            break;

        case 11:
            Console.WriteLine($"Значение в памяти: {calc.MR()}");
            break;

        case 12:
            calc.ClearMemory();
            Console.WriteLine("Память очищена.");
            break;

        case 13:
            exit = true;
            Console.WriteLine("Выход...");
            break;

        default:
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            break;
    }

    Console.WriteLine();
}
