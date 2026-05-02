using System.Text.Json;
using Atya.Foundation.Serialization;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Serialization.Benchmarks;

public static class Program
{
    public static void Main(string[] args)
    {
        _ = args;
        BenchmarkRunner.Run<JsonSerializerConfigurationBenchmarks>();
    }
}

[MemoryDiagnoser]
[ShortRunJob]
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
