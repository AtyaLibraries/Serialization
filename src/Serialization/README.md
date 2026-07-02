# Atya.Foundation.Serialization

*Shared System.Text.Json defaults for Atya foundation packages.*

[![NuGet Version](https://img.shields.io/nuget/v/Atya.Foundation.Serialization?style=for-the-badge&logo=nuget&logoColor=white&label=NuGet&color=512BD4)](https://www.nuget.org/packages/Atya.Foundation.Serialization)
[![Downloads](https://img.shields.io/nuget/dt/Atya.Foundation.Serialization?style=for-the-badge&logo=nuget&logoColor=white&label=Downloads&color=512BD4)](https://www.nuget.org/packages/Atya.Foundation.Serialization)
![net10.0](https://img.shields.io/badge/net10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
[![License: MIT](https://img.shields.io/badge/License-MIT-512BD4?style=for-the-badge)](https://github.com/AtyaLibraries/Serialization/blob/development/LICENSE)

## Overview

`Atya.Foundation.Serialization` provides a small, shared `System.Text.Json` configuration surface for packages that need consistent JSON behavior without repeating options setup in every project.

The package configures camelCase property and dictionary keys, case-insensitive property reads, camelCase string enum values, null-value omission, and non-indented output.

## Features

- Shared read-only `JsonSerializerOptions` through `JsonSerializerConfiguration.Default`.
- Fresh mutable copies through `JsonSerializerConfiguration.CreateDefault()`.
- In-place configuration through `JsonSerializerConfiguration.ApplyDefaults(...)`.
- Extension helpers through `ApplyAtyaDefaults()` and `CreateAtyaDefaults()`.
- No direct runtime package dependencies beyond the .NET platform libraries used by `System.Text.Json`.

## Installation

**.NET CLI**

```bash
dotnet add package Atya.Foundation.Serialization
```

**Package Manager**

```powershell
Install-Package Atya.Foundation.Serialization
```

**PackageReference**

```xml
<PackageReference Include="Atya.Foundation.Serialization" Version="1.0.0" />
```

## Quick Start

```csharp
using System.Text.Json;
using Atya.Foundation.Serialization;

SampleRequest request = new("Ada Lovelace", UserRole.Admin, null);

string json = JsonSerializer.Serialize(request, JsonSerializerConfiguration.Default);

SampleRequest? roundTrip = JsonSerializer.Deserialize<SampleRequest>(
    """
    {
      "FIRSTNAME": "Ada Lovelace",
      "ROLE": "admin"
    }
    """,
    JsonSerializerConfiguration.CreateDefault());

JsonSerializerOptions mutableOptions = new JsonSerializerOptions()
    .ApplyAtyaDefaults();

Console.WriteLine(json);
Console.WriteLine(roundTrip?.Role);
Console.WriteLine(mutableOptions.PropertyNameCaseInsensitive);

internal sealed record SampleRequest(string FirstName, UserRole Role, string? OptionalNote);

internal enum UserRole
{
    Unknown = 0,
    Admin = 1,
}
```

## Usage

Use `JsonSerializerConfiguration.Default` when a shared read-only options instance is enough:

```csharp
string json = JsonSerializer.Serialize(value, JsonSerializerConfiguration.Default);
```

Use `CreateDefault()` when a caller needs a mutable options instance based on the shared defaults:

```csharp
JsonSerializerOptions options = JsonSerializerConfiguration.CreateDefault();
options.WriteIndented = true;
```

Use `ApplyDefaults(...)` or `ApplyAtyaDefaults()` when you already own an options instance:

```csharp
JsonSerializerOptions options = new JsonSerializerOptions()
    .ApplyAtyaDefaults();
```

## API Overview

| API | Purpose |
| --- | --- |
| `JsonSerializerConfiguration.Default` | Shared read-only `JsonSerializerOptions` instance. |
| `JsonSerializerConfiguration.CreateDefault()` | Creates a mutable copy of the shared defaults. |
| `JsonSerializerConfiguration.ApplyDefaults(JsonSerializerOptions)` | Applies the package defaults to an existing options instance. |
| `JsonSerializerConfigurationExtensions.ApplyAtyaDefaults(this JsonSerializerOptions)` | Extension wrapper over `ApplyDefaults(...)`. |
| `JsonSerializerConfigurationExtensions.CreateAtyaDefaults()` | Extension-oriented factory for a mutable default options instance. |
| `JsonSerializerDefaults.PropertyNameCaseInsensitive` | Constant value for case-insensitive property reads. |
| `JsonSerializerDefaults.WriteIndented` | Constant value for compact JSON output. |

## Dependencies

The package has no direct runtime package dependencies. It uses `System.Text.Json` APIs from the target .NET framework.

## Package Boundaries and Limitations

This package only centralizes serializer options. It does not provide a serializer abstraction, persistence model, wire protocol, source generation setup, or custom converters beyond adding a camelCase `JsonStringEnumConverter` when one is not already present.

## Project Structure

```text
.
|-- src/Serialization/                 Package source and NuGet README
|-- tests/Serialization.UnitTests/      Unit tests
|-- samples/Serialization.Samples.Console/  Console sample
|-- benchmarks/Serialization.Benchmarks/    BenchmarkDotNet project
|-- .github/workflows/                 CI, analysis, and publish workflows
|-- Serialization.sln                  Solution file
|-- README.md                          GitHub README
`-- LICENSE                            MIT license
```

## Compatibility

Targets `net10.0`.

## Testing

```bash
dotnet test ./tests/Serialization.UnitTests/Serialization.UnitTests.csproj --configuration Release
```

## Benchmarks

Benchmarks are available under `benchmarks/Serialization.Benchmarks/` for the configuration factory, in-place application, shared default reads, and serialize/deserialize paths. Run them locally with:

```bash
dotnet run --project ./benchmarks/Serialization.Benchmarks/Serialization.Benchmarks.csproj --configuration Release
```

## Contributing

Contributions are welcome. Please open an issue or pull request on [GitHub](https://github.com/AtyaLibraries/Serialization).

## License

Released under the **MIT** license. See [LICENSE](https://github.com/AtyaLibraries/Serialization/blob/development/LICENSE) for details.

---

## About Atya Libraries

`Atya.Foundation.Serialization` is part of **[Atya Libraries](https://github.com/AtyaLibraries)**, a family of focused, modern .NET libraries published under the reserved **`Atya.*`** prefix on NuGet. Every package shares the same principles: a small, clear public API, full test coverage, and consistent documentation.

Browse the full collection on [GitHub](https://github.com/AtyaLibraries) and [NuGet](https://www.nuget.org/profiles/ArsenAsulyan).

Made with .NET - Copyright 2026 Atya Libraries
