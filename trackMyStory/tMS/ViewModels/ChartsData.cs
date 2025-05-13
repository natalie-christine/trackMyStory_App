using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.Drawing;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace tMS.ViewModels;

public class ChartsData : ContentView
{
    public ISeries[] Series { get; set; } = [
        new LineSeries<double, DiamondGeometry>(4, 3, 4, 4, 3, 4, 8) {
            GeometrySize = 30,
            YToolTipLabelFormatter = point => point.Model.ToString("N0"),
            GeometryStroke = new SolidColorPaint(new SKColor(46, 125, 50), 3),
            Fill = new SolidColorPaint(new SKColor(46, 125, 50, 100)),
            Stroke = new SolidColorPaint(new SKColor(46, 125, 50), 5),
        },
        new ScatterSeries<int, VariableSVGPathGeometry>(3, 4, 2, 3, 4, 2, 1) {
            GeometrySvg = SVGPoints.Star,
            GeometrySize = 40,
            YToolTipLabelFormatter = point => "PatPats: " + point.Model.ToString("N0"),
            DataLabelsPaint = new SolidColorPaint(new SKColor(251, 192, 45)),
            DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
            DataLabelsFormatter = (point) => point.Coordinate.PrimaryValue.ToString("N0"),
            Fill = new SolidColorPaint(new SKColor(251, 192, 45))
        },
        new ScatterSeries<double, HeartGeometry>(4, 2, 6, 4, 2, 6, 5) {
            GeometrySize = 40,
            YToolTipLabelFormatter = point => point.Model.ToString("N0"),
            Fill = new SolidColorPaint(new SKColor(198, 40, 40))
        }
    ];

    public ICartesianAxis[] XAxes { get; set; } = [
        new Axis
            {
                Name = "Tage",
                // Use the labels property for named or static labels 
                Labels = ["Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag"],
                LabelsRotation = 0,
            }
    ];
}
