
using ApiDemosAutomation.Tests.Config;

using OpenQA.Selenium.Appium;

using OpenQA.Selenium.Appium.Android;



namespace ApiDemosAutomation.Tests.Core;



public static class DriverFactory

{

    public static AndroidDriver Create(TestSettings settings)

    {

        var options = new AppiumOptions

        {

            PlatformName = "Android",

            AutomationName = "UiAutomator2",

            DeviceName = settings.DeviceName,

            App = settings.ResolveAppPath()

        };

        options.AddAdditionalAppiumOption("autoGrantPermissions", true);

        options.AddAdditionalAppiumOption("newCommandTimeout", 120);



        return new AndroidDriver(new Uri(settings.AppiumServerUrl), options);

    }

}

