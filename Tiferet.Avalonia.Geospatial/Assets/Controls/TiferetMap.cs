using Avalonia;
using Avalonia.Controls;
using Mapsui.Tiling;
using Mapsui.UI.Avalonia;
using Tiferet.Avalonia.Geospatial.Domain;
using Tiferet.Avalonia.Geospatial.Utilities;

namespace Tiferet.Avalonia.Geospatial.Assets.Controls;

// *** controls

// ** control: tiferet_map
/// <summary>
/// A Tiferet-styled map control that wraps <see cref="MapControl"/> from Mapsui.Avalonia.
/// Supports bindable <see cref="MapConfiguration"/> for declarative map setup
/// and exposes the underlying <see cref="Mapsui.Map"/> for direct access.
/// </summary>
public class TiferetMap : ContentControl
{
    // * attribute: map_control
    private MapControl? _mapControl;

    // * attribute: configuration_property
    public static readonly StyledProperty<MapConfiguration?> ConfigurationProperty =
        AvaloniaProperty.Register<TiferetMap, MapConfiguration?>(nameof(Configuration));

    // * attribute: map_property
    public static readonly DirectProperty<TiferetMap, Mapsui.Map?> MapProperty =
        AvaloniaProperty.RegisterDirect<TiferetMap, Mapsui.Map?>(
            nameof(Map),
            o => o.Map);

    // * attribute: map_backing
    private Mapsui.Map? _map;

    // *** properties

    // ** property: configuration
    /// <summary>
    /// The map configuration controlling tile source, default center, and zoom.
    /// </summary>
    public MapConfiguration? Configuration
    {
        get => GetValue(ConfigurationProperty);
        set => SetValue(ConfigurationProperty, value);
    }

    // ** property: map
    /// <summary>
    /// The underlying Mapsui <see cref="Mapsui.Map"/> instance. Read-only; set via
    /// <see cref="Configuration"/> or call <see cref="InitializeMap"/>.
    /// </summary>
    public Mapsui.Map? Map
    {
        get => _map;
        private set => SetAndRaise(MapProperty, ref _map, value);
    }

    // * init
    public TiferetMap()
    {
        _mapControl = new MapControl();
        Content = _mapControl;

        // Initialize with default OSM layer.
        InitializeMap();
    }

    // *** methods

    // ** method: initialize_map
    /// <summary>
    /// Initializes or re-initializes the map based on the current <see cref="Configuration"/>.
    /// Falls back to OpenStreetMap with world view when no configuration is set.
    /// </summary>
    public void InitializeMap()
    {
        if (_mapControl is null) return;

        // Create a new Mapsui map.
        var map = new Mapsui.Map();

        // Add the tile layer based on configuration.
        var config = Configuration;
        if (config is not null && !string.Equals(config.TileSource, "OpenStreetMap", StringComparison.OrdinalIgnoreCase))
        {
            map.Layers.Add(TileLayerFactory.CreateXyzTileLayer(config.TileSource));
        }
        else
        {
            map.Layers.Add(TileLayerFactory.CreateOpenStreetMapLayer());
        }

        // Apply the map to the control.
        _mapControl.Map = map;
        Map = map;

        // Navigate to configured center if available.
        if (config is not null)
        {
            var center = Mapsui.Projections.SphericalMercator.FromLonLat(
                config.DefaultLongitude, config.DefaultLatitude);
            map.Navigator.CenterOnAndZoomTo(
                new Mapsui.MPoint(center.x, center.y),
                map.Navigator.Resolutions[Math.Clamp(config.DefaultZoom, 0, map.Navigator.Resolutions.Count - 1)]);
        }
    }

    // ** method: on_property_changed
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        // Re-initialize the map when Configuration changes.
        if (change.Property == ConfigurationProperty)
        {
            InitializeMap();
        }
    }
}
