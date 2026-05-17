using Tiferet.Domain;

namespace Tiferet.Avalonia.Geospatial.Domain;

// *** models

// ** model: map_configuration
/// <summary>
/// Configuration record for default map settings including center position,
/// zoom level, and tile source.
/// </summary>
public sealed record MapConfiguration(
    string Id,
    string Name,
    double DefaultLatitude = 0,
    double DefaultLongitude = 0,
    int DefaultZoom = 2,
    string TileSource = "OpenStreetMap") : DomainObject;
