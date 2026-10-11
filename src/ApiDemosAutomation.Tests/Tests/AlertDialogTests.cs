
using Allure.Net.Commons;

using Allure.NUnit;

using Allure.NUnit.Attributes;

using ApiDemosAutomation.Tests.Core;

using ApiDemosAutomation.Tests.Pages;

using NUnit.Framework;



namespace ApiDemosAutomation.Tests.Tests;



[TestFixture]

[AllureNUnit]

[AllureSuite("Alert dialogs")]

public class AlertDialogTests : BaseTest

{

    private AlertDialogsPage OpenAlertScreen() =>

        new HomePage(Driver).OpenApp().OpenAlertDialogs();



    [Test]

    public void OkCancelDialog_CanBeCancelled()

    {

        var alerts = OpenAlertScreen();



        AllureApi.Step("Open dialog", () => alerts.OpenOkCancelDialog());

        Assert.That(alerts.IsDialogVisible(), Is.True, "Dialog should be visible");



        AllureApi.Step("Press Cancel", () => alerts.CancelDialog());

        Assert.That(alerts.IsDialogClosed(), Is.True, "Dialog should be closed");

    }



    [Test]

    public void OkCancelDialog_CanBeConfirmed()

    {

        var alerts = OpenAlertScreen();



        AllureApi.Step("Open dialog", () => alerts.OpenOkCancelDialog());

        AllureApi.Step("Press OK", () => alerts.ConfirmDialog());



        Assert.That(alerts.IsDialogClosed(), Is.True);

    }

}

