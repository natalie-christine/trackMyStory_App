namespace tMS.Helper;

public class ColorHelper
{
    public ColorHelper()
    {

    }


    public static void SetColor(Color color)
    {
        void SetColors(string p, Color c)
        {
            Application.Current.Resources[p] = c.ToHex();
            Application.Current.Resources[p + "Light"] = c.WithLuminosity(c.GetLuminosity() + 0.2f).ToHex();
            Application.Current.Resources[p + "Dark"] = c.WithLuminosity(c.GetLuminosity() - 0.2f).ToHex();
            Application.Current.Resources[p + "Text"] = c.GetLuminosity() > 0.5 ?
                    c.WithLuminosity(0f).ToHex() :
                    c.WithLuminosity(1f).ToHex();

            Application.Current.Resources[p + "Brush"] = new SolidColorBrush(c);
        }

        Color RotateColor(Color c, float r)
        {
            c.ToHsl(out var h, out var s, out var l);
            h += r;
            h %= 1.0f;
            return Color.FromHsla(h, s, l);
        }

        SetColors("DynamicPrimary", color);
        SetColors("DynamicSecondary", RotateColor(color, 0.50f));
        SetColors("DynamicTertiary", RotateColor(color, 0.25f));
        SetColors("DynamicQuartary", RotateColor(color, 0.75f));

     
    }



}