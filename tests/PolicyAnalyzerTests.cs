using PrivacyGuardian.Core.Analysis;
using Xunit;

namespace PrivacyGuardian.Tests;

public sealed class PolicyAnalyzerTests
{
    [Fact]
    public void EmptyInputProducesNoFindings()
    {
        Assert.Empty(PolicyAnalyzer.Analyze(""));
        Assert.Empty(PolicyAnalyzer.Analyze(null));
        Assert.Empty(PolicyAnalyzer.Analyze("  \r\n  "));
    }

    [Fact]
    public void FindsUsefulPolicyCategoriesWithEvidenceAndLineNumbers()
    {
        const string policy = "We collect personal information when you register.\nWe may share data with third-party advertisers.\nWe retain records for 2 years.\nYou may request deletion of your information.";
        var findings = PolicyAnalyzer.Analyze(policy);

        Assert.Contains(findings, f => f.Category == "Pengumpulan data" && f.LineNumber == 1);
        Assert.Contains(findings, f => f.Category == "Pembagian data" && f.LineNumber == 2);
        Assert.Contains(findings, f => f.Category == "Retensi data" && f.LineNumber == 3);
        Assert.Contains(findings, f => f.Category == "Hak pengguna" && f.LineNumber == 4);
        Assert.All(findings, f => Assert.False(string.IsNullOrWhiteSpace(f.Evidence)));
    }

    [Fact]
    public void DoesNotClaimThatUnmatchedTextIsSafe()
    {
        var findings = PolicyAnalyzer.Analyze("We are a small company with a nice website.");
        Assert.Empty(findings);
    }

    [Fact]
    public void FlagsTrackingAndCrossBorderTransfersSeparately()
    {
        const string policy = "Cookies and web beacons are used for analytics.\nWe may transfer data outside your country.";
        var findings = PolicyAnalyzer.Analyze(policy);

        Assert.Contains(findings, f => f.Category == "Pelacakan");
        Assert.Contains(findings, f => f.Category == "Pemrosesan lintas negara");
    }

    [Fact]
    public void VeryLongLinesAreCappedInEvidence()
    {
        var line = "Cookies " + new string('x', 600);
        var findings = PolicyAnalyzer.Analyze(line);
        var finding = Assert.Single(findings);
        Assert.True(finding.Evidence.Length <= 500);
    }
}
