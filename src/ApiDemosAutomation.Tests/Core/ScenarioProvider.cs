using System.Text.Json;

public static class ScenarioProvider
{
    public static IEnumerable<TestCaseData> All()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Config", "scenarios.json");
        var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var file = JsonSerializer.Deserialize<ScenarioFile>(File.ReadAllText(path), opts)!;

        foreach (var s in file.Scenarios)
            yield return new TestCaseData(s).SetName(s.Name);   
    }
}