namespace tMS.Helper;

public class ColorHelper
{
    public ColorHelper()
    {

    }

    public static Color CreateRandomColor()
    {
        Random random = new();

        var red = random.NextDouble();
        var green = random.NextDouble();
        var blue = random.NextDouble();

        return Color.FromRgb(red, green, blue);
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
                Application.Current.Resources[p + "Text"] = c.GetLuminosity() > 0.5 ?
                        c.WithLuminosity(0f).ToHex() :
                        c.WithLuminosity(1f).ToHex();

                Application.Current.Resources[p + "Brush"] = new SolidColorBrush(c);
            }
        }

        Color RotateColor(Color c, float r)
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
        return Color.Parse(Application.Current.Resources["DynamicPrimary"].ToString());
    }

    public static Color GetColor2()
    {
        return Color.Parse(Application.Current.Resources["DynamicSecondary"].ToString());
    }
}
