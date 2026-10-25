using System.Text.Json;
using Pokemon_CollectionView.Models.Models;

namespace PokedexGen1.Services;

// Fetches extra details (stats, height, weight, Pokédex entry) from the free PokeAPI.
public static class PokeApiService
{
    static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(10) };

    static readonly Dictionary<string, string> StatNames = new()
    {
        ["hp"]="HP", ["attack"]="Attack", ["defense"]="Defense",
        ["special-attack"]="Sp. Atk", ["special-defense"]="Sp. Def", ["speed"]="Speed"
    };

    public static async Task<PokemonDetails?> GetDetailsAsync(int id)
    {
        try
        {
            using var pokeDoc = JsonDocument.Parse(await Http.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}"));
            var root = pokeDoc.RootElement;

            double height = root.GetProperty("height").GetInt32() / 10.0;   // decimeters -> m
            double weight = root.GetProperty("weight").GetInt32() / 10.0;   // hectograms -> kg

            var stats = new List<StatItem>();
            foreach (var s in root.GetProperty("stats").EnumerateArray())
            {
                var key = s.GetProperty("stat").GetProperty("name").GetString() ?? "";
                stats.Add(new StatItem(StatNames.GetValueOrDefault(key, key), s.GetProperty("base_stat").GetInt32()));
            }

            string description = "";
            using var speciesDoc = JsonDocument.Parse(await Http.GetStringAsync($"https://pokeapi.co/api/v2/pokemon-species/{id}"));
            foreach (var entry in speciesDoc.RootElement.GetProperty("flavor_text_entries").EnumerateArray())
            {
                if (entry.GetProperty("language").GetProperty("name").GetString() == "en")
                {
                    description = (entry.GetProperty("flavor_text").GetString() ?? "")
                        .Replace("\n", " ").Replace("\f", " ");
                    break;
                }
            }
            return new PokemonDetails(height, weight, description, stats);
        }
        catch
        {
            return null; // offline or API error: page shows a friendly message
        }
    }
}
