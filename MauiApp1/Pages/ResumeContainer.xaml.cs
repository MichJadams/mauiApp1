using MauiApp1.Services;

namespace MauiApp1.Pages;

public partial class ResumeContainer : ContentPage
{
    private ApplyService _resumeService;

    public ResumeContainer(ApplyService resumeService)
	{
		InitializeComponent();
        _resumeService = resumeService;
    }

    private async void OnNavigteBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void OnSave(object sender, EventArgs e)
    {
        var name = UsernameEntry.Text;
        var address = UserAddressEntry.Text;
        var summary = UserSummaryEntry.Text;

        await _resumeService.SaveResumeAsync(name, address, summary);

        await DisplayAlert("Saved", "Resume saved successfully!", "OK");

    }

}