using MauiApp1.Data;

using Microsoft.EntityFrameworkCore;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, false);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}