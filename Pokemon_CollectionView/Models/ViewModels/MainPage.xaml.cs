using PokedexGen1.Services;
using Pokemon_CollectionView.Models.Models;

namespace PokedexGen1;

public partial class MainPage : ContentPage
{
    readonly List<Pokemon> _all = PokemonData.GetAll();

    public MainPage()
    {
        InitializeComponent();
        PokemonView.ItemsSource = _all;
    }

    void OnSearchChanged(object? sender, TextChangedEventArgs e)
    {
        var q = (e.NewTextValue ?? "").Trim().TrimStart('#');
        var results = string.IsNullOrEmpty(q)
            ? _all
            : _all.Where(p => p.Name.Contains(q, StringComparison.OrdinalIgnoreCase)
                           || p.Type1.Contains(q, StringComparison.OrdinalIgnoreCase)
                           || (p.Type2?.Contains(q, StringComparison.OrdinalIgnoreCase) ?? false)
                           || p.Id.ToString() == q.TrimStart('0')).ToList();

        PokemonView.ItemsSource = results;
        CountLabel.Text = $"{results.Count} Pokémon";
    }

    async void OnPokemonSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Pokemon selected)
            return;

        // Pass the exact selected object so the details page always matches the tapped item.
        await Shell.Current.GoToAsync(nameof(DetailPage),
            new Dictionary<string, object> { ["Pokemon"] = selected });

        PokemonView.SelectedItem = null; // allow re-selecting the same item
    }
}
