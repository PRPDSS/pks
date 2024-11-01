class Table
{
    private static int IdCounter { get; set; }
    public int Id { get; }
    public string TablePlacement { get; }
    public int SeatCount { get; }
    private bool[] reservations = new bool[24];

    public Table(string placement, in int seats)
    {
        Id = IdCounter++;
        this.TablePlacement = placement;
        SeatCount = seats;
    }

    public bool AddReservation(int hour)
    {
        // Returns true if reservation added succesfully and false otherwise
        if (reservations[hour]) return false;
        reservations[hour] = true;
        return true;
    }
    public void RemoveReservation(int hour) => reservations[hour] = false;

    public void Info()
    {
        string separator = new('*', Console.WindowWidth);

        Console.WriteLine(separator);
        Console.WriteLine($"Стол №{Id}");
        Console.Write("Расположен: ");
        switch (TablePlacement)
        {
            case Placement.window:
                Console.Write("у окна");
                break;
            case Placement.entrance:
                Console.Write("у входа");
                break;
            case Placement.passage:
                Console.Write("у прохода");
                break;
            case Placement.deep:
                Console.Write("в глубине");
                break;
            default:
                break;
        }
        Console.WriteLine($"Мест: {SeatCount}");
        Console.Write("Расписание:");
        for (int hour = 0; hour < 24; hour++)
        {
            if (reservations[hour]) Console.Write($"{hour}:00 - {hour + 1}:00");
            // TODO: вывод информацию бронирования
        }
        Console.WriteLine(separator);
    }
}