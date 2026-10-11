
using System.Text.Json;



namespace ApiDemosAutomation.Tests.Config;



public class TestSettings

{

    public string AppiumServerUrl { get; set; } = "http://127.0.0.1:4723";

    public string DeviceName { get; set; } = "emulator-5554";

    public string AppFileName { get; set; } = "ApiDemos-debug.apk";

    public int ExplicitWaitSeconds { get; set; } = 10;



    public static TestSettings Load()

    {

        var path = Path.Combine(AppContext.BaseDirectory, "Config", "appsettings.json");

        var json = File.ReadAllText(path);

        return JsonSerializer.Deserialize<TestSettings>(json)

               ?? throw new InvalidOperationException("Cannot read appsettings.json");

    }



    // Ищет apps/<AppFileName>, поднимаясь вверх по папкам от bin/...

    public string ResolveAppPath()

    {

        var dir = new DirectoryInfo(AppContext.BaseDirectory);

        while (dir != null)

        {

            var candidate = Path.Combine(dir.FullName, "apps", AppFileName);

            if (File.Exists(candidate)) return candidate;

            dir = dir.Parent;

        }

        throw new FileNotFoundException($"APK not found: apps/{AppFileName}");

    }

}

