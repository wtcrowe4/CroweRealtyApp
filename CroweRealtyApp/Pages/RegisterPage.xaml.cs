using CroweRealtyApp.Services;
using CroweRealtyApp.Models;

namespace CroweRealtyApp.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

	private async void RegisterButton_Clicked(object sender, EventArgs e)
	{
       var response = await UserServices.RegisterUser(FullNameEntry.Text, EmailEntry.Text, PasswordEntry.Text, PhoneEntry.Text);
		if (response)
		{
			await DisplayAlert("Success", "User Registered Successfully", "OK");
			await Navigation.PushAsync(new LoginPage());
		} 
		else
		{
			await DisplayAlert("Error", "Something went wrong", "OK");
		}
    }

	private async void LoginTapped(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new LoginPage());
    }
}