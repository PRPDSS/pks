internal class Program
{
    Dictionary<Table.Placement, >;
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Ресторатор v0.0.1 pre-alpha");

        List<Table> tables = new();

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
            Console.WriteLine("100) Создать случайный набор столов");

            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("Список столов:\n");
                    foreach(Table table in tables)
                    {
                        Console.WriteLine($"Стол {table.Id} - {table.SeatCount} стульев, находится в {table.Placement}");
                    }
                    break;

                case 2:
                    Console.Write("Введите количество мест: ");
                    int seatCount = int.Parse(Console.ReadLine());
                    Console.Write("Введите расположение (deep, center и т.д.): ");
                    var placement = Enum.Parse<Table.Placement>(Console.ReadLine(), true);
                    tables.Add(new Table(placement, seatCount));
                    Console.WriteLine("Стол успешно добавлен!");
                    break;

                case 3:
                    Console.Write("Введите ID стола: ");
                    int id = int.Parse(Console.ReadLine());
                    Table tableToView = tables.FirstOrDefault(t => t.Id == id);
                    if (tableToView != null)
                    {
                        Console.WriteLine($"Стол {tableToView.Id} - {tableToView.SeatCount} стульев, находится в {tableToView.Placement}");
                    }
                    else
                    {
                        Console.WriteLine("Стол не найден!");
                    }
                    break;

                case 4:
                    Console.Write("Введите ID стола для изменения: ");
                    int editId = int.Parse(Console.ReadLine());
                    Table tableToEdit = tables.FirstOrDefault(t => t.Id == editId);
                    if (tableToEdit != null)
                    {
                        Console.Write("Введите новое количество мест: ");
                        tableToEdit.SeatCount = int.Parse(Console.ReadLine());
                        Console.WriteLine("Стол успешно обновлен!");
                    }
                    else
                    {
                        Console.WriteLine("Стол не найден!");
                    }
                    break;

                case 5:
                    Console.Write("Введите ID стола для удаления: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    Table tableToDelete = tables.FirstOrDefault(t => t.Id == deleteId);
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
                    // Пример логики для создания брони
                    Console.Write("Введите ID стола для бронирования: ");
                    int reserveId = int.Parse(Console.ReadLine());
                    Table tableToReserve = tables.FirstOrDefault(t => t.Id == reserveId);
                    if (tableToReserve != null)
                    {
                        // Создать логику бронирования
                        Console.WriteLine("Бронь успешно создана!");
                    }
                    else
                    {
                        Console.WriteLine("Стол не найден!");
                    }
                    break;

                case 7:
                    // Пример логики для редактирования брони
                    Console.WriteLine("Редактирование брони");
                    break;

                case 8:
                    // Пример логики для удаления брони
                    Console.WriteLine("Удаление брони");
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
}