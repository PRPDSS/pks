class Dish
{

    static int IdCounter;
    public readonly int Id = ++IdCounter;
    public string Name { set; get; }
    public string Composition { set; get; }
    public string Weight { set; get; }
    public float Price { set; get; }
    public Category Category { set; get; }
    private int CookingTime { set; get; }
    readonly string[] Type;

    public Dish(in string name, in string composition, in string weight, in float price, in Category category, in int cookingTime, params string[] type)
    {
        Name = name;
        Composition = composition;
        Weight = weight;
        Price = price;
        Category = category;
        CookingTime = cookingTime;
        Type = type;
    }

    public void Redact() => DishEditor.HandleDishRedaction(this);
    public void Info()
    {
        Console.WriteLine("-------Информация-------");
        Console.WriteLine("Id: {0}", Id);
        Console.WriteLine("Наименование: {0}", Name);
        Console.WriteLine("Состав: {0}", Composition);
        Console.WriteLine("Вес: {0}", Weight);
        Console.WriteLine("Цена: {0}", Price, "₽");
        Console.WriteLine("Категория: {0}", Category);
        Console.WriteLine("Время готовки: {0}", CookingTime);
        Console.WriteLine("Тип блюда: {0}", String.Join(", ", Type));
        Console.WriteLine("------------------------");
    }
    ~Dish() => Console.WriteLine("Блюдо №{0} - {1} - удалено", Id, Name);
}

enum Category
{
    drink = 1, salad = 2, coldApetizer = 3, warmApetizer = 4, soup = 5, meal = 6, dessert = 7
}

