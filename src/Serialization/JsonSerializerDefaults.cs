// <copyright file="JsonSerializerDefaults.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Foundation.Serialization;

/// <summary>
/// Represents the shared JSON serializer behavior used by Atya.
/// </summary>
/// <remarks>Superseded by <see cref="AtyaJsonDefaults"/>. This shim is removed in the next major version.</remarks>
[Obsolete("Use AtyaJsonDefaults. This type shadows System.Text.Json.JsonSerializerDefaults and is removed in the next major version.")]
public static class JsonSerializerDefaults
{
    /// <summary>
    /// Gets the default property name case-insensitive behavior.
    /// </summary>
    public const bool PropertyNameCaseInsensitive = AtyaJsonDefaults.PropertyNameCaseInsensitive;

    /// <summary>
    /// Gets the default indentation behavior.
    /// </summary>
    public const bool WriteIndented = AtyaJsonDefaults.WriteIndented;
}
