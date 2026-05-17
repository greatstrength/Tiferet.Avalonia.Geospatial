using Tiferet.Avalonia.Geospatial.Domain;

namespace Tiferet.Avalonia.Geospatial.Tests.Domain;

// *** tests

// ** test: geo_coordinate_tests
public class GeoCoordinateTests
{
    // ** test: constructor_sets_latitude_and_longitude
    [Fact]
    public void Constructor_SetsLatitudeAndLongitude()
    {
        var coord = new GeoCoordinate(40.7128, -74.0060);

        Assert.Equal(40.7128, coord.Latitude);
        Assert.Equal(-74.0060, coord.Longitude);
        Assert.Null(coord.Altitude);
    }

    // ** test: constructor_sets_altitude_when_provided
    [Fact]
    public void Constructor_SetsAltitudeWhenProvided()
    {
        var coord = new GeoCoordinate(40.7128, -74.0060, 100.5);

        Assert.Equal(100.5, coord.Altitude);
    }

    // ** test: equality_same_values_are_equal
    [Fact]
    public void Equality_SameValuesAreEqual()
    {
        var a = new GeoCoordinate(51.5074, -0.1278);
        var b = new GeoCoordinate(51.5074, -0.1278);

        Assert.Equal(a, b);
    }

    // ** test: equality_different_values_are_not_equal
    [Fact]
    public void Equality_DifferentValuesAreNotEqual()
    {
        var a = new GeoCoordinate(51.5074, -0.1278);
        var b = new GeoCoordinate(48.8566, 2.3522);

        Assert.NotEqual(a, b);
    }

    // ** test: to_string_without_altitude
    [Fact]
    public void ToString_WithoutAltitude_FormatsCorrectly()
    {
        var coord = new GeoCoordinate(40.712800, -74.006000);

        Assert.Equal("(40.712800, -74.006000)", coord.ToString());
    }

    // ** test: to_string_with_altitude
    [Fact]
    public void ToString_WithAltitude_FormatsCorrectly()
    {
        var coord = new GeoCoordinate(40.712800, -74.006000, 100.50);

        Assert.Equal("(40.712800, -74.006000, 100.50m)", coord.ToString());
    }
}
