
using OpenQA.Selenium;

using OpenQA.Selenium.Appium.Android;



namespace ApiDemosAutomation.Tests.Pages;



public class AlertDialogsPage : BasePage

{

    private static readonly By OkButton = By.Id("android:id/button1");

    private static readonly By CancelButton = By.Id("android:id/button2");



    public AlertDialogsPage(AndroidDriver driver) : base(driver) { }



    public void OpenOkCancelDialog() =>

        ScrollToText("OK Cancel dialog with a message").Click();



    public bool IsDialogVisible() => WaitVisible(OkButton).Displayed;



    public void CancelDialog() => WaitVisible(CancelButton).Click();



    public void ConfirmDialog() => WaitVisible(OkButton).Click();



    public bool IsDialogClosed() =>

        Wait.Until(d => d.FindElements(OkButton).Count == 0);

}

