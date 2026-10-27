using PokedexGen1.Services;
using Pokemon_CollectionView.Models.Models;

namespace PokedexGen1;

public partial class MainPage : ContentPage
{
    readonly List<Pokemon> _all = PokemonData.GetAll();
    string _activeType = "All";

    public List<TypeFilterModel> TypeFilters { get; set; }

    public MainPage()
    {
        InitializeComponent();
        TypeFilters = TypeFilterService.CreateFilters(_all);
        BindingContext = this;
        PokemonView.ItemsSource = _all;
    }

    async void OnTypeFilterTapped(object? sender, TappedEventArgs e)
    {
        if (sender is VisualElement visual)
        {
            _ = visual.ScaleToAsync(0.92, 50)
                      .ContinueWith(_ => visual.ScaleToAsync(1.0, 70), TaskScheduler.FromCurrentSynchronizationContext());
        }

        var filter = (e.Parameter as TypeFilterModel) ?? ((sender as VisualElement)?.BindingContext as TypeFilterModel);
        if (filter is null) return;

        SelectType(filter.Name);
    }

    void OnResetTypeClicked(object? sender, EventArgs e)
    {
        SelectType("All");
    }

    void SelectType(string typeName)
    {
        _activeType = typeName;

        TypeFilterModel? current = null;
        foreach (var item in TypeFilters)
        {
            bool isCurrent = item.Name.Equals(typeName, StringComparison.OrdinalIgnoreCase);
            item.IsSelected = isCurrent;
            if (isCurrent) current = item;
        }

        UpdateActiveFilterHeader(current);
        ApplyFilters();
    }

    void UpdateActiveFilterHeader(TypeFilterModel? active)
    {
        if (active == null || active.Name.Equals("All", StringComparison.OrdinalIgnoreCase))
        {
            ActiveFilterBadge.BackgroundColor = Color.FromArgb("#F1F5F9");
            ActiveFilterBadge.Stroke = Color.FromArgb("#CBD5E1");
            ActiveFilterIcon.Text = "🔘";
            ActiveFilterLabel.Text = $"ALL ({_all.Count})";
            ActiveFilterLabel.TextColor = Color.FromArgb("#334155");
            ActiveFilterResetPrompt.IsVisible = false;
        }
        else
        {
            ActiveFilterBadge.BackgroundColor = active.PrimaryColor.WithAlpha(0.15f);
            ActiveFilterBadge.Stroke = active.PrimaryColor;
            ActiveFilterIcon.Text = active.Icon;
            ActiveFilterLabel.Text = $"{active.Name.ToUpperInvariant()} ({active.Count})";
            ActiveFilterLabel.TextColor = active.PrimaryColor;
            ActiveFilterResetPrompt.IsVisible = true;
        }
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
