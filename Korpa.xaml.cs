namespace TechShop;
using TechShop.Services;
using TechShop.ViewModels;

public partial class Korpa : ContentPage
{
    public Korpa()
    {
        InitializeComponent();
        BindingContext = new TechShop.ViewModels.CartViewModel();
    }

    private async void OnLogoTapped(object sender, EventArgs e) //samo navigacija
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnBackTapped(object sender, EventArgs e) //samo navigacija
    {
        await Navigation.PopAsync();
    }
    private void OnPaymentSwitchToggled(object sender, ToggledEventArgs e) //metoda za prikazivanje karticnog placanja
    {
        PaymentInfoSection.IsVisible = e.Value;
    }
}
