using tMS.Helper;

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
            ColorHelper.SetColor(color);
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
        ColorHelper.SetColor(color);

        sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;

        isRandom = false;
    }

}