using System.Text.Json;
using Atya.Foundation.Serialization;
using BenchmarkDotNet.Attributes;

namespace Serialization.Benchmarks;

#pragma warning disable CA1822 // BenchmarkDotNet requires benchmark methods to be instance methods.

public class JsonSerializerConfigurationBenchmarks
{
    private readonly SampleRequest _request = new("Ada Lovelace", UserRole.Admin, null);
    private readonly string _json = """{"firstName":"Ada Lovelace","role":"admin"}""";

    [Benchmark]
    public JsonSerializerOptions CreateDefault()
    {
        return JsonSerializerConfiguration.CreateDefault();
    }

    [Benchmark]
    public JsonSerializerOptions ApplyDefaults()
    {
        return JsonSerializerConfiguration.ApplyDefaults(new JsonSerializerOptions());
    }

    [Benchmark]
    public string SerializeWithSharedDefaults()
    {
        return JsonSerializer.Serialize(_request, JsonSerializerConfiguration.Default);
    }

    [Benchmark]
    public SampleRequest? DeserializeWithSharedDefaults()
    {
        return JsonSerializer.Deserialize<SampleRequest>(_json, JsonSerializerConfiguration.Default);
    }

    [Benchmark]
    public JsonSerializerOptions ReadSharedDefault()
    {
        return JsonSerializerConfiguration.Default;
    }

    public sealed record SampleRequest(string FirstName, UserRole Role, string? OptionalNote);

    public enum UserRole
    {
        Unknown = 0,
        Admin = 1,
    }
}

#pragma warning restore CA1822
