$ErrorActionPreference = "Stop"
$required = @(
  "README.md",
  "PrivacyGuardian.sln",
  "src/PrivacyGuardian.csproj",
  "tests/PrivacyGuardian.Tests.csproj",
  "resources/schemas",
  "resources/rules",
  "docs/architecture"
)
foreach ($path in $required) {
  if (-not (Test-Path $path)) { throw "Required project path missing: $path" }
}
Write-Host "Project structure verification passed."
