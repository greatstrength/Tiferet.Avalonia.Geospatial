**Perfect—I've incorporated the optional dependencies directly into the core plan.** This makes `Tiferet.Avalonia.Geospatial` more powerful out of the box for advanced geometry, tiling, and custom rendering, while keeping it lightweight and mission-agnostic.

### Updated Dependencies (All Included)
**Direct / Required:**
- `Mapsui.Avalonia` (v5.0.2+ — current stable as of now)
- `Avalonia` (matching your `tiferet.net-avalonia` version, e.g., Avalonia 11 or 12)
- `Avalonia.Themes.Fluent` + your Tiferet design system package

**Now Promoted to Direct Dependencies:**
- **`Mapsui.Nts`** — Official Mapsui bridge to `NetTopologySuite` (NTS). Provides robust geometry (Point, LineString, Polygon, Multi*, GeometryCollection), spatial operations (buffer, union, intersection, convex hull, etc.), and spatial indexing. Mapsui recommends this for anything beyond basic features.
- **`BruTile`** (and `BruTile.MbTiles`) — For flexible tile sources (XYZ, WMTS, WMS) and excellent offline MBTiles support. Mapsui already uses BruTile under the hood; exposing it gives you full control over custom providers and caching.
- **`SkiaSharp`** (and `SkiaSharp.Views.Avalonia` if needed) — For custom drawing, symbol generation, overlays, heatmaps, or advanced raster effects beyond Mapsui’s built-in rendering.

**Optional / Peer (for consumers):**
- `NetTopologySuite` (already pulled via Mapsui.Nts)
- `ProjNET` or `DotSpatial.Projections` (for advanced CRS transformations)
- Tiferet.NET core packages (for extension methods only)

This combo gives you production-grade geospatial capabilities without pulling in the entire world.

### Refined Project Structure (with new deps reflected)
```
Tiferet.Avalonia.Geospatial/
├── Controls/
│   ├── TiferetMap.cs
│   └── ...
├── Widgets/
│   ├── CardinalArrowWidget.cs
│   ├── LegendWidget.cs
│   ├── EnhancedScaleBarWidget.cs
│   └── CoordinateDisplayWidget.cs
├── Layers/
│   ├── TileLayerFactory.cs          # BruTile-powered providers
│   ├── VectorLayerFactory.cs        # NTS-backed feature creation
│   ├── FeatureLayer.cs
│   └── ...
├── Primitives/
│   ├── GeoCoordinate.cs
│   ├── GeoBoundingBox.cs
│   ├── GeoPath.cs
│   └── GeoPolygon.cs (NTS-backed)
├── Geometry/                        # NTS integration
│   ├── NtsExtensions.cs
│   └── GeometryConverter.cs
├── Rendering/
│   └── CustomSkiaRenderer.cs        # SkiaSharp extensions
├── Converters/
├── Behaviors/
├── ViewModels/
├── Themes/
├── Services/
│   ├── TileCacheService.cs          # BruTile + MBTiles
│   ├── ProjectionService.cs         # NTS + Proj
│   └── GeometryService.cs           # NTS ops wrapper
├── Extensions/
└── ...
```

### How the New Dependencies Enhance Core Components

1. **TiferetMap Control**
   - Uses `Mapsui.Map` internally with BruTile tile providers by default (OpenStreetMap, custom XYZ, offline MBTiles).
   - Full NTS geometry support for layers via `Mapsui.Nts`.

2. **Layer & Feature System**
   - `VectorLayerFactory.CreatePointLayer(GeoCoordinate, style)` etc., backed by NTS geometries.
   - Advanced ops: `geometry.Buffer(meters)`, `polygon.Contains(point)`, spatial queries, etc.

3. **Widgets**
   - ScaleBar & CardinalArrow use SkiaSharp for crisp, rotatable rendering.
   - Legend dynamically reflects NTS feature styles.

4. **Offline & Advanced Capabilities**
   - First-class MBTiles via BruTile.MbTiles.
   - Custom SkiaSharp drawing for dynamic symbols (e.g., rotated drone icons, measurement overlays).

5. **Performance & Extensibility**
   - NTS spatial indexing for large feature sets.
   - SkiaSharp for GPU-accelerated custom layers when Mapsui’s standard renderer isn’t enough.

### .csproj Snippet (Recommended)
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <!-- Core -->
    <PackageReference Include="Mapsui.Avalonia" Version="5.0.2" />
    <PackageReference Include="Mapsui.Nts" Version="5.0.2" />
    
    <!-- Tiling & Offline -->
    <PackageReference Include="BruTile" Version="5.0.0" />
    <PackageReference Include="BruTile.MbTiles" Version="5.0.0" />
    
    <!-- Custom Rendering -->
    <PackageReference Include="SkiaSharp" Version="3.0.0" />
    <PackageReference Include="SkiaSharp.Views.Avalonia" Version="3.0.0" />
    
    <!-- Avalonia -->
    <PackageReference Include="Avalonia" Version="..." />
    <!-- Your design system -->
  </ItemGroup>

</Project>
```

This setup keeps the library focused yet very capable. NTS and BruTile integrate cleanly with Mapsui, and SkiaSharp aligns perfectly with Avalonia’s rendering.
