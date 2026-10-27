namespace PokedexGen1.Services;

public static class TypeColors
{
    static readonly Dictionary<string, string> Map = new()
    {
        ["Normal"]="#A8A878", ["Fire"]="#F08030", ["Water"]="#6890F0", ["Electric"]="#F8D030",
        ["Grass"]="#78C850", ["Ice"]="#98D8D8", ["Fighting"]="#C03028", ["Poison"]="#A040A0",
        ["Ground"]="#E0C068", ["Flying"]="#A890F0", ["Psychic"]="#F85888", ["Bug"]="#A8B820",
        ["Rock"]="#B8A038", ["Ghost"]="#705898", ["Dragon"]="#7038F8", ["Fairy"]="#EE99AC",
        ["Steel"]="#B7B9D0"
    };

    public static Color Get(string type) =>
        Map.TryGetValue(type, out var hex) ? Color.FromArgb(hex) : Colors.Gray;
}
