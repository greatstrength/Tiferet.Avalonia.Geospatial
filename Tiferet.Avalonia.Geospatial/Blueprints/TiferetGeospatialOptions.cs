namespace Tiferet.Avalonia.Geospatial.Blueprints;

// *** blueprints

// ** blueprint: tiferet_geospatial_options
/// <summary>
/// Configuration POCO for bootstrapping Tiferet geospatial services.
/// Specifies default map behavior including center position, zoom, and tile source.
/// </summary>
public class TiferetGeospatialOptions
{
    // ** property: default_latitude
    /// <summary>Default latitude for the map center.</summary>
    public double DefaultLatitude { get; set; } = 0;

    // ** property: default_longitude
    /// <summary>Default longitude for the map center.</summary>
    public double DefaultLongitude { get; set; } = 0;

    // ** property: default_zoom
    /// <summary>Default zoom level for the map.</summary>
    public int DefaultZoom { get; set; } = 2;

    // ** property: tile_source
    /// <summary>
    /// Tile source identifier. Use "OpenStreetMap" for the built-in OSM provider,
    /// or provide a custom XYZ tile URL template.
    /// </summary>
    public string TileSource { get; set; } = "OpenStreetMap";
}
