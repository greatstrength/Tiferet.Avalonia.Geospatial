using CommunityToolkit.Mvvm.ComponentModel;
using Mapsui.Tiling;
using Tiferet.Avalonia.Contexts;
using Tiferet.Avalonia.Geospatial.Domain;
using Tiferet.Avalonia.Geospatial.Utilities;

namespace Tiferet.Avalonia.Geospatial.Contexts;

// *** contexts

// ** context: map_view_model
/// <summary>
/// An MVVM view model for map-based views. Extends <see cref="ViewModelBase"/>
/// with map configuration state and a Mapsui <see cref="Mapsui.Map"/> instance.
/// </summary>
public partial class MapViewModel : ViewModelBase
{
    // * attribute: map_config
    [ObservableProperty]
    private MapConfiguration? _mapConfig;

    // * attribute: map
    [ObservableProperty]
    private Mapsui.Map? _map;

    // * init
    /// <summary>
    /// Initializes the map view model with an optional configuration.
    /// Calls <see cref="InitializeMap"/> to create the map instance.
    /// </summary>
    /// <param name="config">Optional map configuration. Defaults to OSM world view.</param>
    public MapViewModel(MapConfiguration? config = null)
    {
        _mapConfig = config;
        InitializeMap();
    }

    // *** methods

    // ** method: initialize_map
    /// <summary>
    /// Creates and configures a Mapsui <see cref="Mapsui.Map"/> based on the
    /// current <see cref="MapConfig"/>. Adds the appropriate tile layer and
    /// navigates to the configured center.
    /// </summary>
    public void InitializeMap()
    {
        // Create a fresh map instance.
        var map = new Mapsui.Map();

        // Add tile layer based on config or default to OSM.
        if (MapConfig is not null &&
            !string.Equals(MapConfig.TileSource, "OpenStreetMap", StringComparison.OrdinalIgnoreCase))
        {
            map.Layers.Add(TileLayerFactory.CreateXyzTileLayer(MapConfig.TileSource));
        }
        else
        {
            map.Layers.Add(TileLayerFactory.CreateOpenStreetMapLayer());
        }

        // Navigate to configured center if available.
        if (MapConfig is not null)
        {
            var center = Mapsui.Projections.SphericalMercator.FromLonLat(
                MapConfig.DefaultLongitude, MapConfig.DefaultLatitude);
            map.Navigator.CenterOnAndZoomTo(
                new Mapsui.MPoint(center.x, center.y),
                map.Navigator.Resolutions[Math.Clamp(MapConfig.DefaultZoom, 0, map.Navigator.Resolutions.Count - 1)]);
        }

        // Set the map property (triggers binding update).
        Map = map;
    }
}
