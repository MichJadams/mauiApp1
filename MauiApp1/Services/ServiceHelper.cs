namespace MauiApp1.Services
{
    public static class ServiceHelper
    {
        public static T GetService<T>() where T : class
        {
            var serviceProvider = Application.Current?.Handler?.MauiContext?.Services;

            if (serviceProvider == null)
                throw new InvalidOperationException("MauiContext or Services are not available yet.");

            return serviceProvider.GetService(typeof(T)) as T
                   ?? throw new InvalidOperationException($"Service of type {typeof(T)} not found.");
        }
    }

}
