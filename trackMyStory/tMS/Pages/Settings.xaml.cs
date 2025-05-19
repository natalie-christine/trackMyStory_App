using tMS.Helper;

namespace tMS.Pages;

public partial class Settings : ContentPage
{

    bool isRandom = false;
    public Settings()
	{
		InitializeComponent();

        Color color = ColorHelper.GetColor1();
        Color color2 = ColorHelper.GetColor2();

        setSld1Color(color);
        setSld2Color(color2);
    }

    private void setSld1Color(Color color)
    {
        sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;
    }

    private void setSld2Color(Color color)
    {
        sldRed2.Value = color.Red;
        sldGreen2.Value = color.Green;
        sldBlue2.Value = color.Blue;
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            Color color = Color.FromRgb(sldRed.Value, sldGreen.Value, sldBlue.Value);
            Color color2 = Color.FromRgb(sldRed2.Value, sldGreen2.Value, sldBlue2.Value);
            ColorHelper.SetColor(color, color2);
        }
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        isRandom = true;

        Color color = ColorHelper.CreateRandomColor();
        ColorHelper.SetColor(color, null);
        setSld1Color(color);

        isRandom = false;
    }

    private void btnRandom2_Clicked(object sender, EventArgs e)
    {
        isRandom = true;

        Color color = ColorHelper.CreateRandomColor();
        ColorHelper.SetColor(null, color);
        setSld2Color(color);

        isRandom = false;
    }
}
