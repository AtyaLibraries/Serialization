# Serialization

`Serialization` is the repository for the `Atya.Foundation.Serialization` NuGet
package.

| | |
| --- | --- |
| Repository | [https://github.com/AtyaLibraries/Serialization](https://github.com/AtyaLibraries/Serialization) |
| NuGet | `Atya.Foundation.Serialization` |
| License | MIT |

This package provides shared `System.Text.Json` defaults so low-level packages
can serialize and deserialize with one consistent configuration.

## Included APIs

- `JsonSerializerDefaults`
- `JsonSerializerConfiguration`
- `JsonSerializerConfigurationExtensions`

## Layout

```text
.
|-- src/Serialization/
|-- tests/Serialization.UnitTests/
|-- samples/Serialization.Samples.Console/
|-- benchmarks/Serialization.Benchmarks/
`-- .github/
```

## Build, Test, Pack

```bash
dotnet restore ./Serialization.sln
dotnet build ./Serialization.sln --configuration Release --no-restore
dotnet test ./tests/Serialization.UnitTests/Serialization.UnitTests.csproj --configuration Release --no-build
dotnet pack ./src/Serialization/Serialization.csproj --configuration Release --no-build
```

Artifacts land in `artifacts/packages/`.
