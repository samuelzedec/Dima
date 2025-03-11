using MudBlazor;

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
            Secondary = Colors.LightGreen.Darken3,
            Background = Colors.Gray.Lighten4,
            AppbarBackground = "#1EFA2D",
            AppbarText = Colors.Shades.Black,
            TextPrimary = Colors.Shades.Black,
            PrimaryContrastText = Colors.Shades.Black,
            DrawerText = Colors.Shades.Black,
            DrawerBackground = Colors.LightGreen.Lighten4
        },
        
        PaletteDark = new ()
        {
            Primary = Colors.LightGreen.Accent3,
            Secondary = Colors.LightGreen.Darken3,
            AppbarBackground = Colors.LightGreen.Accent3,
            AppbarText = Colors.Shades.Black
        }
    };
}