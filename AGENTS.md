# AGENTS.md — Tiferet.Avalonia.Geospatial (v1.0.0-beta.1)

## Project Overview

**Tiferet.Avalonia.Geospatial** is an Avalonia UI extension library built on top of [Tiferet.Avalonia](https://github.com/greatstrength/tiferet.net-avalonia). It provides geospatial/mapping capabilities powered by Mapsui, NetTopologySuite, and BruTile for building cross-platform desktop mapping applications with the Tiferet DDD framework.

- **Repository:** https://github.com/greatstrength/Tiferet.Avalonia.Geospatial
- **Branch:** `v1.x-proto`
- **Runtime:** .NET 9.0
- **Version:** 1.0.0-beta.1
- **Core dependencies:** Tiferet.Avalonia ≥ 1.0.0-beta.2, Mapsui.Avalonia 5.0.2, Mapsui.Nts 5.0.2

## Architecture

### Layer Overview

```
Tiferet.Avalonia.Geospatial/
├── Assets/Controls/     Map controls — TiferetMap (Mapsui wrapper)
├── Blueprints/          Bootstrap — GeospatialBlueprint, TiferetGeospatialOptions
├── Contexts/            View models — MapViewModel
├── DependencyInjection/ IServiceCollection extensions (AddTiferetGeospatial)
├── Domain/              Domain records (GeoCoordinate, GeoBoundingBox, MapConfiguration)
├── Interfaces/          Service contracts (IMapService)
└── Utilities/           Static utilities (TileLayerFactory)
```

### Key Concepts

- **GeoCoordinate** — Immutable record extending `DomainObject` for geographic coordinates (lat, lon, optional altitude).
- **GeoBoundingBox** — Immutable record for geographic extents with `Contains()` and `Center` helpers.
- **MapConfiguration** — Configuration record for map defaults (center, zoom, tile source).
- **TiferetMap** — `ContentControl` wrapping Mapsui's `MapControl` with bindable `Configuration` and `Map` properties.
- **MapViewModel** — CommunityToolkit.Mvvm view model extending `ViewModelBase` with `MapConfig` and `Map` observable properties.
- **TileLayerFactory** — Static utility for creating OSM and custom XYZ tile layers via BruTile.
- **IMapService** — Service interface for map creation and navigation.
- **GeospatialBlueprint** — Static bootstrap that registers geospatial services into DI.
- **AddTiferetGeospatial** — `IServiceCollection` extension for one-line DI registration.

## Structured Code Style

All code follows the Tiferet structured code style with artifact comments:

### Comment Levels

- `# ***` — Top-level: `imports`, `controls`, `contexts`, `interfaces`, `models`, `utils`, `extensions`, `blueprints`
- `# **` — Mid-level: `control: <name>`, `context: <name>`, `interface: <name>`, `model: <name>`, `util: <name>`, `blueprint: <name>`, `test: <name>`
- `# *` — Low-level: `attribute: <name>`, `init`, `method: <name>`, `method: <name> (static)`

### Spacing Rules

- One empty line between `# ***` and first `# **`.
- One empty line between each `# *` section.
- One empty line after docstrings and between code snippets within methods.

### Docstrings

Use XML doc comments (`/// <summary>`) with `<param>`, `<typeparam>`, `<returns>` for all public members.

## Dependencies

### NuGet Packages (Library)

- `Tiferet.Avalonia` 1.0.0-beta.2 (local nupkg)
- `Mapsui.Avalonia` 5.0.2
- `Mapsui.Nts` 5.0.2

### NuGet Packages (Test Project)

- `xunit` 2.9.2
- `Moq` 4.20.72
- `Microsoft.NET.Test.Sdk` 17.12.0

### Local NuGet Feed

The `local-packages/` directory contains local `.nupkg` files. The `nuget.config` at the repo root configures this as a package source alongside nuget.org.

## Testing

- **Framework:** xUnit (with `Moq` for mocking).
- **Test location:** `tests/Tiferet.Avalonia.Geospatial.Tests/` — organized by component (`Domain/`, `Utilities/`).
- **Run tests:** `dotnet test` from repo root.
- **Test structure:** Uses Tiferet artifact comments (`# *** tests`, `# ** test:`).
- **Naming:** Test methods use `MethodName_Condition_ExpectedResult` pattern.

## Configuration

- `nuget.config` — Package sources (nuget.org + local-packages).
- `Directory.Build.props` — Shared version (`1.0.0-beta.1`) and NuGet metadata.
- `Tiferet.Avalonia.Geospatial.sln` — Solution containing library, tests, and example projects.

## Key Files for Orientation

- `Tiferet.Avalonia.Geospatial/Domain/GeoCoordinate.cs` — Geographic coordinate record
- `Tiferet.Avalonia.Geospatial/Domain/GeoBoundingBox.cs` — Bounding box with containment
- `Tiferet.Avalonia.Geospatial/Domain/MapConfiguration.cs` — Map defaults record
- `Tiferet.Avalonia.Geospatial/Assets/Controls/TiferetMap.cs` — Core map control
- `Tiferet.Avalonia.Geospatial/Contexts/MapViewModel.cs` — MVVM map view model
- `Tiferet.Avalonia.Geospatial/Utilities/TileLayerFactory.cs` — Tile layer creation
- `Tiferet.Avalonia.Geospatial/Interfaces/IMapService.cs` — Map service contract
- `Tiferet.Avalonia.Geospatial/Blueprints/GeospatialBlueprint.cs` — Bootstrap wiring
- `Tiferet.Avalonia.Geospatial/DependencyInjection/ServiceCollectionExtensions.cs` — DI registration

## Branch Conventions

- Feature branches: `<issue-number>-<lowercase-hyphenated-title>`
- PRs target the prototype branch (`v1.x-proto`).
- All commits include `Co-Authored-By: Oz <oz-agent@warp.dev>` when collaborating with AI.
