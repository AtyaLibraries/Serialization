
using System.Text.Json;

namespace Atya.Foundation.Serialization.UnitTests;

public sealed class JsonSerializationBehaviorTests
{
    [Fact]
    public void Serialize_Should_Use_CamelCase_Property_Names()
    {
        SampleRequest request = new("John", UserRole.Admin, null);

        string json = JsonSerializer.Serialize(request, JsonSerializerConfiguration.Default);

        json.Should().Contain("\"firstName\":\"John\"");
        json.Should().Contain("\"role\":\"admin\"");
    }

    [Fact]
    public void Serialize_Should_Ignore_Null_Values()
    {
        SampleRequest request = new("John", UserRole.Admin, null);

        string json = JsonSerializer.Serialize(request, JsonSerializerConfiguration.Default);

        json.Should().NotContain("optionalNote");
    }

    [Fact]
    public void Serialize_Should_Preserve_Dictionary_Keys_Verbatim()
    {
        Dictionary<string, int> payload = new()
        {
            ["X-Correlation-ID"] = 1,
            ["SKU"] = 2,
            ["Tenant_Id"] = 3,
        };

        string json = JsonSerializer.Serialize(payload, JsonSerializerConfiguration.Default);
        Dictionary<string, int>? roundTripped = JsonSerializer.Deserialize<Dictionary<string, int>>(
            json,
            JsonSerializerConfiguration.Default);

        json.Should().Contain("\"X-Correlation-ID\":1").And.Contain("\"SKU\":2").And.Contain("\"Tenant_Id\":3");
        roundTripped.Should().NotBeNull();
        roundTripped!.Keys.Should().BeEquivalentTo("X-Correlation-ID", "SKU", "Tenant_Id");
    }

    [Fact]
    public void Deserialize_Should_Be_Case_Insensitive()
    {
        const string json = """
                            {
                              "FIRSTNAME": "John",
                              "ROLE": "admin"
                            }
                            """;

        SampleRequest? result = JsonSerializer.Deserialize<SampleRequest>(json, JsonSerializerConfiguration.Default);

        result.Should().NotBeNull();
        result!.FirstName.Should().Be("John");
        result.Role.Should().Be(UserRole.Admin);
    }

    private sealed record SampleRequest(string FirstName, UserRole Role, string? OptionalNote);

    private enum UserRole
    {
        Unknown = 0,
        Admin = 1,
    }
}
