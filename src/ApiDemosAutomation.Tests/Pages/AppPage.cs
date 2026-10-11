using OpenQA.Selenium.Appium.Android;
namespace ApiDemosAutomation.Tests.Pages;

public class AppPage : BasePage
{
    public AppPage(AndroidDriver driver) : base(driver) { }

    public AlertDialogsPage OpenAlertDialogs()
    {
        ScrollToText("Alert Dialogs").Click();

        return new AlertDialogsPage(Driver);
    }
}

