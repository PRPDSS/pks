class Reservation
{
    static int idCounter;
    public readonly int Id;
    public string name {get;}
    public readonly string phoneNumber;
    public DateTime Start { set; get; }
    public DateTime End { set; get; }
    string? comment;
    public int reservedTableId { set; get; }

    public Reservation(string name, string phoneNumber, int reservedTableId, DateTime start, DateTime end)
    {
        Id = ++idCounter;
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.reservedTableId = reservedTableId;
        this.Start = start;
        this.End = end;
    }

    public void AddComment()
    {
        Console.Write("Введите новый комментарий: ");
        comment += $"{DateTime.Now:dd/MM/yyyy H:mm:ss} ";
        comment += Console.ReadLine();
    }

    public void ShowReservation()
    {
        Console.WriteLine($"Бронь #{Id} на имя {name}");
        Console.WriteLine($"Телефон: {phoneNumber}");
        Console.WriteLine($"Начало: {Start:dd/MM/yyyy H:mm}");
        Console.WriteLine($"Конец: {End:dd/MM/yyyy H:mm}");
        Console.WriteLine($"Комментарий: {comment}");
    }

    ~Reservation()
    {
        Console.WriteLine($"Бронь на имя {name} в {Start:dd/MM H:mm} удалена.");
    }
}