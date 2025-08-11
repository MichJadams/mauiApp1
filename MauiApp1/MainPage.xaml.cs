namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavigate(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ResumeContainer");
        }

        public async void GoToApplications(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ApplicationsContainer");

        }

    }
}
