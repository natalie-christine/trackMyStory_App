using System.Windows.Input;

namespace tMS.Components;

public partial class DashboardTile : ContentView
{

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(DashboardTile));

    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(DashboardTile));

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(DashboardTile));

    public DashboardTile()
	{
		InitializeComponent();
        container.BindingContext = this;

    }

    public event EventHandler? Clicked;

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public ImageSource Icon
    {
        get { return (ImageSource)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, EventArgs.Empty);
        Command?.Execute(null);
    }
}