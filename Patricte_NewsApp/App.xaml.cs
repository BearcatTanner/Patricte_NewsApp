using Patricte_NewsApp.Pages;

namespace Patricte_NewsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new NewsHomePage());
        }
    }
}
