using CroweRealtyApp.Pages;

namespace CroweRealtyApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new RegisterPage();
	}
}
