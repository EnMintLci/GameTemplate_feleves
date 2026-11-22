using GameTemplateMAUI.ViewModels;

namespace GameTemplateMAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private MainPageViewModel vm;

        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();

            this.vm = vm;
            this.BindingContext = vm;
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
