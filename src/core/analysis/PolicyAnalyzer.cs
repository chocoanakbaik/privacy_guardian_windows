using System.Text.RegularExpressions;

namespace PrivacyGuardian.Core.Analysis;

public sealed record PolicyFinding(
    string Category,
    string Heading,
    string Attention,
    int LineNumber,
    string Evidence,
    string Explanation);

/// <summary>
/// A deterministic, explainable keyword-and-context screen for policy text.
/// It never claims a legal or overall-safety conclusion.
/// </summary>
public static class PolicyAnalyzer
{
    private sealed record Rule(
        string Category,
        string Heading,
        string Attention,
        string Explanation,
        Regex Pattern);

    private static readonly Rule[] Rules =
    [
        new("Pengumpulan data", "Data pribadi atau akun disebut", "Perlu ditinjau",
            "Periksa jenis data yang disebut, dasar pengumpulan, dan apakah data wajib atau opsional.",
            Rx(@"\b(collect|collects|collected|collecting|gather|gathers|gathered|obtain|obtains|obtain(ed)?|request|requests)\b.{0,100}\b(data|information|details|identifier|location|contact|account|personal)\b|\b(data|information)\b.{0,70}\b(we collect|is collected|may be collected)\b")),
        new("Penggunaan data", "Tujuan penggunaan data disebut", "Perlu ditinjau",
            "Periksa apakah penggunaan data dibatasi pada tujuan yang dijelaskan atau mencakup tujuan tambahan.",
            Rx(@"\b(use|uses|used|using|process|processes|processed|processing)\b.{0,100}\b(data|information|personal information|your information)\b|\b(data|information)\b.{0,70}\b(to provide|to improve|to personalize|for analytics|for marketing)\b")),
        new("Pembagian data", "Pembagian atau penjualan data disebut", "Perhatian tinggi",
            "Periksa penerima data, afiliasi, mitra, pengiklan, dan pilihan untuk menolak jika disebutkan.",
            Rx(@"\b(share|shares|shared|disclose|discloses|disclosed|transfer|transfers|transferred|sell|sells|sold|selling)\b.{0,120}\b(data|information|third parties|partners|advertisers|service providers)\b|\b(third[- ]party|third parties|service providers|advertisers)\b.{0,80}\b(data|information|share|receive|access)\b")),
        new("Retensi data", "Masa penyimpanan data disebut", "Perlu ditinjau",
            "Cari durasi penyimpanan, kriteria retensi, dan kondisi penghapusan setelah akun ditutup.",
            Rx(@"\b(retain|retains|retained|retention|store|stores|stored|storage|keep|keeps|kept|preserve|preserved|delete|deletion|erase|erasure)\b.{0,120}\b(data|information|record|account|period|necessary|indefinitely|as long as)\b|\b(indefinitely|as long as necessary|retention period|for \d+ (days|months|years))\b")),
        new("Pelacakan", "Cookies atau teknologi pelacakan disebut", "Perlu ditinjau",
            "Periksa cookie, analytics, advertising identifiers, pixels, serta kontrol yang tersedia bagi pengguna.",
            Rx(@"\b(cookies?|web beacons?|pixels?|tracking technologies|advertising identifiers|device identifiers|analytics|cross[- ]site tracking|interest[- ]based advertising)\b")),
        new("Hak pengguna", "Hak atau permintaan pengguna disebut", "Informasi hak",
            "Periksa syarat, batas waktu, verifikasi identitas, kanal pengajuan, dan pengecualian hak tersebut.",
            Rx(@"\b(right to (access|correct|delete|erase|object|restrict|port|withdraw|opt out)|you may (request|access|correct|delete|erase|opt out)|request (access|deletion|correction|a copy)|withdraw (your )?consent|opt[- ]out)\b")),
        new("Pengecualian dan kewajiban", "Pengecualian atau pengungkapan wajib disebut", "Perlu ditinjau",
            "Periksa cakupan pengecualian, pengungkapan kepada otoritas, kewajiban hukum, dan kondisi berlakunya.",
            Rx(@"\b(except|unless|notwithstanding|however|to the extent permitted|required by law|legal obligation|law enforcement|government authorities|court order|without notice)\b")),
        new("Pemrosesan lintas negara", "Transfer atau penyimpanan lintas negara disebut", "Perlu ditinjau",
            "Periksa lokasi pemrosesan, penerima lintas negara, dan perlindungan yang disebut oleh dokumen.",
            Rx(@"\b(international transfer|transfer(s|red)? outside|outside your country|cross[- ]border|different jurisdictions|other countries|global infrastructure)\b")),
    ];

    private static Regex Rx(string pattern) => new(
        pattern,
        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled,
        TimeSpan.FromMilliseconds(100));

    public static IReadOnlyList<PolicyFinding> Analyze(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return Array.Empty<PolicyFinding>();

        var findings = new List<PolicyFinding>();
        var lines = text.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');

        for (var index = 0; index < lines.Length; index++)
        {
            var line = Regex.Replace(lines[index].Trim(), @"\s+", " ");
            if (line.Length == 0)
                continue;

            foreach (var rule in Rules)
            {
                try
                {
                    if (!rule.Pattern.IsMatch(line))
                        continue;

                    var evidence = line.Length > 500 ? line[..497] + "..." : line;
                    findings.Add(new PolicyFinding(
                        rule.Category, rule.Heading, rule.Attention,
                        index + 1, evidence, rule.Explanation));
                }
                catch (RegexMatchTimeoutException)
                {
                    // Fail closed for this individual line; do not hang on crafted input.
                }
            }
        }

        return findings
            .GroupBy(f => (f.Category, f.LineNumber, f.Evidence))
            .Select(g => g.First())
            .ToArray();
    }
}
