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

        async void LoginButton_Clicked(System.Object sender, System.EventArgs e)
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

        async void Register_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }
    }
}
