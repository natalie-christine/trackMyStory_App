namespace tMS.Layouts;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

public class ResponsiveLayout : Layout
{
    public static readonly BindableProperty HorizontalThresholdProperty =
        BindableProperty.Create(nameof(HorizontalThreshold), typeof(int), typeof(ResponsiveLayoutManager), 800);

    public static readonly BindableProperty HorizontalSpacingProperty =
            BindableProperty.Create(nameof(HorizontalSpacing), typeof(int), typeof(ResponsiveLayoutManager), 20);

    public static readonly BindableProperty VerticalSpacingProperty =
            BindableProperty.Create(nameof(VerticalSpacing), typeof(int), typeof(ResponsiveLayoutManager), 20);

    public int HorizontalThreshold
    {
        get { return (int)GetValue(HorizontalThresholdProperty); }
        set { SetValue(HorizontalThresholdProperty, value); }
    }

    public int HorizontalSpacing
    {
        get { return (int)GetValue(HorizontalSpacingProperty); }
        set { SetValue(HorizontalSpacingProperty, value); }
    }

    public int VerticalSpacing
    {
        get { return (int)GetValue(VerticalSpacingProperty); }
        set { SetValue(VerticalSpacingProperty, value); }
    }

    protected override ILayoutManager CreateLayoutManager()
    {
        return new ResponsiveLayoutManager(this)
        {
            HorizontalThreshold = HorizontalThreshold,
            HorizontalSpacing = HorizontalSpacing,
            VerticalSpacing = VerticalSpacing
        };
    }
}
