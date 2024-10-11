using System;

class Sokratun
{
    public void doTheThing(int x, int y) // считает x/y
    {
        if (y == 0)
        {
            Console.WriteLine("На ноль делить нельзя!");
            return;
        }
        if (x == 0)
        {
            Console.WriteLine("0");
            return;
        }
        if (x == y)
        {
            Console.WriteLine("1");
            return;
        }
        if (x < 0 ^ y < 0)
        {
            Console.Write("- ");
            x = Math.Abs(x);
            y = Math.Abs(y);
        }
        int nod = Math.Max(x, y);
        int other = Math.Min(x, y);
        while (other != 0)
        {
            int temp = other;
            other = nod % other;
            nod = temp;
        }
        x = x / nod;
        y = y / nod;
        Console.WriteLine($"{x} / {y}");
    }
}

Sokratun thingDoingMachine = new Sokratun();
Console.WriteLine("Введите числитель:");
int x = int.Parse(Console.ReadLine());
Console.WriteLine("Введите знаменатель:");
int y = int.Parse(Console.ReadLine());
thingDoingMachine.doTheThing(x, y);