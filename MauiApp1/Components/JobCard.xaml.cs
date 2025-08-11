using MauiApp1.Services;

namespace MauiApp1.Components;

public partial class JobCard : ContentView
{
    public DateTime? SelectedStartDate { get; set; }
    public DateTime? SelectedEndDate { get; set; }
    public string JobTitle => JobTitleEntry.Text;
    public string CompanyName => CompanyNameEntry.Text;
    public bool Editable { get; set; }
    private ApplyService _resumeService;


    public JobCard()
    {
        InitializeComponent();
        _resumeService = ServiceHelper.GetService<ApplyService>();
    }

    private async void OnSaveJob(object sender, EventArgs e)
    {
        var company = CompanyName;
        var selectedEndDate = SelectedEndDate.GetValueOrDefault();
        var selectedStartDate = SelectedStartDate.GetValueOrDefault();
        var jobTitle = JobTitle;

        //await _resumeService.SaveOrUpdateJobAsync(jobTitle, company, selectedStartDate, selectedEndDate);
    }
}