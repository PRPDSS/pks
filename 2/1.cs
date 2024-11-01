using System;

class Solver
{
    public double CosMaclaurin(double x, double e)
    {
        double sum = 1;
        double term = 1;
        int n = 1;

        while (Math.Abs(term) >= e)
        {
            term *= -x * x / (2 * n * (2 * n - 1)); // Вычисляем следующий член ряда
            sum += term; // Добавляем его к сумме
            n++;
        }
        sum -= term;

        return sum;
    }

    public double NTerm(int n, double x)
    {
        double term = Math.Pow(-1, n) * Math.Pow(x, 2 * n) / Factorial(2 * n);
        return term;
    }

    static double Factorial(int n)
    {
        double result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}


Solver solver = new Solver();

Console.Write("Введите значение x: ");
double x = double.Parse(Console.ReadLine());
double e;
for (; ; )
{
    Console.Write("Введите значение точности e (e < 0.01): ");
    e = double.Parse(Console.ReadLine());
    if (e <= 0.01) break;
    Console.WriteLine("Ошибка: e должен быть меньше 0.01.");
}
double result = solver.CosMaclaurin(x, e);
Console.WriteLine($"Значение cos({x}) = {result}");

Console.Write("Введите номер n-го члена ряда: ");
int n = int.Parse(Console.ReadLine());
double nthTerm = solver.NTerm(n, x);
Console.WriteLine($"Значение {n}-го члена ряда для x = {x}: {nthTerm}");