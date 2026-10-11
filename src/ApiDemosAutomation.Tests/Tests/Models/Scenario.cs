public class Scenario
{
    public string Name { get; set; } = "";
    public List<string> Steps { get; set; } = new();
    public string Expected { get; set; } = "";
}
public class ScenarioFile { public List<Scenario> Scenarios { get; set; } = new(); }