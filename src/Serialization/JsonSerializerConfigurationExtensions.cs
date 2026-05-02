// <copyright file="JsonSerializerConfigurationExtensions.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using System.Text.Json;

namespace Atya.Foundation.Serialization;

/// <summary>
/// Provides extension methods for working with shared JSON serializer configuration.
/// </summary>
public static class JsonSerializerConfigurationExtensions
{
    /// <summary>
    /// Applies Atya defaults to the specified <see cref="JsonSerializerOptions" />.
    /// </summary>
    /// <param name="options">The options instance to configure.</param>
    /// <returns>The configured options instance.</returns>
    public static JsonSerializerOptions ApplyAtyaDefaults(this JsonSerializerOptions options)
    {
        return JsonSerializerConfiguration.ApplyDefaults(options);
    }

    /// <summary>
    /// Creates a copy of the shared Atya default <see cref="JsonSerializerOptions" />.
    /// </summary>
    /// <returns>A new configured <see cref="JsonSerializerOptions" /> instance.</returns>
    public static JsonSerializerOptions CreateAtyaDefaults()
    {
        return JsonSerializerConfiguration.CreateDefault();
    }
}
