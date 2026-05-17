using Tiferet.Avalonia.Geospatial.Utilities;

namespace Tiferet.Avalonia.Geospatial.Tests.Utilities;

// *** tests

// ** test: tile_layer_factory_tests
public class TileLayerFactoryTests
{
    // ** test: create_osm_layer_returns_non_null
    [Fact]
    public void CreateOpenStreetMapLayer_ReturnsNonNull()
    {
        var layer = TileLayerFactory.CreateOpenStreetMapLayer();

        Assert.NotNull(layer);
    }

    // ** test: create_xyz_layer_sets_name
    [Fact]
    public void CreateXyzTileLayer_SetsName()
    {
        var layer = TileLayerFactory.CreateXyzTileLayer(
            "https://tile.example.com/{z}/{x}/{y}.png",
            "Test Layer");

        Assert.NotNull(layer);
        Assert.Equal("Test Layer", layer.Name);
    }

    // ** test: create_xyz_layer_default_name
    [Fact]
    public void CreateXyzTileLayer_DefaultName_IsCustomTiles()
    {
        var layer = TileLayerFactory.CreateXyzTileLayer(
            "https://tile.example.com/{z}/{x}/{y}.png");

        Assert.Equal("Custom Tiles", layer.Name);
    }
}
