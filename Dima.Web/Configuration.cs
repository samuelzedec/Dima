using MudBlazor;
using MudBlazor.Utilities;

namespace Dima.Web;

public static class Configuration
{
    public const string HttpClientName = "dima";
    public static string BackendUrl { get; set; } = string.Empty;
    
    public static readonly MudTheme Theme = new()
    {
        Typography = new()
        {
            Default = new DefaultTypography() { FontFamily = ["Releway", "sans-serif"] }
        },
        
        PaletteLight = new()
        {
            Primary = "#1EFA2D",
            PrimaryContrastText = new MudColor("#000000"),
            Secondary = Colors.LightGreen.Darken3,
            Background = Colors.Gray.Lighten4,
            AppbarBackground = "#1EFA2D",
            AppbarText = Colors.Shades.Black,
            TextPrimary = Colors.Shades.Black,
            DrawerText = Colors.Shades.Black,
            DrawerBackground = Colors.Green.Darken4
        },
        
        PaletteDark = new ()
        {
            Primary = Colors.LightGreen.Accent3,
            Secondary = Colors.LightGreen.Darken3,
            AppbarBackground = Colors.LightGreen.Accent3,
            AppbarText = Colors.Shades.Black,
            PrimaryContrastText = new MudColor("#000000"),
        }
    };
}