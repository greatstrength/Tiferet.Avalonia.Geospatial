using Tiferet.Domain;

namespace Tiferet.Avalonia.Geospatial.Domain;

// *** models

// ** model: geo_bounding_box
/// <summary>
/// An immutable geographic bounding box defined by its south-west and north-east corners.
/// </summary>
public sealed record GeoBoundingBox(
    GeoCoordinate SouthWest,
    GeoCoordinate NorthEast) : DomainObject
{
    // * method: contains
    /// <summary>
    /// Determines whether the bounding box contains the specified coordinate.
    /// </summary>
    /// <param name="coordinate">The coordinate to test.</param>
    /// <returns>True if the coordinate falls within the bounding box.</returns>
    public bool Contains(GeoCoordinate coordinate) =>
        coordinate.Latitude >= SouthWest.Latitude &&
        coordinate.Latitude <= NorthEast.Latitude &&
        coordinate.Longitude >= SouthWest.Longitude &&
        coordinate.Longitude <= NorthEast.Longitude;

    // * method: center
    /// <summary>
    /// Returns the center coordinate of the bounding box.
    /// </summary>
    public GeoCoordinate Center => new(
        (SouthWest.Latitude + NorthEast.Latitude) / 2.0,
        (SouthWest.Longitude + NorthEast.Longitude) / 2.0);
}
