namespace tMS.Pages;

public partial class Settings : ContentPage
{

    bool isRandom = false;
    public Settings()
	{
		InitializeComponent();
	}


    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        isRandom = true;
        Random random = new Random();
        var red = random.NextDouble();
        var green = random.NextDouble();
        var blue = random.NextDouble();

        Color color = Color.FromRgb(red, green, blue);
        SetColor(color);

        sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;

        isRandom = false;
    }

    private void SetColor(Color color)
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