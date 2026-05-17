using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Tiferet.Avalonia.Geospatial.Domain;
using Tiferet.Avalonia.Geospatial.Contexts;

namespace Tiferet.Avalonia.Geospatial.Examples.MapViewer;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Create a map configuration centered on New York City.
            var config = new MapConfiguration(
                Id: "mapviewer",
                Name: "Map Viewer Demo",
                DefaultLatitude: 40.7128,
                DefaultLongitude: -74.0060,
                DefaultZoom: 10);

            // Create the view model.
            var viewModel = new MapViewModel(config);

            desktop.MainWindow = new MainWindow
            {
                DataContext = viewModel,
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
