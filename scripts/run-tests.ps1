
param(

    [string]$Filter = ""   # например: -Filter "Name~Cancelled"

)

$root = Split-Path $PSScriptRoot -Parent

Set-Location $root



if ($Filter -ne "") { dotnet test --filter $Filter } else { dotnet test }



$results = Get-ChildItem -Path "$root\src" -Recurse -Directory -Filter "allure-results" | Select-Object -First 1

if ($results) {

    Write-Host "Allure results: $($results.FullName)"

    Write-Host "Открыть отчёт:  allure serve `"$($results.FullName)`""

}

