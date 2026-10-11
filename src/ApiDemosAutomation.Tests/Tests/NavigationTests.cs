
using Allure.Net.Commons;

using Allure.NUnit;

using Allure.NUnit.Attributes;

using ApiDemosAutomation.Tests.Core;

using ApiDemosAutomation.Tests.Pages;

using NUnit.Framework;



namespace ApiDemosAutomation.Tests.Tests;



[TestFixture]
[AllureNUnit]
[AllureSuite("Navigation")]

public class NavigationTests : BaseTest

{

    [Test]

    public void HomeScreen_IsLoaded()

    {

        var home = new HomePage(Driver);

        AllureApi.Step("Check home screen is displayed", () =>

            Assert.That(home.IsLoaded(), Is.True));

    }



    [Test]
    public void CanNavigate_ToAlertDialogs()

    {

        var home = new HomePage(Driver);

        AppPage app = null!;

        AlertDialogsPage alerts = null!;



        AllureApi.Step("Open App section", () => app = home.OpenApp());

        AllureApi.Step("Open Alert Dialogs", () => alerts = app.OpenAlertDialogs());

        AllureApi.Step("Open OK/Cancel dialog", () => alerts.OpenOkCancelDialog());



        Assert.That(alerts.IsDialogVisible(), Is.True);

    }

}

