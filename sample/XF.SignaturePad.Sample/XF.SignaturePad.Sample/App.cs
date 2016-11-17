using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.SignaturePad.Sample.Pages;

namespace XF.SignaturePad.Sample
{
    public class App : Application
    {
        public App()
        {
            MainPage = new SignaturePadPage();
        }

        public static async Task ShowAlert(string title, string message, string cancel)
        {
            await Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public static async Task ShowAlert(string message)
        {
            await Current.MainPage.DisplayAlert("SignaturePad.Sample", message, "OK");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
