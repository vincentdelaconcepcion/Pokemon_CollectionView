# Kanto Pokédex – .NET MAUI CollectionView demo (Gen 1)

## Setup
1. `dotnet new maui -n PokedexGen1`
2. Copy these files over the template: AppShell.xaml(.cs), MainPage.xaml(.cs); add DetailPage.xaml(.cs), Models/, Services/.
3. Run on an Android emulator/device (internet required for images and details).

## How it works
- MainPage: CollectionView, 2-column GridItemsLayout, 151 Gen 1 Pokémon, search by name/type/number, EmptyView.
- Tapping a card -> SelectionChanged -> Shell.GoToAsync(DetailPage, { "Pokemon": selectedItem }).
- DetailPage: receives the selected object via [QueryProperty], shows artwork/types immediately,
  then loads height, weight, Pokédex entry and base stats from PokeAPI (pokeapi.co).
