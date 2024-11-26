internal class Program
{
    private static List<Reservation> reservations = new();

    static List<Table> tables = new();
    private static void Main(string[] args)
    {
        // Console.Clear();
        Console.WriteLine("Ресторатор v0.0.1 pre-alpha");


        while (true)
        {
            Console.WriteLine("Что вы хотите сделать?\n");
            Console.WriteLine("1) Просмотреть список столов");
            Console.WriteLine("2) Создать стол");
            Console.WriteLine("3) Вывести информацию о столе");
            Console.WriteLine("4) Изменить стол");
            Console.WriteLine("5) Удалить стол");
            Console.WriteLine("6) Создать бронь");
            Console.WriteLine("7) Редактировать бронь");
            Console.WriteLine("8) Удалить бронь");
            Console.WriteLine("9) Найти бронь по имени");
            Console.WriteLine("100) Создать случайный набор столов");

            int input = int.Parse(Console.ReadLine() ?? "");
            switch (input)
            {
                case 1:
                    Console.WriteLine("Список столов:\n");
                    foreach (Table table in tables)
                    {
                        Console.WriteLine($"Стол {table.Id} - {table.SeatCount} стульев, находится {Table.PlacementDescription[table.TablePlacement]}");
                    }
                    break;

                case 2:
                    Console.Write("Введите количество мест: ");
                    int seatCount = int.Parse(Console.ReadLine() ?? "");
                    Console.Write("Введите расположение (window, entrance, passage, deep): ");
                    var placement = Enum.Parse<Table.Placement>(Console.ReadLine() ?? "", true);
                    tables.Add(new Table(placement, seatCount));
                    Console.WriteLine("Стол успешно добавлен!");
                    break;

                case 3:
                    Console.Write("Введите ID стола: ");
                    int id = int.Parse(Console.ReadLine() ?? "");
                    Table? tableToView = tables.FirstOrDefault(t => t.Id == id);
                    if (tableToView != null)
                    {
                        tableToView.Info();
                    }
                    else
                    {
                        Console.WriteLine("Стол не найден!");
                    }
                    break;

                case 4:
                    Console.Write("Введите ID стола для изменения: ");
                    int editId = int.Parse(Console.ReadLine() ?? "");
                    Table? tableToEdit = tables.FirstOrDefault(t => t.Id == editId);
                    if (tableToEdit != null)
                    {
                        Console.Write("Введите новое количество мест: ");
                        tableToEdit.SeatCount = int.Parse(Console.ReadLine() ?? "");
                        Console.WriteLine("Стол успешно обновлен!");
                    }
                    else
                    {
                        Console.WriteLine("Стол не найден!");
                    }
                    break;

                case 5:
                    Console.Write("Введите ID стола для удаления: ");
                    int deleteId = int.Parse(Console.ReadLine() ?? "");
                    Table? tableToDelete = tables.FirstOrDefault(t => t.Id == deleteId);
                    if (tableToDelete != null)
                    {
                        tables.Remove(tableToDelete);
                        Console.WriteLine("Стол успешно удален!");
                    }
                    else
                    {
                        Console.WriteLine("Стол не найден!");
                    }
                    break;

                case 6:
                    CreateReservation(tables);
                    break;

                case 7:
                    EditReservation();
                    break;

                case 8:
                    DeleteReservation();
                    break;
                case 9:
                    FindReservation();
                    break;
                case 100:
                    for (int i = 0; i < 10; i++)
                    {
                        tables.Add(new Table(Table.Placement.deep, 4));
                    }
                    Console.WriteLine("Столы успешно созданы");
                    break;

                default:
                    Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                    break;
            }
            Console.ReadLine();
        }
    }
    private static void EditReservation()
    {
        Console.Write("Введите ID брони для редактирования: ");
        int resId = int.Parse(Console.ReadLine() ?? "");
        Reservation? reservation = reservations.FirstOrDefault(r => r.Id == resId);
        if (reservation != null)
        {
            Console.Write("Введите новый комментарий: ");
            reservation.AddComment();
            Console.WriteLine("Комментарий добавлен!");
        }
        else
        {
            Console.WriteLine("Бронь не найдена!");
        }
    }

    private static void CreateReservation(List<Table> tables)
    {
        Console.Write("Введите имя: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Введите номер телефона: ");
        string phone = Console.ReadLine() ?? "";
        Console.Write("Введите ID стола для бронирования: ");
        int tableId = int.Parse(Console.ReadLine() ?? "");

        Table? table = tables.FirstOrDefault(t => t.Id == tableId);
        if (table == null)
        {
            Console.WriteLine("Стол не найден!");
            return;
        }

        Console.Write("Введите час начала бронирования (0-23): ");
        int startHour = int.Parse(Console.ReadLine() ?? "");
        Console.Write("Введите час окончания бронирования (0-23): ");
        int endHour = int.Parse(Console.ReadLine() ?? "");

        if (table.AddReservation(startHour, endHour))
        {
            DateTime start = DateTime.Today.AddHours(startHour);
            DateTime end = DateTime.Today.AddHours(endHour);
            Reservation reservation = new(name, phone, tableId, start, end);
            reservations.Add(reservation);
            Console.WriteLine("Бронь успешно создана!");
        }
        else
        {
            Console.WriteLine("Ошибка: стол уже забронирован на это время.");
        }
    }

    private static void DeleteReservation()
    {
        Console.Write("Введите ID брони для удаления: ");
        int resId = int.Parse(Console.ReadLine() ?? "");
        Reservation? reservation = reservations.FirstOrDefault(r => r.Id == resId);
        if (reservation != null)
        {
            // Найти стол и отменить бронь на диапазон времени
            Table table = tables.FirstOrDefault(t => t.Id == reservation.reservedTableId)!;
            if (table != null)
            {
                table.RemoveReservation(reservation.Start.Hour, reservation.End.Hour);
            }

            reservations.Remove(reservation);
            Console.WriteLine("Бронь успешно удалена!");
        }
        else
        {
            Console.WriteLine("Бронь не найдена!");
        }
    }
    private static void FindReservation()
    {
        Console.Write("Введите имя: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Введите последние 4 цифры номера телефона: ");
        string phoneNumber = Console.ReadLine() ?? "";


        var foundReservations = reservations.Where(r => r.name.Equals(name, StringComparison.OrdinalIgnoreCase) & r.phoneNumber.Substring(r.phoneNumber.Length - 4, 4).Equals(phoneNumber)).ToList();

        if (foundReservations.Any())
        {
            Console.WriteLine($"Найдено {foundReservations.Count} броней на имя {name}:");
            foreach (var reservation in foundReservations)
            {
                reservation.ShowReservation();
            }
        }
        else
        {
            Console.WriteLine($"Брони на имя {name} не найдены.");
        }
    }
}