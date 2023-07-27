using CroweRealtyApp.Models;
using CroweRealtyApp.Services;

namespace CroweRealtyApp.Pages
{
    public partial class PropertiesListPage : ContentPage
    {
        public PropertiesListPage(int categoryId, string categoryName)
        {
            InitializeComponent();
            Title = categoryName;
            GetPropertiesList(categoryId);
        }

        private async void GetPropertiesList(int categoryId)
        {
            var properties = await PropertyServices.GetPropertyByCategory(categoryId);
            Properties.ItemsSource = properties;
        }

        void Properties_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as PropertyByCategory;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new PropertyDetailPage(currentSelection.Id));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
