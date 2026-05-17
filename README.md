# Tiferet.Avalonia.Geospatial

Geospatial controls, domain primitives, and map services for building Avalonia UI mapping applications with the [Tiferet](https://github.com/greatstrength/tiferet.net) DDD framework.

## Features

- **TiferetMap** — Avalonia control wrapping Mapsui's `MapControl` with bindable configuration
- **Domain Primitives** — `GeoCoordinate`, `GeoBoundingBox`, `MapConfiguration` as immutable `DomainObject` records
- **TileLayerFactory** — Static utility for OpenStreetMap and custom XYZ tile layers
- **MapViewModel** — CommunityToolkit.Mvvm view model with map state management
- **DI Integration** — One-line `AddTiferetGeospatial()` registration

## Quick Start

```csharp
// In your DI setup:
services.AddTiferetGeospatial(options =>
{
    options.DefaultLatitude = 40.7128;
    options.DefaultLongitude = -74.0060;
    options.DefaultZoom = 10;
});
```

## Dependencies

- [Tiferet.Avalonia](https://github.com/greatstrength/tiferet.net-avalonia) >= 1.0.0-beta.2
- [Mapsui.Avalonia](https://www.nuget.org/packages/Mapsui.Avalonia) 5.0.2
- [Mapsui.Nts](https://www.nuget.org/packages/Mapsui.Nts) 5.0.2

## License

[MIT](LICENSE)
