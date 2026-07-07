using System.Text.Json;
using Atya.Foundation.Serialization;
using BenchmarkDotNet.Attributes;

namespace Serialization.Benchmarks;

#pragma warning disable CA1822 // BenchmarkDotNet requires benchmark methods to be instance methods.

/// <summary>
/// Benchmarks shared JSON serializer configuration operations.
/// </summary>
public class JsonSerializerConfigurationBenchmarks
{
    private readonly SampleRequest _request = new("Ada Lovelace", UserRole.Admin, null);
    private readonly string _json = """{"firstName":"Ada Lovelace","role":"admin"}""";

    /// <summary>
    /// Creates a new default options instance.
    /// </summary>
    /// <returns>The configured options instance.</returns>
    [Benchmark]
    public JsonSerializerOptions CreateDefault()
    {
        return JsonSerializerConfiguration.CreateDefault();
    }

    /// <summary>
    /// Applies defaults to a mutable options instance.
    /// </summary>
    /// <returns>The configured options instance.</returns>
    [Benchmark]
    public JsonSerializerOptions ApplyDefaults()
    {
        return JsonSerializerConfiguration.ApplyDefaults(new JsonSerializerOptions());
    }

    /// <summary>
    /// Serializes a sample request with shared defaults.
    /// </summary>
    /// <returns>The serialized JSON payload.</returns>
    [Benchmark]
    public string SerializeWithSharedDefaults()
    {
        return JsonSerializer.Serialize(_request, JsonSerializerConfiguration.Default);
    }

    /// <summary>
    /// Deserializes a sample request with shared defaults.
    /// </summary>
    /// <returns>The deserialized sample request.</returns>
    [Benchmark]
    public SampleRequest? DeserializeWithSharedDefaults()
    {
        return JsonSerializer.Deserialize<SampleRequest>(_json, JsonSerializerConfiguration.Default);
    }

    /// <summary>
    /// Reads the shared default options instance.
    /// </summary>
    /// <returns>The shared default options instance.</returns>
    [Benchmark]
    public JsonSerializerOptions ReadSharedDefault()
    {
        return JsonSerializerConfiguration.Default;
    }

    /// <summary>
    /// Represents a sample request payload used by the benchmarks.
    /// </summary>
    /// <param name="FirstName">The sample first name.</param>
    /// <param name="Role">The sample user role.</param>
    /// <param name="OptionalNote">The optional note.</param>
    public sealed record SampleRequest(string FirstName, UserRole Role, string? OptionalNote);

    /// <summary>
    /// Represents sample user roles.
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// The role is unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The user is an administrator.
        /// </summary>
        Admin = 1,
    }
}

#pragma warning restore CA1822
