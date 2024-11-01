class Reservation
{
    static int idCounter;
    readonly int id;
    readonly string name;
    readonly string phoneNumber;
    public DateTime Start { set; get; }
    public DateTime End { set; get; }
    string? comment;
    int reservedTableId;

    public Reservation(string name, string phoneNumber, int reservedTableId, DateTime start, DateTime end)
    {
        id = idCounter++;
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.reservedTableId = reservedTableId;
        this.Start = start;
        this.End = end;
    }
    public void addComment()
    {
        Console.Write("Введите новый комментарий: ");
        comment += String.Format("0:dd/MM/yyyy H:mm:ss ");
        comment += Console.ReadLine();
    }

    ~Reservation()
    {
        Console.WriteLine("Бронь на имя {} в {0:dd/MM H:mm} удалена.", name, Start);
    }
}