using System;

class Housing
{
    // Функция для проверки, поместятся ли модули с защитой толщины d на поле
    public bool CanPlaceModules(int n, int a, int b, int w, int h, int d)
    {
        // Новые размеры модуля с защитой
        int shieldedWidth = a + 2 * d;
        int shieldedHeight = b + 2 * d;
        int x = w / shieldedWidth;
        int y = h / shieldedHeight;
        return (x * y) >= n;
    }
}

Housing haligali = new Housing();

Console.Write("Введите n: ");
int n = int.Parse(Console.ReadLine());

Console.Write("Введите a: ");
int a = int.Parse(Console.ReadLine());
Console.Write("Введите b: ");
int b = int.Parse(Console.ReadLine());

Console.Write("Введите w: ");
int w = int.Parse(Console.ReadLine());
Console.Write("Введите h: ");
int h = int.Parse(Console.ReadLine());

int left = 0, right = Math.Min(w, h);
int maxD = 0;

while (left <= right)
{
    int mid = (left + right) / 2;

    if (haligali.CanPlaceModules(n, a, b, w, h, mid))
    {
        maxD = mid;
        left = mid + 1;
    }
    else
    {
        right = mid - 1;
    }
}

Console.WriteLine($"Ответ d = {maxD}");