using PokedexGen1.Services;
using Pokemon_CollectionView.Models.Models;

namespace PokedexGen1;

public partial class MainPage : ContentPage
{
    readonly List<Pokemon> _all = PokemonData.GetAll();
    string _activeType = "All";

    public MainPage()
    {
        InitializeComponent();
        PokemonView.ItemsSource = _all;
    }

    // Called when a type pill is tapped
    void OnTypeFilterClicked(object? sender, EventArgs e)
    {
        if (sender is not Button btn || btn.CommandParameter is not string type) return;
        _activeType = type;
        ApplyFilters();
    }

    void OnSearchChanged(object? sender, TextChangedEventArgs e) => ApplyFilters();

    void ApplyFilters()
    {
        var q = (Search.Text ?? "").Trim().TrimStart('#');

        IEnumerable<Pokemon> results = _all;

        // Type filter
        if (_activeType != "All")
            results = results.Where(p =>
                p.Type1.Equals(_activeType, StringComparison.OrdinalIgnoreCase) ||
                (p.Type2?.Equals(_activeType, StringComparison.OrdinalIgnoreCase) ?? false));

        // Search text filter
        if (!string.IsNullOrEmpty(q))
            results = results.Where(p =>
                p.Name.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                p.Type1.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                (p.Type2?.Contains(q, StringComparison.OrdinalIgnoreCase) ?? false) ||
                p.Id.ToString() == q.TrimStart('0'));

        var list = results.ToList();
        PokemonView.ItemsSource = list;
        CountLabel.Text = $"{list.Count} Pokémon";
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
