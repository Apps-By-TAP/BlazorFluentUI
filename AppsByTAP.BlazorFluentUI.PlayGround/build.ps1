param(
    [Parameter(Mandatory=$true)]
    [ValidateSet("local", "ghpages")]
    [string]$Target
)

$projectPath = "AppsByTAP.BlazorFluentUI.PlayGround\AppsByTAP.BlazorFluentUI.Demo\AppsByTAP.BlazorFluentUI.Demo.csproj"

if ($Target -eq "local") {
    Write-Host "Building for LOCAL development..." -ForegroundColor Cyan
    dotnet build $projectPath
}
elseif ($Target -eq "ghpages") {
    Write-Host "Building for GITHUB PAGES (base href: /BlazorFluentUI/)..." -ForegroundColor Cyan
    dotnet build $projectPath /p:GHPages=true
    dotnet publish $projectPath /p:GHPages=true -c Release -o publish
    Write-Host "`n✓ Published to publish/ folder" -ForegroundColor Green
    Write-Host "  Deploy all files in publish/ to your GitHub Pages site." -ForegroundColor Yellow
}
