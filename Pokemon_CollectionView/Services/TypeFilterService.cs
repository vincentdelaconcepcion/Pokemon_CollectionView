using Pokemon_CollectionView.Models.Models;

namespace PokedexGen1.Services;

public static class TypeFilterService
{
    public static List<TypeFilterModel> CreateFilters(List<Pokemon> allPokemon)
    {
        var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (var p in allPokemon)
        {
            if (!string.IsNullOrEmpty(p.Type1))
                counts[p.Type1] = counts.GetValueOrDefault(p.Type1, 0) + 1;
            if (!string.IsNullOrEmpty(p.Type2))
                counts[p.Type2] = counts.GetValueOrDefault(p.Type2, 0) + 1;
        }

        return new List<TypeFilterModel>
        {
            new()
            {
                Name = "All",
                Icon = "🔘",
                Subtitle = "ALL POKÉMON",
                PrimaryColor = Color.FromArgb("#334155"),
                SecondaryColor = Color.FromArgb("#0F172A"),
                LightBackgroundColor = Color.FromArgb("#F8FAFC"),
                UnselectedBorderColor = Color.FromArgb("#CBD5E1"),
                Count = allPokemon.Count,
                IsSelected = true
            },
            new()
            {
                Name = "Fire",
                Icon = "🔥",
                Subtitle = "BLAZE · HEAT",
                PrimaryColor = Color.FromArgb("#F05030"),
                SecondaryColor = Color.FromArgb("#B91C1C"),
                LightBackgroundColor = Color.FromArgb("#FFF5F2"),
                UnselectedBorderColor = Color.FromArgb("#FECACA"),
                Count = counts.GetValueOrDefault("Fire", 0)
            },
            new()
            {
                Name = "Water",
                Icon = "💧",
                Subtitle = "AQUA · WAVE",
                PrimaryColor = Color.FromArgb("#2563EB"),
                SecondaryColor = Color.FromArgb("#1D4ED8"),
                LightBackgroundColor = Color.FromArgb("#EFF6FF"),
                UnselectedBorderColor = Color.FromArgb("#BFDBFE"),
                Count = counts.GetValueOrDefault("Water", 0)
            },
            new()
            {
                Name = "Grass",
                Icon = "🍃",
                Subtitle = "FLORA · NATURE",
                PrimaryColor = Color.FromArgb("#16A34A"),
                SecondaryColor = Color.FromArgb("#15803D"),
                LightBackgroundColor = Color.FromArgb("#F0FDF4"),
                UnselectedBorderColor = Color.FromArgb("#BBF7D0"),
                Count = counts.GetValueOrDefault("Grass", 0)
            },
            new()
            {
                Name = "Electric",
                Icon = "⚡",
                Subtitle = "VOLT · SPARK",
                PrimaryColor = Color.FromArgb("#F59E0B"),
                SecondaryColor = Color.FromArgb("#D97706"),
                LightBackgroundColor = Color.FromArgb("#FFFBEB"),
                UnselectedBorderColor = Color.FromArgb("#FDE68A"),
                Count = counts.GetValueOrDefault("Electric", 0),
                IsLightType = true
            },
            new()
            {
                Name = "Psychic",
                Icon = "🔮",
                Subtitle = "ESPER · MIND",
                PrimaryColor = Color.FromArgb("#EC4899"),
                SecondaryColor = Color.FromArgb("#BE185D"),
                LightBackgroundColor = Color.FromArgb("#FDF2F8"),
                UnselectedBorderColor = Color.FromArgb("#FBCFE8"),
                Count = counts.GetValueOrDefault("Psychic", 0)
            },
            new()
            {
                Name = "Ice",
                Icon = "❄️",
                Subtitle = "CRYO · FROST",
                PrimaryColor = Color.FromArgb("#06B6D4"),
                SecondaryColor = Color.FromArgb("#0E7490"),
                LightBackgroundColor = Color.FromArgb("#ECFEFF"),
                UnselectedBorderColor = Color.FromArgb("#A5F3FC"),
                Count = counts.GetValueOrDefault("Ice", 0)
            },
            new()
            {
                Name = "Dragon",
                Icon = "🐲",
                Subtitle = "MYTHIC · WYRM",
                PrimaryColor = Color.FromArgb("#4F46E5"),
                SecondaryColor = Color.FromArgb("#3730A3"),
                LightBackgroundColor = Color.FromArgb("#EEF2FF"),
                UnselectedBorderColor = Color.FromArgb("#C7D2FE"),
                Count = counts.GetValueOrDefault("Dragon", 0)
            },
            new()
            {
                Name = "Ghost",
                Icon = "👻",
                Subtitle = "ASTRAL · SHADOW",
                PrimaryColor = Color.FromArgb("#7C3AED"),
                SecondaryColor = Color.FromArgb("#581C87"),
                LightBackgroundColor = Color.FromArgb("#FAF5FF"),
                UnselectedBorderColor = Color.FromArgb("#DDD6FE"),
                Count = counts.GetValueOrDefault("Ghost", 0)
            },
            new()
            {
                Name = "Poison",
                Icon = "☠️",
                Subtitle = "TOXIC · BIO",
                PrimaryColor = Color.FromArgb("#9333EA"),
                SecondaryColor = Color.FromArgb("#6B21A8"),
                LightBackgroundColor = Color.FromArgb("#FAF5FF"),
                UnselectedBorderColor = Color.FromArgb("#E9D5FF"),
                Count = counts.GetValueOrDefault("Poison", 0)
            },
            new()
            {
                Name = "Fighting",
                Icon = "🥊",
                Subtitle = "COMBAT · BRAWL",
                PrimaryColor = Color.FromArgb("#DC2626"),
                SecondaryColor = Color.FromArgb("#991B1B"),
                LightBackgroundColor = Color.FromArgb("#FEF2F2"),
                UnselectedBorderColor = Color.FromArgb("#FECACA"),
                Count = counts.GetValueOrDefault("Fighting", 0)
            },
            new()
            {
                Name = "Ground",
                Icon = "⛰️",
                Subtitle = "TERRA · EARTH",
                PrimaryColor = Color.FromArgb("#D97706"),
                SecondaryColor = Color.FromArgb("#92400E"),
                LightBackgroundColor = Color.FromArgb("#FFFBEB"),
                UnselectedBorderColor = Color.FromArgb("#FDE68A"),
                Count = counts.GetValueOrDefault("Ground", 0)
            },
            new()
            {
                Name = "Flying",
                Icon = "🪽",
                Subtitle = "AERO · SKY",
                PrimaryColor = Color.FromArgb("#8B5CF6"),
                SecondaryColor = Color.FromArgb("#6D28D9"),
                LightBackgroundColor = Color.FromArgb("#F5F3FF"),
                UnselectedBorderColor = Color.FromArgb("#DDD6FE"),
                Count = counts.GetValueOrDefault("Flying", 0)
            },
            new()
            {
                Name = "Bug",
                Icon = "🪲",
                Subtitle = "CHITIN · FOREST",
                PrimaryColor = Color.FromArgb("#84CC16"),
                SecondaryColor = Color.FromArgb("#4D7C0F"),
                LightBackgroundColor = Color.FromArgb("#F7FEE7"),
                UnselectedBorderColor = Color.FromArgb("#D9F99D"),
                Count = counts.GetValueOrDefault("Bug", 0)
            },
            new()
            {
                Name = "Rock",
                Icon = "🪨",
                Subtitle = "MINERAL · STONE",
                PrimaryColor = Color.FromArgb("#B45309"),
                SecondaryColor = Color.FromArgb("#78350F"),
                LightBackgroundColor = Color.FromArgb("#FFFBEB"),
                UnselectedBorderColor = Color.FromArgb("#FDE68A"),
                Count = counts.GetValueOrDefault("Rock", 0)
            },
            new()
            {
                Name = "Fairy",
                Icon = "✨",
                Subtitle = "COSMIC · CHARM",
                PrimaryColor = Color.FromArgb("#F43F5E"),
                SecondaryColor = Color.FromArgb("#BE123C"),
                LightBackgroundColor = Color.FromArgb("#FFF1F2"),
                UnselectedBorderColor = Color.FromArgb("#FECDD3"),
                Count = counts.GetValueOrDefault("Fairy", 0)
            },
            new()
            {
                Name = "Steel",
                Icon = "⚙️",
                Subtitle = "ALLOY · METAL",
                PrimaryColor = Color.FromArgb("#64748B"),
                SecondaryColor = Color.FromArgb("#475569"),
                LightBackgroundColor = Color.FromArgb("#F8FAFC"),
                UnselectedBorderColor = Color.FromArgb("#CBD5E1"),
                Count = counts.GetValueOrDefault("Steel", 0)
            },
            new()
            {
                Name = "Normal",
                Icon = "🎯",
                Subtitle = "BASIC · BALANCE",
                PrimaryColor = Color.FromArgb("#94A3B8"),
                SecondaryColor = Color.FromArgb("#64748B"),
                LightBackgroundColor = Color.FromArgb("#F8FAFC"),
                UnselectedBorderColor = Color.FromArgb("#E2E8F0"),
                Count = counts.GetValueOrDefault("Normal", 0)
            }
        };
    }
}
