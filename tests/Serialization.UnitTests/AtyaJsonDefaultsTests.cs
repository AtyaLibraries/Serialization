namespace Atya.Foundation.Serialization.UnitTests;

public sealed class AtyaJsonDefaultsTests
{
    [Fact]
    public void AtyaJsonDefaults_Should_Expose_The_Shared_Values()
    {
        AtyaJsonDefaults.PropertyNameCaseInsensitive.Should().BeTrue();
        AtyaJsonDefaults.WriteIndented.Should().BeFalse();
    }

    [Fact]
    public void ObsoleteShim_Should_Forward_To_AtyaJsonDefaults()
    {
#pragma warning disable CS0618 // The shim is intentionally referenced to prove it forwards.
        JsonSerializerDefaults.PropertyNameCaseInsensitive.Should().Be(AtyaJsonDefaults.PropertyNameCaseInsensitive);
        JsonSerializerDefaults.WriteIndented.Should().Be(AtyaJsonDefaults.WriteIndented);
#pragma warning restore CS0618
    }
}
