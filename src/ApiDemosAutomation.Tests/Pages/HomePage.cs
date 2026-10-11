using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace ApiDemosAutomation.Tests.Pages;

public class HomePage : BasePage
{
    public HomePage(AndroidDriver driver) : base(driver)
    {
    }

    public bool IsLoaded() =>
        WaitVisible(MobileBy.AccessibilityId("App")).Displayed;

    public AppPage OpenApp()
    {
        WaitVisible(MobileBy.AccessibilityId("App")).Click();

        return new AppPage(Driver);
    }
}