namespace tMS.Helper;

public class ColorHelper
{
    public ColorHelper()
    {

    }

    public static Color CreateRandomColor()
    {
        Random random = new();

        var red = 0.2 + (random.NextDouble() * 0.6);
        var green = 0.2 + (random.NextDouble() * 0.6);
        var blue = 0.2 + (random.NextDouble() * 0.6);

        return Color.FromRgb(red, green, blue);
    }

    public static Color CreateTextColor(Color color)
    {
        return color.GetLuminosity() > 0.5 ?
                        color.WithLuminosity(0f) :
                        color.WithLuminosity(1f);
    }

    public static void SetColor(Color? color, Color? color2)
    {
        static void SetColors(string p, Color c)
        {
            if (Application.Current != null)
            {
                Application.Current.Resources[p] = c.ToHex();
                Application.Current.Resources[p + "Light"] = c.WithLuminosity(c.GetLuminosity() + 0.2f).ToHex();
                Application.Current.Resources[p + "Dark"] = c.WithLuminosity(c.GetLuminosity() - 0.2f).ToHex();
                Application.Current.Resources[p + "Text"] = CreateTextColor(c).ToHex();

                Application.Current.Resources[p + "Brush"] = new SolidColorBrush(c);
            }
        }

        static Color RotateColor(Color c, float r)
        {
            c.ToHsl(out var h, out var s, out var l);
            h += r;
            h %= 1.0f;
            return Color.FromHsla(h, s, l);
        }

        if (color != null)
        {
            SetColors("DynamicPrimary", color);
            SetColors("DynamicTertiary", RotateColor(color, 0.25f));
        }
        if (color2 != null)
        {
            SetColors("DynamicSecondary", color2);
            SetColors("DynamicQuartary", RotateColor(color2, 0.25f));
        }
    }

    public static Color GetColor1()
    {
        return Color.Parse(Application.Current!.Resources["DynamicPrimary"].ToString());
    }

    public static Color GetColor2()
    {
        return Color.Parse(Application.Current!.Resources["DynamicSecondary"].ToString());
    }

    public static void ToggleDarkMode()
    {
        if (Application.Current!.RequestedTheme == AppTheme.Light)
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
        }
        else
        {
            Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}
