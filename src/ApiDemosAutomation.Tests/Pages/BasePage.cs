using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace ApiDemosAutomation.Tests.Pages;

public class BasePage
{
    protected readonly AndroidDriver Driver;
    protected readonly WebDriverWait Wait;

    protected BasePage(AndroidDriver driver, int waitSeconds = 10)
    {
        Driver = driver;
        Wait = new WebDriverWait(
            driver,
            TimeSpan.FromSeconds(waitSeconds));
    }

    protected IWebElement WaitVisible(By by) =>
        Wait.Until(d =>
        {
            var element = d.FindElement(by);
            return element.Displayed ? element : null;
        })!;

    protected IWebElement ScrollToText(string text) =>
        Driver.FindElement(
            MobileBy.AndroidUIAutomator(
                "new UiScrollable(new UiSelector().scrollable(true))" +
                $".scrollIntoView(new UiSelector().text(\"{text}\"))"));
}