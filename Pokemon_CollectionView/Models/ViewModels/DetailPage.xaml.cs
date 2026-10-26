using PokedexGen1.Services;
using Pokemon_CollectionView.Models.Models;

namespace PokedexGen1;

[QueryProperty(nameof(Pokemon), "Pokemon")]
public partial class DetailPage : ContentPage
{
    Pokemon? _pokemon;

    public Pokemon? Pokemon
    {
        get => _pokemon;
        set { _pokemon = value; if (value != null) ShowBasics(value); }
    }

    public DetailPage() => InitializeComponent();

    void ShowBasics(Pokemon p)
    {
        Title = p.Name;
        NameLabel.Text = p.Name;

        NumberLabel.Text = p.NumberText;
        Artwork.Source = p.ImageUrl;
        Hero.BackgroundColor = p.Type1Color;

        TypeRow.Children.Clear();
        TypeRow.Children.Add(MakeBadge(p.Type1, p.Type1Color));
        if (p.HasType2) TypeRow.Children.Add(MakeBadge(p.Type2!, p.Type2Color));
    }

    static Border MakeBadge(string text, Color color) => new()
    {
        BackgroundColor = color,
        Padding = new Thickness(14, 4),
        StrokeThickness = 0,
        StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle { CornerRadius = 12 },
        Content = new Label { Text = text, TextColor = Colors.White, FontAttributes = FontAttributes.Bold }
    };

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_pokemon is null) return;

        Loader.IsRunning = Loader.IsVisible = true;
        var details = await PokeApiService.GetDetailsAsync(_pokemon.Id);
        Loader.IsRunning = Loader.IsVisible = false;

        if (details is null)
        {
            DescriptionLabel.Text = "Couldn't load extra details. Check your internet connection.";
            return;
        }

        DescriptionLabel.Text = details.Description;
        HeightLabel.Text = $"{details.HeightM:0.0} m";
        WeightLabel.Text = $"{details.WeightKg:0.0} kg";
        BindableLayout.SetItemsSource(StatsLayout, details.Stats);
    }

    async void OnBackClicked(object? sender, EventArgs e) => await Shell.Current.GoToAsync("..");
}
