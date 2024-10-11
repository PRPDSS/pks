using System;

class PetriDish
{
    int bacteria, antibiotic;
    public void simulate()
    {
        Console.Write("Введите количество бактерий: ");
        bacteria = int.Parse(Console.ReadLine());
        Console.Write("Введите количество антибиотика: ");
        antibiotic = int.Parse(Console.ReadLine());
        bool bacteriasDied = false;
        for (int effectivity = 10; effectivity > 0; effectivity--)
        {
            bacteria *= 2;
            bacteria -= antibiotic * effectivity;
            if (bacteria <= 0)
            {
                bacteriasDied = true;
                break;
            }
            Console.WriteLine($"После {11 - effectivity} часа осталось {bacteria} бактерий.");
        }
        if (bacteriasDied)
        {
            Console.WriteLine("Бактерии вымерли");
        }
        else
        {
            Console.WriteLine("Антибиотик перестал действовать");
        }
    }
}

PetriDish dish = new PetriDish();
dish.simulate();