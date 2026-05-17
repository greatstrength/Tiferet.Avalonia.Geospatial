using Tiferet.Avalonia.Geospatial.Domain;

namespace Tiferet.Avalonia.Geospatial.Tests.Domain;

// *** tests

// ** test: map_configuration_tests
public class MapConfigurationTests
{
    // ** test: defaults_use_expected_values
    [Fact]
    public void Defaults_UseExpectedValues()
    {
        var config = new MapConfiguration("test", "Test Map");

        Assert.Equal("test", config.Id);
        Assert.Equal("Test Map", config.Name);
        Assert.Equal(0, config.DefaultLatitude);
        Assert.Equal(0, config.DefaultLongitude);
        Assert.Equal(2, config.DefaultZoom);
        Assert.Equal("OpenStreetMap", config.TileSource);
    }

    // ** test: custom_values_are_preserved
    [Fact]
    public void CustomValues_ArePreserved()
    {
        var config = new MapConfiguration(
            Id: "nyc",
            Name: "New York City",
            DefaultLatitude: 40.7128,
            DefaultLongitude: -74.0060,
            DefaultZoom: 12,
            TileSource: "https://tile.example.com/{z}/{x}/{y}.png");

        Assert.Equal("nyc", config.Id);
        Assert.Equal(40.7128, config.DefaultLatitude);
        Assert.Equal(-74.0060, config.DefaultLongitude);
        Assert.Equal(12, config.DefaultZoom);
        Assert.Equal("https://tile.example.com/{z}/{x}/{y}.png", config.TileSource);
    }
}
