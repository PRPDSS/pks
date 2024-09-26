using System;

class Calculator
{
    private double memory = 0;  // Для операций с памятью

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

Console.WriteLine("Пример работы калькулятора:");
Console.WriteLine($"5 + 3 = {calc.Add(5, 3)}");
Console.WriteLine($"10 - 4 = {calc.Subtract(10, 4)}");
Console.WriteLine($"6 * 2 = {calc.Multiply(6, 2)}");
Console.WriteLine($"8 / 4 = {calc.Divide(8, 4)}");
Console.WriteLine($"10 % 3 = {calc.Modulus(10, 3)}");
Console.WriteLine($"1 / 5 = {calc.Reciprocal(5)}");
Console.WriteLine($"2^2 = {calc.Square(2)}");
Console.WriteLine($"Квадратный корень из 16 = {calc.SquareRoot(16)}");

// Пример операций с памятью
calc.MPlus(100);
Console.WriteLine($"MR (Память): {calc.MR()}");
calc.MMinus(50);
Console.WriteLine($"MR (Память): {calc.MR()}");

