// <copyright file="AtyaJsonDefaults.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Foundation.Serialization;

/// <summary>
/// Represents the shared JSON serializer behavior used by Atya.
/// </summary>
/// <remarks>
/// This type replaces <see cref="JsonSerializerDefaults"/>, whose name collided with
/// <c>System.Text.Json.JsonSerializerDefaults</c> in every file importing both namespaces.
/// </remarks>
public static class AtyaJsonDefaults
{
    /// <summary>
    /// Gets the default property name case-insensitive behavior.
    /// </summary>
    public const bool PropertyNameCaseInsensitive = true;

    /// <summary>
    /// Gets the default indentation behavior.
    /// </summary>
    public const bool WriteIndented = false;
}
