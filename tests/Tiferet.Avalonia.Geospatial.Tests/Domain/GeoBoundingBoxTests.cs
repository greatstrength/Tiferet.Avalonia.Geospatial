using Tiferet.Avalonia.Geospatial.Domain;

namespace Tiferet.Avalonia.Geospatial.Tests.Domain;

// *** tests

// ** test: geo_bounding_box_tests
public class GeoBoundingBoxTests
{
    // *** fixtures

    // ** fixture: sample_bbox
    private static GeoBoundingBox SampleBbox() => new(
        SouthWest: new GeoCoordinate(40.0, -75.0),
        NorthEast: new GeoCoordinate(41.0, -73.0));

    // ** test: contains_point_inside_returns_true
    [Fact]
    public void Contains_PointInside_ReturnsTrue()
    {
        var bbox = SampleBbox();
        var point = new GeoCoordinate(40.5, -74.0);

        Assert.True(bbox.Contains(point));
    }

    // ** test: contains_point_outside_returns_false
    [Fact]
    public void Contains_PointOutside_ReturnsFalse()
    {
        var bbox = SampleBbox();
        var point = new GeoCoordinate(42.0, -74.0);

        Assert.False(bbox.Contains(point));
    }

    // ** test: contains_point_on_boundary_returns_true
    [Fact]
    public void Contains_PointOnBoundary_ReturnsTrue()
    {
        var bbox = SampleBbox();
        var point = new GeoCoordinate(40.0, -75.0);

        Assert.True(bbox.Contains(point));
    }

    // ** test: center_returns_midpoint
    [Fact]
    public void Center_ReturnsMidpoint()
    {
        var bbox = SampleBbox();
        var center = bbox.Center;

        Assert.Equal(40.5, center.Latitude);
        Assert.Equal(-74.0, center.Longitude);
    }
}
