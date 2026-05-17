using Tiferet.Interfaces;
using Tiferet.Avalonia.Geospatial.Domain;

namespace Tiferet.Avalonia.Geospatial.Interfaces;

// *** interfaces

// ** interface: map_service
/// <summary>
/// Service interface for creating and configuring Mapsui map instances.
/// </summary>
public interface IMapService : IService
{
    // * method: create_map
    /// <summary>
    /// Create a new Mapsui map configured according to the specified configuration.
    /// </summary>
    /// <param name="config">The map configuration.</param>
    /// <returns>A configured Mapsui map instance.</returns>
    Mapsui.Map CreateMap(MapConfiguration config);

    // * method: set_center
    /// <summary>
    /// Set the center position and zoom level of a map.
    /// </summary>
    /// <param name="map">The Mapsui map instance.</param>
    /// <param name="coordinate">The center coordinate.</param>
    /// <param name="zoom">The zoom level.</param>
    void SetCenter(Mapsui.Map map, GeoCoordinate coordinate, int zoom);
}
