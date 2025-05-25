using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace tMS.Components;

public partial class ResponsiveIconButton : ContentView
{
    public static readonly BindableProperty GlyphProperty =
        BindableProperty.Create(nameof(Glyph), typeof(string), typeof(ResponsiveIconButton), "");

    public static readonly BindableProperty GlyphFontFamilyProperty =
        BindableProperty.Create(nameof(GlyphFontFamily), typeof(string), typeof(ResponsiveIconButton), "");

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(ResponsiveIconButton), "");

    public static readonly BindableProperty ThresholdProperty =
        BindableProperty.Create(nameof(Threshold), typeof(int), typeof(ResponsiveIconButton), 800);

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ResponsiveIconButton));

    public event EventHandler? Clicked;

    public ResponsiveIconButton()
    {
        InitializeComponent();
        BindingContext = this;
    }

    [System.ComponentModel.TypeConverter(typeof(ListStringTypeConverter))]
    public IList<string> ButtonStyleClass
    {
        get { return button.StyleClass; }
        set { button.StyleClass = value; }
    }

    public string Glyph
    {
        get { return (string)GetValue(GlyphProperty); }
        set { SetValue(GlyphProperty, value); }
    }

    public string GlyphFontFamily
    {
        get { return (string)GetValue(GlyphFontFamilyProperty); }
        set { SetValue(GlyphFontFamilyProperty, value); }
    }

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public int Threshold
    {
        get { return (int)GetValue(ThresholdProperty); }
        set { SetValue(ThresholdProperty, value); }
    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, e);
    }
}