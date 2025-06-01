using tMS.Helper;
using tMS.ViewModels;

namespace tMS.Pages;

public partial class Settings : ContentPage
{
    private SbLoginViewModel sbLoginViewModel;

    bool isRandom = false;
    public Settings(SbLoginViewModel _sbLoginViewModel)
	{
		InitializeComponent();

        sbLoginViewModel = _sbLoginViewModel;
        BindingContext = sbLoginViewModel;

        Color color = ColorHelper.GetColor1();
        Color color2 = ColorHelper.GetColor2();

        setSld1Color(color);
        setSld2Color(color2);
    }

    private void setSld1Color(Color color)
    {
        ColorPickerSettings1.Red = color.Red;
        ColorPickerSettings1.Green = color.Green;
        ColorPickerSettings1.Blue = color.Blue;
    }

    private void setSld2Color(Color color)
    {
        ColorPickerSettings2.Red = color.Red;
        ColorPickerSettings2.Green = color.Green;
        ColorPickerSettings2.Blue = color.Blue;
    }

    private void Slider_ValueChanged(object sender, EventArgs e)
    {
        if (!isRandom)
        {
            Color color = Color.FromRgb(ColorPickerSettings1.Red, ColorPickerSettings1.Green, ColorPickerSettings1.Blue);
            Color color2 = Color.FromRgb(ColorPickerSettings2.Red, ColorPickerSettings2.Green, ColorPickerSettings2.Blue);
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

    private void btnSaveColor1Clicked(object sender, EventArgs e)
    {
        sbLoginViewModel.UserConfig!.ColorPrimary = ColorHelper.GetColor1().ToArgbHex();
        sbLoginViewModel.SaveUserConfigCommand.Execute(null);
    }

    private void btnSaveColor2Clicked(object sender, EventArgs e)
    {
        sbLoginViewModel.UserConfig!.ColorSecondary = ColorHelper.GetColor2().ToArgbHex();
        sbLoginViewModel.SaveUserConfigCommand.Execute(null);
    }

    private void btnBackColor1Clicked(object sender, EventArgs e)
    {
        if (sbLoginViewModel.UserConfig!.ColorPrimary != null)
        {
            Color color = Color.FromArgb(sbLoginViewModel.UserConfig.ColorPrimary);
            ColorHelper.SetColor(color, null);
            setSld1Color(color);
        }
    }

    private void btnBackColor2Clicked(object sender, EventArgs e)
    {
        if (sbLoginViewModel.UserConfig!.ColorSecondary != null)
        {
            Color color = Color.FromArgb(sbLoginViewModel.UserConfig.ColorSecondary);
            ColorHelper.SetColor(null, color);
            setSld2Color(color);
        }
    }
}
