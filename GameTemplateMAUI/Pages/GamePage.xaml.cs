using CommunityToolkit.Mvvm.Messaging;
using GameTemplateMAUI.ViewModels;


namespace GameTemplateMAUI.Pages;

public partial class GamePage : ContentPage
{
    public GamePage(GameViewModel viewModel)
    {
       InitializeComponent();

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        WeakReferenceMessenger.Default.Register<string>(
            this,
            (recipient, message) =>
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Warning", message, "OK");
                });
            });
    }
    protected override void OnDisappearing() {
        WeakReferenceMessenger.Default.Unregister<string>(this);
        base.OnDisappearing();
    }
}