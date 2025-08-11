using MauiApp1.Backend;
using MauiApp1.Data.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;

namespace MauiApp1.Pages;

public partial class ApplicationsContainer : ContentPage
{
    private ApplyService _applyService;
    private LocalWebServer _webServer;

    public ObservableCollection<JobApplication> Applications { get; set; } = new();

    public ApplicationsContainer(ApplyService applyServce, LocalWebServer webServer)
	{
		InitializeComponent();
        _applyService = applyServce;
        _webServer = webServer;
        UpdateServerStatusIndicator();
        _webServer.ApplicationRefreshRequested += HandleIncomingPostRequests;
        BindingContext = this;
	}

	protected override async void OnAppearing()
    {
        await RenderApplications();
    }

    private async Task RenderApplications()
    {
        var apps = await _applyService.GetApplications();
        Applications.Clear();

        foreach (var app in apps)
        {
            if (app != null)
            {
                Applications.Add(app);
            }

        }
    }

    private void OnToggleServerClicked(object sender, EventArgs e)
    {
        if(_webServer.IsRunning)
        {
            _webServer.StopAsync();
        }
        else
        {
            _webServer.Start();
        }
        UpdateServerStatusIndicator();
    }
    private void UpdateServerStatusIndicator()
    {
        StatusIndicator.BackgroundColor = _webServer.IsRunning ? Colors.DeepSkyBlue : Colors.Gray;
    }

    private async void OnNavigteBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private void HandleIncomingPostRequests(object? sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            StatusIndicator.BackgroundColor = Colors.Yellow;
            await RenderApplications();
            await Task.Delay(1000);
            StatusIndicator.BackgroundColor = Colors.Yellow;

        });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _webServer.ApplicationRefreshRequested -= HandleIncomingPostRequests;
    }

}