
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Atya.Foundation.Serialization.UnitTests;

public sealed class JsonSerializerConfigurationExtensionsTests
{
    [Fact]
    public void ApplyAtyaDefaults_Should_Configure_Options()
    {
        JsonSerializerOptions options = new();

        JsonSerializerOptions result = options.ApplyAtyaDefaults();

        result.Should().BeSameAs(options);
        options.PropertyNamingPolicy.Should().BeSameAs(JsonNamingPolicy.CamelCase);
        options.DictionaryKeyPolicy.Should().BeSameAs(JsonNamingPolicy.CamelCase);
        options.Converters.OfType<JsonStringEnumConverter>().Should().ContainSingle();
    }

    [Fact]
    public void CreateAtyaDefaults_Should_Return_New_Configured_Options()
    {
        JsonSerializerOptions options = JsonSerializerConfigurationExtensions.CreateAtyaDefaults();

        options.IsReadOnly.Should().BeFalse();
        options.PropertyNamingPolicy.Should().BeSameAs(JsonNamingPolicy.CamelCase);
        options.DictionaryKeyPolicy.Should().BeSameAs(JsonNamingPolicy.CamelCase);
        options.PropertyNameCaseInsensitive.Should().BeTrue();
        options.DefaultIgnoreCondition.Should().Be(JsonIgnoreCondition.WhenWritingNull);
    }
}
