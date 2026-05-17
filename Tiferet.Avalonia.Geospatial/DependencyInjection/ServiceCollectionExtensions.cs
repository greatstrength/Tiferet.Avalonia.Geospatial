using Microsoft.Extensions.DependencyInjection;
using Tiferet.Avalonia.Geospatial.Blueprints;

namespace Tiferet.Avalonia.Geospatial.DependencyInjection;

// *** extensions

// ** extension: service_collection_extensions
/// <summary>
/// Extension methods for integrating Tiferet.Avalonia.Geospatial with
/// <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    // ** method: add_tiferet_geospatial
    /// <summary>
    /// Add Tiferet geospatial services to the DI container, using an explicit
    /// configuration callback for map defaults.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">A callback to configure geospatial options.</param>
    /// <returns>The configured service collection for chaining.</returns>
    public static IServiceCollection AddTiferetGeospatial(
        this IServiceCollection services,
        Action<TiferetGeospatialOptions> configure)
    {
        var options = new TiferetGeospatialOptions();
        configure(options);
        return GeospatialBlueprint.ConfigureServices(services, options);
    }
}
