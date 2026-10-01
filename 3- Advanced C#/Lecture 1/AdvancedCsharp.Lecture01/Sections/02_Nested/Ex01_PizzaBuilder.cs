namespace AdvancedCsharp.Lecture01.Sections._02_Nested;

/// <summary>Deck 01 — nested Builder can touch outer private fields.</summary>
public static class Ex01_PizzaBuilder
{
    public static void Run()
    {
        var pizza = new Pizza.Builder()
            .Add("Cheese")
            .Add("Olives")
            .Build();
        Console.WriteLine(pizza.Describe());
        // var bad = new Pizza(); // private ctor
    }

    public class Pizza
    {
        private readonly List<string> _toppings = new();
        private Pizza() { }

        public string Describe() => string.Join(", ", _toppings);

        public class Builder
        {
            private readonly Pizza _pizza = new();

            public Builder Add(string topping)
            {
                _pizza._toppings.Add(topping);
                return this;
            }

            public Pizza Build() => _pizza;
        }
    }
}
