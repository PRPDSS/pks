class Table
{
    private static int IdCounter { get; set; }
    public int Id { get; }
    public Placement TablePlacement { get; set; }
    public int SeatCount { get; set; }
    private bool[] reservations = new bool[24];

    public Table(Placement placement, int seats)
    {
        Id = IdCounter++;
        this.TablePlacement = placement;
        SeatCount = seats;
    }

    public bool AddReservation(int startHour, int endHour)
    {
        if (startHour < 0 || startHour >= 24 || endHour <= startHour || endHour > 24)
        {
            Console.WriteLine("Ошибка: Неверный диапазон времени для бронирования.");
            return false;
        }

        // Проверка, что все часы в диапазоне свободны
        for (int hour = startHour; hour < endHour; hour++)
        {
            if (reservations[hour]) // Если хотя бы один час занят, то нельзя забронировать
            {
                return false;
            }
        }

        // Бронирование всех часов в диапазоне
        for (int hour = startHour; hour < endHour; hour++)
        {
            reservations[hour] = true;
        }

        Console.WriteLine($"{startHour}:00 - {endHour}:00 успешно забронировано для стола #{Id}");
        return true;
    }

    public void RemoveReservation(int startHour, int endHour)
    {
        if (startHour < 0 || startHour >= 24 || endHour <= startHour || endHour > 24)
        {
            Console.WriteLine("Ошибка: Неверный диапазон времени для снятия брони.");
            return;
        }

        for (int hour = startHour; hour < endHour; hour++)
        {
            reservations[hour] = false; // Освобождение каждого часа в диапазоне
        }

        Console.WriteLine($"Бронь с {startHour}:00 до {endHour}:00 для стола #{Id} отменена.");
    }

    public void Info()
    {
        string separator = new('*', Console.WindowWidth);
        Console.WriteLine(separator);
        Console.WriteLine($"Стол №{Id}");
        Console.WriteLine($"Расположен: {PlacementDescription[TablePlacement]}");
        Console.WriteLine($"Мест: {SeatCount}");
        Console.WriteLine("Расписание:");

        bool hasReservations = false;
        for (int hour = 0; hour < 24; hour++)
        {
            if (reservations[hour])
            {
                Console.WriteLine($"{hour:00}:00 - {hour + 1}:00 забронировано");
                hasReservations = true;
            }
        }
        if (!hasReservations)
        {
            Console.WriteLine("Нет забронированных часов.");
        }

        Console.WriteLine(separator);
    }

    public enum Placement { window, passage, entrance, deep };

    public static readonly Dictionary<Placement, string> PlacementDescription = new()
    {
        { Placement.window, "у окна" },
        { Placement.entrance, "у входа" },
        { Placement.passage, "у прохода" },
        { Placement.deep, "в глубине" }
    };
}