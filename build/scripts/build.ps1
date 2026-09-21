param(
  [string]$Configuration = "Release"
)

$ErrorActionPreference = "Stop"
dotnet restore PrivacyGuardian.sln
dotnet build PrivacyGuardian.sln --configuration $Configuration --no-restore
