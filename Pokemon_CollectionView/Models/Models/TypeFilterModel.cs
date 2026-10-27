using System.ComponentModel;
using Microsoft.Maui.Controls.Shapes;

namespace Pokemon_CollectionView.Models.Models;

public class TypeFilterModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public string Name { get; set; } = "";
    public string Icon { get; set; } = "";
    public string Subtitle { get; set; } = "";
    public Color PrimaryColor { get; set; } = Colors.Gray;
    public Color SecondaryColor { get; set; } = Colors.DarkGray;
    public Color LightBackgroundColor { get; set; } = Colors.White;
    public Color UnselectedBorderColor { get; set; } = Color.FromArgb("#E2E8F0");
    public int Count { get; set; }
    public bool IsLightType { get; set; }

    bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected != value)
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
                OnPropertyChanged(nameof(CardBackground));
                OnPropertyChanged(nameof(CardBorderColor));
                OnPropertyChanged(nameof(CardBorderThickness));
                OnPropertyChanged(nameof(NameColor));
                OnPropertyChanged(nameof(SubtitleColor));
                OnPropertyChanged(nameof(BadgeBackground));
                OnPropertyChanged(nameof(BadgeTextColor));
                OnPropertyChanged(nameof(IconContainerBackground));
                OnPropertyChanged(nameof(IconBorderColor));
                OnPropertyChanged(nameof(ActiveIndicatorVisible));
            }
        }
    }

    public Brush CardBackground => IsSelected
        ? new LinearGradientBrush
        {
            StartPoint = new Point(0, 0),
            EndPoint = new Point(1, 1),
            GradientStops = new GradientStopCollection
            {
                new GradientStop(PrimaryColor, 0.0f),
                new GradientStop(SecondaryColor, 1.0f)
            }
        }
        : new SolidColorBrush(LightBackgroundColor);

    public Color CardBorderColor => IsSelected ? PrimaryColor : UnselectedBorderColor;
    public double CardBorderThickness => IsSelected ? 2.0 : 1.0;

    public Color NameColor => IsSelected
        ? (IsLightType ? Color.FromArgb("#0F172A") : Colors.White)
        : Color.FromArgb("#1E293B");

    public Color SubtitleColor => IsSelected
        ? (IsLightType ? Color.FromArgb("#334155") : Color.FromRgba(255, 255, 255, 210))
        : Color.FromArgb("#64748B");

    public Brush IconContainerBackground => IsSelected
        ? new SolidColorBrush(IsLightType ? Color.FromRgba(0, 0, 0, 25) : Color.FromRgba(255, 255, 255, 50))
        : new SolidColorBrush(PrimaryColor.WithAlpha(0.15f));

    public Color IconBorderColor => IsSelected
        ? (IsLightType ? Color.FromRgba(0, 0, 0, 40) : Color.FromRgba(255, 255, 255, 100))
        : PrimaryColor.WithAlpha(0.35f);

    public Color BadgeBackground => IsSelected
        ? (IsLightType ? Color.FromRgba(0, 0, 0, 40) : Color.FromRgba(255, 255, 255, 60))
        : PrimaryColor;

    public Color BadgeTextColor => (IsSelected && IsLightType)
        ? Color.FromArgb("#0F172A")
        : Colors.White;

    public bool ActiveIndicatorVisible => IsSelected;

    void OnPropertyChanged(string propName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
}
