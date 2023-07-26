using CroweRealtyApp.Services;
using CroweRealtyApp.Models;
using System.Diagnostics;

namespace CroweRealtyApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void LoginButton_Clicked(Object sender, EventArgs e)
        {
            Debug.WriteLine(EmailEntry.Text);
            Debug.WriteLine(PasswordEntry.Text);
            var response = await UserServices.LoginUser(EmailEntry.Text, PasswordEntry.Text);
            if (response)
            {
                Application.Current.MainPage = new TabPage();
            }
            else
            {
                await DisplayAlert("", "Oops something went wrong.", "Cancel");
                Debug.WriteLine(response);
            }
        }

        async void Register_Tapped(Object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
