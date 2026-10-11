using ApiDemosAutomation.Tests.Core;
using ApiDemosAutomation.Tests.Pages;

[TestFixture]
public class ScenarioTests : BaseTest
{
    private AppPage? _app;
    private AlertDialogsPage? _alerts;

    [TestCaseSource(typeof(ScenarioProvider), nameof(ScenarioProvider.All))]
    public void RunScenario(Scenario scenario)
    {
        foreach (var step in scenario.Steps) Execute(step);

        if (scenario.Expected == "DialogClosed")
            Assert.That(_alerts!.IsDialogClosed(), Is.True);
    }

    private void Execute(string step)
    {
        switch (step)
        {
            case "OpenApp": _app = new HomePage(Driver).OpenApp(); break;
            case "OpenAlertDialogs": _alerts = _app!.OpenAlertDialogs(); break;
            case "OpenOkCancelDialog": _alerts!.OpenOkCancelDialog(); break;
            case "PressCancel": _alerts!.CancelDialog(); break;
            case "PressOk": _alerts!.ConfirmDialog(); break;
            default: throw new ArgumentException($"Unknown step: {step}");
        }
    }
}