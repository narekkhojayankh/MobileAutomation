using Allure.Net.Commons;
using ApiDemosAutomation.Tests.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace ApiDemosAutomation.Tests.Core;

public abstract class BaseTest
{
    protected AndroidDriver Driver = null!;
    protected TestSettings Settings = null!;

    [SetUp]
    public void SetUp()
    {
        Settings = TestSettings.Load();
        Driver = DriverFactory.Create(Settings);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var bytes = ((ITakesScreenshot)Driver)
                    .GetScreenshot()
                    .AsByteArray;

                AllureApi.AddAttachment(
                    "Screenshot on failure",
                    "image/png",
                    bytes,
                    ".png");
            }
        }
        finally
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}