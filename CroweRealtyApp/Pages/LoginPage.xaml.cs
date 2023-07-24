using CroweRealtyApp.Services;
using CroweRealtyApp.Models;

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
            var response = await UserServices.LoginUser(EmailEntry.Text, PasswordEntry.Text) ;
            if (response)
            {
                Application.Current.MainPage = new CustomTabbedPage();
            }
            else
            {
                await DisplayAlert("", "Oops something went wrong.", "Cancel");
            }
        }

        async void Register_Tapped(Object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
