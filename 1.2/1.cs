using System;


class Calendar
{
    private int daysInMonth = 31; //при желании сменить на любой другой
    private int startingDay = 1;

    public bool CheckDate(int day) => (0 < day) && (day <= daysInMonth);
    public void SetStartingDay(int day) => startingDay = day;
    public bool IsHoliday(int day)
    {
        if (1 <= day && day <= 5) return true;
        if (8 <= day && day <= 10) return true;
        return (day + startingDay - 2) % 7 >= 5;
    }
}

Calendar calendar = new Calendar();
int day;
while (true)
{
    Console.Write("Ведите номер дня недели, с которого начинается месяц (1-пн,...7-вс) ");
    day = int.Parse(Console.ReadLine());
    if (1 <= day && day <= 7) break;
}
calendar.SetStartingDay(day);

while (true)
{
    Console.Write("Введите день месяца ");
    day = int.Parse(Console.ReadLine());
    if (!calendar.CheckDate(day))
    {
        Console.WriteLine("Неверная дата, попробуйте еще раз.");
        continue;
    }
    if (calendar.IsHoliday(day))
        Console.WriteLine("Этот день будет выходным");
    else
        Console.WriteLine("Этот день будет плохим");
    Console.WriteLine("");
}