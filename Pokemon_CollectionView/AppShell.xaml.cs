namespace PokedexGen1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
    }

    private void Grid_SizeChanged(object sender, EventArgs e)
    {

    }
}
