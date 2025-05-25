namespace tMS.Behaviors;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ScreenSizeBehavior : Behavior<View>
{
    public static readonly BindableProperty ThresholdProperty =
        BindableProperty.Create(nameof(Threshold), typeof(int), typeof(ScreenSizeBehavior), 800);

    public static readonly BindableProperty SmallStyleProperty =
        BindableProperty.Create(nameof(SmallStyle), typeof(Style), typeof(ScreenSizeBehavior));

    public static readonly BindableProperty LargeStyleProperty =
        BindableProperty.Create(nameof(LargeStyle), typeof(Style), typeof(ScreenSizeBehavior));

    public int Threshold
    {
        get { return (int)GetValue(ThresholdProperty); }
        set { SetValue(ThresholdProperty, value); }
    }

    public Style SmallStyle
    {
        get { return (Style)GetValue(SmallStyleProperty); }
        set { SetValue(SmallStyleProperty, value); }
    }

    public Style LargeStyle
    {
        get { return (Style)GetValue(LargeStyleProperty); }
        set { SetValue(LargeStyleProperty, value); }
    }

    private View? bindable;

    protected override void OnAttachedTo(View _bindable)
    {
        bindable = _bindable;

        base.OnAttachedTo(bindable);

        if (App.Current != null)
        {
            App.Current.Windows[0].SizeChanged += ScreenSizeChanged;
        }

        //bindable.Resources.Add("__ScreenSizeBehaviorSmallStyle", SmallStyle);
        //bindable.Resources.Add("__ScreenSizeBehaviorLargeStyle", LargeStyle);

        ApplyStyle();
    }

    protected override void OnDetachingFrom(View bindable)
    {
        base.OnDetachingFrom(bindable);

        if (App.Current != null)
        {
            App.Current.Windows[0].SizeChanged -= ScreenSizeChanged;
        }

        //bindable.RemoveDynamicResource(View.StyleProperty);
        //bindable.Resources.Remove("__ScreenSizeBehaviorSmallStyle");
        //bindable.Resources.Remove("__ScreenSizeBehaviorLargeStyle");
    }

    private void ScreenSizeChanged(object? sender, EventArgs e)
    {
        ApplyStyle();
    }

    private void ApplyStyle()
    {
        if (App.Current != null && bindable != null)
        {
            if (App.Current.Windows[0].Width < Threshold)
            {
                //bindable.SetDynamicResource(View.StyleProperty, "__ScreenSizeBehaviorSmallStyle");
                bindable.Style = SmallStyle;
            }
            else
            {
                //bindable.SetDynamicResource(View.StyleProperty, "__ScreenSizeBehaviorLargeStyle");
                bindable.Style = LargeStyle;
            }
        }
    }
}
