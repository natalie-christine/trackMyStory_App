using tMS.Helper;
using tMS.ViewModels;

namespace tMS.Pages;

public partial class Settings : ContentPage
{
    private SupabaseViewModel supabaseViewModel;

    bool isRandom = false;
    public Settings(SupabaseViewModel _supabaseViewModel)
	{
		InitializeComponent();

        supabaseViewModel = _supabaseViewModel;
        BindingContext = supabaseViewModel;

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

    private void btnSaveColor1Clicked(object sender, EventArgs e)
    {
        supabaseViewModel.UserConfig!.ColorPrimary = ColorHelper.GetColor1().ToArgbHex();
        supabaseViewModel.SaveUserConfigCommand.Execute(null);
    }

    private void btnSaveColor2Clicked(object sender, EventArgs e)
    {
        supabaseViewModel.UserConfig!.ColorSecondary = ColorHelper.GetColor2().ToArgbHex();
        supabaseViewModel.SaveUserConfigCommand.Execute(null);
    }

    private void btnBackColor1Clicked(object sender, EventArgs e)
    {
        if (supabaseViewModel.UserConfig!.ColorPrimary != null)
        {
            Color color = Color.FromArgb(supabaseViewModel.UserConfig.ColorPrimary);
            ColorHelper.SetColor(color, null);
            setSld1Color(color);
        }
    }

    private void btnBackColor2Clicked(object sender, EventArgs e)
    {
        if (supabaseViewModel.UserConfig!.ColorSecondary != null)
        {
            Color color = Color.FromArgb(supabaseViewModel.UserConfig.ColorSecondary);
            ColorHelper.SetColor(null, color);
            setSld2Color(color);
        }
    }
}
