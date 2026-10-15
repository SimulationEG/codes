using System.Text.Json.Serialization;

namespace AdvancedCsharp.Lecture04.Sections._07_Json;

/// <summary>Deck: OPTIONS — [JsonPropertyName] maps a different JSON key.</summary>
public class Product
{
    [JsonPropertyName("product_name")]
    public string Name { get; set; } = "";

    public decimal Price { get; set; }
}
