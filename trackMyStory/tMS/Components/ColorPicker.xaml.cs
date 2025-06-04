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
    public static readonly BindableProperty LabelClassProperty =
         BindableProperty.Create(nameof(LabelClass), typeof(string), typeof(ColorPicker), "", propertyChanged: OnLabelClassChanged);

    public ColorPicker()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public event EventHandler? ColorChanged;

    public string LabelClass
    {
        get { return (string)GetValue(LabelClassProperty); }
        set
        {
            SetValue(LabelClassProperty, value);

        }
    }

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

    public Color SelectedColor { get; internal set; }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        ColorChanged?.Invoke(this, EventArgs.Empty);
    }

    private static void OnLabelClassChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ColorPicker)bindable;
        // Beispiel: Zugriff auf das Label und Aktualisierung der StyleClass
        if (control.labelRed != null && newValue is string styleClass)
        {
            control.labelRed.StyleClass = new List<string> { styleClass };

        }
        if (control.labelGreen != null && newValue is string styleClassGreen)
        {
            control.labelGreen.StyleClass = new List<string> { styleClassGreen };
        }

        if (control.labelBlue != null && newValue is string styleClassBlue)
        {
            control.labelBlue.StyleClass = new List<string> { styleClassBlue };
        }

        if (control.sliderRed != null && newValue is string styleRed)
        {
            control.sliderRed.StyleClass = new List<string> { styleRed };
        }

        if (control.sliderGreen != null && newValue is string styleGreen)
        {
            control.sliderGreen.StyleClass = new List<string> { styleGreen };
        }

        if (control.sliderBlue != null && newValue is string styleBlue)
        {
            control.sliderBlue.StyleClass = new List<string> { styleBlue };
        }
    }
}
       


