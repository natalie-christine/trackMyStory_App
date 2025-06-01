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

    private void OnColorComponentChanged()
    {
        // Hier können Sie beliebige Logik für ValueChanged einbauen,
        // z.B. ein Event auslösen oder weitere Aktionen durchführen.
        ColorChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? ColorChanged;

    public double Red
    {
        get { return (double)GetValue(RedProperty); }
        set
        {
            if (Red != value)
            {
                SetValue(RedProperty, value);
                OnColorComponentChanged();
            }
        }
    }

    public double Green
    {
        get { return (double)GetValue(GreenProperty); }
        set
        {
            if (Green != value)
            {
                SetValue(GreenProperty, value);
                OnColorComponentChanged();
            }
        }
    }

    public double Blue
    {
        get { return (double)GetValue(BlueProperty); }
        set
        {
            if (Blue != value)
            {
                SetValue(BlueProperty, value);
                OnColorComponentChanged();
            }
        }
    }
  
}


