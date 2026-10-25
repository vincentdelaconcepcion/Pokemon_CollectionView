using PokedexGen1.Services;

namespace Pokemon_CollectionView.Models.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Type1 { get; set; } = "";
    public string? Type2 { get; set; }

    public string NumberText => $"#{Id:000}";
    public bool HasType2 => !string.IsNullOrEmpty(Type2);
    public string ImageUrl =>
        $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{Id}.png";
    public Color Type1Color => TypeColors.Get(Type1);
    public Color Type2Color => TypeColors.Get(Type2 ?? "");
}

public record StatItem(string Name, int Value)
{
    public double Progress => Math.Min(Value / 200.0, 1.0);
}

public record PokemonDetails(double HeightM, double WeightKg, string Description, List<StatItem> Stats);
