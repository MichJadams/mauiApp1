namespace MauiApp1.Pages
{
    public class PdfViewerViewModel 
    {
        public Stream PdfDocumentStream { get; }

        public PdfViewerViewModel()
        {
            var assembly = typeof(PdfViewerViewModel).Assembly;
            PdfDocumentStream = assembly.GetManifestResourceStream("MauiApp1.Resources.Raw.remain_repair.pdf");
            // Ensure the PDF is set as EmbeddedResource
        }
    }
}
