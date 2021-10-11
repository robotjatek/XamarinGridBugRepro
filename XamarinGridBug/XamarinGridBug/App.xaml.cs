
using Xamarin.Forms;

using XamarinGridBug.Pages;

namespace XamarinGridBug
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var tabs = new TabbedPage();
            tabs.Children.Add(new MainPage() { Title = "Buttons in grid" });
            tabs.Children.Add(new ListView() { Title = "Buttons in list" });
            tabs.Children.Add(new GridRemoveLast() { Title = "Labels in grid remove last" });

            MainPage = tabs;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
