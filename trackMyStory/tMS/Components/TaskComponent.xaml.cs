namespace tMS.Components;

public partial class TaskComponent : ContentView
{
    public static readonly BindableProperty NameProperty =
         BindableProperty.Create(nameof(Name), typeof(string), typeof(TaskComponent), "", BindingMode.TwoWay);

    public static readonly BindableProperty HexColorProperty =
         BindableProperty.Create(nameof(HexColor), typeof(string), typeof(TaskComponent), "");

    public string Name
    {
        get { return (string)GetValue(NameProperty); }
        set
        {
            SetValue(NameProperty, value);

        }
    }

    public string HexColor
    {
        get { return (string)GetValue(HexColorProperty); }
        set
        {
            SetValue(HexColorProperty, value);

        }
    }

    public event EventHandler? SaveClicked;
    public event EventHandler? CancelClicked;

    public TaskComponent()
	{
		InitializeComponent();
        container.BindingContext = this;

    }

    private void ButtonSave_Clicked(object sender, EventArgs e)
    {
        SaveClicked?.Invoke(this, EventArgs.Empty);
    }

    private void ButtonCancel_Clicked(object sender, EventArgs e)
    {
        CancelClicked?.Invoke(this, EventArgs.Empty);


    }
}