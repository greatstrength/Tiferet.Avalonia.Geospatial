using BruTile.Predefined;
using BruTile.Web;
using Mapsui.Layers;
using Mapsui.Tiling;
using Mapsui.Tiling.Layers;

namespace Tiferet.Avalonia.Geospatial.Utilities;

// *** utils

// ** util: tile_layer_factory
/// <summary>
/// Static utility for creating Mapsui tile layers backed by BruTile providers.
/// </summary>
public static class TileLayerFactory
{
    // * method: create_open_street_map_layer (static)
    /// <summary>
    /// Creates a tile layer using the default OpenStreetMap tile source.
    /// </summary>
    /// <returns>A configured tile layer displaying OpenStreetMap tiles.</returns>
    public static TileLayer CreateOpenStreetMapLayer()
    {
        return OpenStreetMap.CreateTileLayer();
    }

    // * method: create_xyz_tile_layer (static)
    /// <summary>
    /// Creates a tile layer from an XYZ tile URL template.
    /// The template should contain {z}, {x}, {y} placeholders.
    /// </summary>
    /// <param name="urlTemplate">The XYZ tile URL template (e.g., "https://tile.example.com/{z}/{x}/{y}.png").</param>
    /// <param name="name">The display name for the layer.</param>
    /// <returns>A configured tile layer.</returns>
    public static TileLayer CreateXyzTileLayer(string urlTemplate, string name = "Custom Tiles")
    {
        // Create a BruTile HTTP tile source from the URL template.
        var tileSource = new HttpTileSource(
            new GlobalSphericalMercator(),
            urlTemplate,
            name: name);

        // Wrap in a Mapsui tile layer and return.
        return new TileLayer(tileSource) { Name = name };
    }
}
