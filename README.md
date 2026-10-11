
# ApiDemos Automation (Appium 2 + C# + NUnit + Allure)



Mini project: Android UI automation of the Appium ApiDemos app.



## Stack

C#/.NET, NUnit, Appium 2.x (UiAutomator2), Allure Reports, Page Object Model.



## Run

1. Start an Android emulator (`adb devices` must show it).

2. `./scripts/start-appium.ps1` (keep it running).

3. `./scripts/run-tests.ps1` or `dotnet test --filter "Name~Cancelled"`.

4. `allure serve <path to allure-results>`.



## Structure

- `Config/` settings loaded from JSON

- `Core/` driver factory and base test (screenshot on failure)

- `Pages/` page objects

- `Tests/` test classes

