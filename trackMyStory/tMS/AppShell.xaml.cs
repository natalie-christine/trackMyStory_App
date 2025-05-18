using tMS.Helper;

namespace tMS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

        
            Random random = new Random();
            var red = random.NextDouble();
            var green = random.NextDouble();
            var blue = random.NextDouble();

            Color color = Color.FromRgb(red, green, blue);
            ColorHelper.SetColor(color);
        }
    }
}
