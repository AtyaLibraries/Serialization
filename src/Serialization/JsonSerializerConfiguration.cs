// <copyright file="JsonSerializerConfiguration.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Atya.Foundation.Serialization;

/// <summary>
/// Provides shared <see cref="JsonSerializerOptions" /> configuration for Atya.Foundation.Serialization.
/// </summary>
public static class JsonSerializerConfiguration
{
    private static readonly JsonSerializerOptions s_sharedDefault = CreateCore();

    /// <summary>
    /// Gets a shared read-only default options instance.
    /// </summary>
    public static JsonSerializerOptions Default => s_sharedDefault;

    /// <summary>
    /// Creates a new <see cref="JsonSerializerOptions" /> instance with Atya defaults.
    /// </summary>
    /// <returns>A new configured <see cref="JsonSerializerOptions" /> instance.</returns>
    public static JsonSerializerOptions CreateDefault()
    {
        return new JsonSerializerOptions(s_sharedDefault);
    }

    /// <summary>
    /// Applies Atya defaults to the specified <see cref="JsonSerializerOptions" /> instance.
    /// </summary>
    /// <param name="options">The options instance to configure.</param>
    /// <returns>The configured options instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="options" /> is null.</exception>
    public static JsonSerializerOptions ApplyDefaults(JsonSerializerOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        options.PropertyNameCaseInsensitive = JsonSerializerDefaults.PropertyNameCaseInsensitive;
        options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.WriteIndented = JsonSerializerDefaults.WriteIndented;

        EnsureStringEnumConverter(options);

        return options;
    }

    private static JsonSerializerOptions CreateCore()
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        ApplyDefaults(options);
        options.TypeInfoResolver ??= new DefaultJsonTypeInfoResolver();
        options.MakeReadOnly();
        return options;
    }

    private static void EnsureStringEnumConverter(JsonSerializerOptions options)
    {
        bool hasConverter = options.Converters.OfType<JsonStringEnumConverter>().Any();
        if (!hasConverter)
        {
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        }
    }
}
