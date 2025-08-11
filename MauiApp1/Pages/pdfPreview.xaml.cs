namespace MauiApp1.Pages;

public partial class pdfPreview : ContentView
{
	public pdfPreview()
	{
		InitializeComponent();
        BindingContext = new PdfViewerViewModel(); // Or inject another source

    }
}