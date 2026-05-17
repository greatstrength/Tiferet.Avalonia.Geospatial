using Tiferet.Domain;

namespace Tiferet.Avalonia.Geospatial.Domain;

// *** models

// ** model: geo_coordinate
/// <summary>
/// An immutable geographic coordinate with latitude, longitude, and optional altitude.
/// </summary>
public sealed record GeoCoordinate(
    double Latitude,
    double Longitude,
    double? Altitude = null) : DomainObject
{
    // * method: to_string
    /// <summary>
    /// Returns a human-readable string representation of the coordinate.
    /// </summary>
    public override string ToString() =>
        Altitude.HasValue
            ? $"({Latitude:F6}, {Longitude:F6}, {Altitude.Value:F2}m)"
            : $"({Latitude:F6}, {Longitude:F6})";
}
