using System;

class Guesser
{
    public static void guess()
    {
        int midpoint = 32;
        int step = 16;
        bool flag;
        while (step >= 1)
        {
            Console.WriteLine($"Ваше число больше {midpoint}? (y/n):");
            flag = Console.ReadLine() == "y";
            if (flag)
                midpoint += step;
            else
                midpoint -= step;

            if (step == 1)
            {
                Console.WriteLine($"Ваше число {midpoint}? (y/n):");
                if (Console.ReadLine() != "y") midpoint--;
            }
            step /= 2;
        }
        Console.WriteLine($"Число было {midpoint}!");
    }
}

Guesser.guess();