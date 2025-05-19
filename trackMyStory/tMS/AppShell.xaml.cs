using tMS.Helper;

namespace tMS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            ColorHelper.SetColor(ColorHelper.CreateRandomColor(), ColorHelper.CreateRandomColor());
        }
    }
}
