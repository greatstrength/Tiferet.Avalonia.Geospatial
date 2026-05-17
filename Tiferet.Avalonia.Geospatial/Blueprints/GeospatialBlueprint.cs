using Microsoft.Extensions.DependencyInjection;
using Tiferet.Avalonia.Geospatial.Domain;

namespace Tiferet.Avalonia.Geospatial.Blueprints;

// *** blueprints

// ** blueprint: geospatial_blueprint
/// <summary>
/// Static blueprint for bootstrapping Tiferet geospatial services into
/// an <see cref="IServiceCollection"/>. Registers map configuration
/// and geospatial options as singletons.
/// </summary>
public static class GeospatialBlueprint
{
    // ** method: configure_services
    /// <summary>
    /// Register all Tiferet geospatial services into the DI container.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="options">The geospatial configuration options.</param>
    /// <returns>The configured service collection for chaining.</returns>
    public static IServiceCollection ConfigureServices(
        IServiceCollection services,
        TiferetGeospatialOptions options)
    {
        // Register the options for injection.
        services.AddSingleton(options);

        // Create and register a default MapConfiguration from the options.
        var mapConfig = new MapConfiguration(
            Id: "default",
            Name: "Default Map",
            DefaultLatitude: options.DefaultLatitude,
            DefaultLongitude: options.DefaultLongitude,
            DefaultZoom: options.DefaultZoom,
            TileSource: options.TileSource);
        services.AddSingleton(mapConfig);

        return services;
    }
}
