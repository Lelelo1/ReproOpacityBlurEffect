using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ContentPage() { Content = (new MyContent()).RootLayout };
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
