using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
namespace Repro
{
    public class MyContent
    {
        public AbsoluteLayout RootLayout { get; }

        StackLayout ChildLayout { get; }

        public MyContent()
        {
            RootLayout = new AbsoluteLayout();
            RootLayout.BackgroundColor = Color.Yellow;

            ChildLayout = new StackLayout();
            AbsoluteLayout.SetLayoutFlags(ChildLayout, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(ChildLayout, new Rectangle(0, 0, 1, 1));

            ChildLayout.On<iOS>().UseBlurEffect(BlurEffectStyle.ExtraLight);

            // change opacity by: the ChildLayout is always shown beacuse of 'UseBlurEffect'
            var tapReco = new TapGestureRecognizer();
            tapReco.Tapped += TapReco_Tapped;
            ChildLayout.GestureRecognizers.Add(tapReco);
            RootLayout.Children.Add(ChildLayout);
           
        }

        bool ShowChildLayout { get; set; } = true;
        private void TapReco_Tapped(object sender, EventArgs e)
        {
            ShowChildLayout = !ShowChildLayout;
            var opacity = ShowChildLayout ? 1 : 0;
            Console.WriteLine("set overlay opacity to: " + opacity);
            Device.BeginInvokeOnMainThread(() =>
            {
                ChildLayout.Opacity = opacity;
            });
        }
    }
}
