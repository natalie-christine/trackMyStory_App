using static System.Net.Mime.MediaTypeNames;

namespace tMS.Components;

public partial class ColorPicker : ContentView
{
    public static readonly BindableProperty RedProperty =
       BindableProperty.Create(nameof(Red), typeof(Double), typeof(ColorPicker), 0.0);
    public static readonly BindableProperty GreenProperty =
       BindableProperty.Create(nameof(Green), typeof(Double), typeof(ColorPicker), 0.0);
    public static readonly BindableProperty BlueProperty =
       BindableProperty.Create(nameof(Blue), typeof(Double), typeof(ColorPicker), 0.0);
    public ColorPicker()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public event EventHandler? ColorChanged;

    public double Red
    {
        get { return (double)GetValue(RedProperty); }
        set { SetValue(RedProperty, value); }
    }

    public double Green
    {
        get { return (double)GetValue(GreenProperty); }
        set { SetValue(GreenProperty, value); }
    }

    public double Blue
    {
        get { return (double)GetValue(BlueProperty); }
        set { SetValue(BlueProperty, value); }
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        ColorChanged?.Invoke(this, EventArgs.Empty);
    }
}


