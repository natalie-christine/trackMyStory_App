using Microsoft.Maui.Layouts;

namespace tMS.Layouts;

public class ResponsiveLayoutManager : LayoutManager
{
    private readonly Microsoft.Maui.ILayout _layout;

    public int HorizontalThreshold;
    public int HorizontalSpacing;
    public int VerticalSpacing;

    private Dictionary<IView, Size> childSizeMap = new Dictionary<IView, Size>();

    public ResponsiveLayoutManager(Microsoft.Maui.ILayout layout) : base(layout)
    {
        _layout = layout;
    }

    public override Size Measure(double widthConstraint, double heightConstraint)
    {
        double requiredHeight = 0;
        if (widthConstraint < HorizontalThreshold) // vertical mode
        {
            var totalSpacing = VerticalSpacing * (_layout.Count - 1);
            foreach (IView child in _layout)
            {
                Size childSize = child.Measure(widthConstraint, heightConstraint);
                requiredHeight += childSize.Height;
                childSizeMap[child] = childSize;
            }
            return new Size(widthConstraint, requiredHeight + totalSpacing);
        }
        else // horizontal mode
        {
            var totalSpacing = HorizontalSpacing * (_layout.Count - 1);
            foreach (IView child in _layout)
            {
                Size childSize = child.Measure((widthConstraint - totalSpacing) / _layout.Count, heightConstraint);
                requiredHeight = Math.Max(requiredHeight, childSize.Height);
                childSizeMap[child] = childSize;
            }
            return new Size(widthConstraint, requiredHeight);
        }
    }

    public override Size ArrangeChildren(Rect bounds)
    {
        double requiredHeight = 0;
        if (bounds.Width < HorizontalThreshold) // vertical mode
        {
            var totalSpacing = VerticalSpacing * (_layout.Count - 1);
            var ew = bounds.Width;
            var i = 0;

            foreach (IView child in _layout)
            {
                Size childSize = child.Arrange(new Rect(0, requiredHeight, ew, childSizeMap[child].Height));
                requiredHeight += childSize.Height + VerticalSpacing;
                ++i;
            }
        }
        else // horizontal mode
        {
            var totalSpacing = HorizontalSpacing * (_layout.Count - 1);
            var ew = (bounds.Width - totalSpacing) / _layout.Count;
            var i = 0;
        
            foreach (IView child in _layout)
            {
                Size childSize = child.Arrange(new Rect((ew + HorizontalSpacing) * i, 0, ew, bounds.Height));
                requiredHeight = Math.Max(requiredHeight, childSize.Height);
                ++i;
            }
        }
        return new Size(bounds.Width, requiredHeight);
    }

}
