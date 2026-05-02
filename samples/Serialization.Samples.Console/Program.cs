using System.Text.Json;
using Atya.Foundation.Serialization;

namespace Serialization.Samples.ConsoleApp;

public static class Program
{
    public static void Main()
    {
        SampleRequest request = new("Ada Lovelace", UserRole.Admin, null);

        string json = JsonSerializer.Serialize(request, JsonSerializerConfiguration.Default);
        SampleRequest? roundTrip = JsonSerializer.Deserialize<SampleRequest>(
            """
            {
              "FIRSTNAME": "Ada Lovelace",
              "ROLE": "admin"
            }
            """,
            JsonSerializerConfigurationExtensions.CreateAtyaDefaults());

        JsonSerializerOptions mutableOptions = new JsonSerializerOptions()
            .ApplyAtyaDefaults();

        Console.WriteLine("Atya.Foundation.Serialization sample");
        Console.WriteLine($"Serialized JSON: {json}");
        Console.WriteLine($"Round-trip role: {roundTrip?.Role}");
        Console.WriteLine($"Uses camelCase: {mutableOptions.PropertyNamingPolicy == JsonNamingPolicy.CamelCase}");
    }

    private sealed record SampleRequest(string FirstName, UserRole Role, string? OptionalNote);

    private enum UserRole
    {
        Unknown = 0,
        Admin = 1,
    }
}
