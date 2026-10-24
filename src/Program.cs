using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using PrivacyGuardian.Core.Analysis;

namespace PrivacyGuardian;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        if (args.Contains("--self-test", StringComparer.OrdinalIgnoreCase))
        {
            RunSelfTest();
            return;
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new PolicyReviewForm());
    }

    private static void RunSelfTest()
    {
        var sample = "We collect personal information when you register.\nWe may share data with third-party advertisers.\nWe retain records for 2 years.\nYou may request deletion of your information.";
        var findings = PolicyAnalyzer.Analyze(sample);
        if (findings.Count < 4)
            throw new InvalidOperationException($"Self-test expected at least 4 findings, got {findings.Count}.");
        Console.WriteLine($"PASS: {findings.Count} findings from sample policy.");
    }
}

internal sealed class PolicyReviewForm : Form
{
    private readonly RichTextBox _source = new();
    private readonly DataGridView _grid = new();
    private readonly RichTextBox _detail = new();
    private readonly Label _status = new();
    private readonly Label _summary = new();
    private readonly Label _fileLabel = new();
    private IReadOnlyList<PolicyFinding> _findings = Array.Empty<PolicyFinding>();
    private string? _sourcePath;

    public PolicyReviewForm()
    {
        Text = "Privacy Guardian Windows";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(1000, 680);
        Size = new Size(1280, 820);
        BackColor = Color.FromArgb(13, 18, 32);
        ForeColor = Color.FromArgb(235, 241, 250);
        Font = new Font("Segoe UI", 9.5F);
        BuildInterface();
        LoadSample();
    }

    private void BuildInterface()
    {
        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Padding = new Padding(18),
            BackColor = BackColor,
        };
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 92));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
        Controls.Add(root);

        var header = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2 };
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 550));
        header.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        header.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        var title = new Label
        {
            Text = "PRIVACY GUARDIAN",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI Semibold", 21F),
            ForeColor = Color.FromArgb(112, 224, 222),
            TextAlign = ContentAlignment.MiddleLeft,
        };
        var subtitle = new Label
        {
            Text = "Pemeriksa dokumen kebijakan • analisis lokal • berbasis bukti",
            Dock = DockStyle.Fill,
            ForeColor = Color.FromArgb(179, 191, 210),
            TextAlign = ContentAlignment.MiddleLeft,
        };
        header.Controls.Add(title, 0, 0);
        header.Controls.Add(subtitle, 0, 1);

        var actions = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.RightToLeft,
            WrapContents = false,
            Padding = new Padding(0, 8, 0, 0),
        };
        actions.Controls.Add(Button("Ekspor CSV", ExportCsv));
        actions.Controls.Add(Button("Ekspor TXT", ExportText));
        actions.Controls.Add(Button("Analisis", AnalyzeSource, true));
        actions.Controls.Add(Button("Buka dokumen", OpenDocument));
        actions.Controls.Add(Button("Contoh", (_, _) => LoadSample()));
        header.Controls.Add(actions, 1, 0);
        header.SetRowSpan(actions, 2);
        root.Controls.Add(header, 0, 0);

        var split = new SplitContainer
        {
            Dock = DockStyle.Fill,
            Orientation = Orientation.Vertical,
            SplitterDistance = 520,
            BackColor = BackColor,
            Panel1MinSize = 320,
            Panel2MinSize = 430,
        };
        root.Controls.Add(split, 0, 1);

        var inputLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3,
            Padding = new Padding(0, 0, 10, 0), BackColor = BackColor,
        };
        inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        inputLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        inputLayout.Controls.Add(SectionLabel("SUMBER DOKUMEN"), 0, 0);
        _source.Dock = DockStyle.Fill;
        _source.AcceptsTab = true;
        _source.WordWrap = true;
        _source.BorderStyle = BorderStyle.FixedSingle;
        _source.BackColor = Color.FromArgb(20, 28, 46);
        _source.ForeColor = Color.FromArgb(230, 237, 248);
        _source.Font = new Font("Consolas", 10F);
        inputLayout.Controls.Add(_source, 0, 1);
        _fileLabel.Text = "Tempel teks atau buka file .txt, .md, .html";
        _fileLabel.Dock = DockStyle.Fill;
        _fileLabel.ForeColor = Color.FromArgb(150, 169, 193);
        _fileLabel.TextAlign = ContentAlignment.MiddleLeft;
        inputLayout.Controls.Add(_fileLabel, 0, 2);
        split.Panel1.Controls.Add(inputLayout);

        var resultLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 4,
            Padding = new Padding(10, 0, 0, 0), BackColor = BackColor,
        };
        resultLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        resultLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 66));
        resultLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        resultLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 34));
        resultLayout.Controls.Add(SectionLabel("TEMUAN BERDASARKAN TEKS"), 0, 0);

        _grid.Dock = DockStyle.Fill;
        _grid.ReadOnly = true;
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        _grid.AllowUserToResizeRows = false;
        _grid.RowHeadersVisible = false;
        _grid.MultiSelect = false;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _grid.AutoGenerateColumns = false;
        _grid.BackgroundColor = Color.FromArgb(20, 28, 46);
        _grid.BorderStyle = BorderStyle.FixedSingle;
        _grid.EnableHeadersVisualStyles = false;
        _grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 44, 68);
        _grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        _grid.DefaultCellStyle.BackColor = Color.FromArgb(20, 28, 46);
        _grid.DefaultCellStyle.ForeColor = Color.FromArgb(230, 237, 248);
        _grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 75, 96);
        _grid.DefaultCellStyle.SelectionForeColor = Color.White;
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Kategori", DataPropertyName = nameof(PolicyFinding.Category), Width = 130 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Perhatian", DataPropertyName = nameof(PolicyFinding.Attention), Width = 110 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Baris", DataPropertyName = nameof(PolicyFinding.LineNumber), Width = 48 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Potongan bukti", DataPropertyName = nameof(PolicyFinding.Evidence), AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        _grid.SelectionChanged += (_, _) => ShowSelectedFinding();
        resultLayout.Controls.Add(_grid, 0, 1);

        resultLayout.Controls.Add(SectionLabel("POTONGAN BUKTI DAN PENJELASAN"), 0, 2);
        _detail.Dock = DockStyle.Fill;
        _detail.ReadOnly = true;
        _detail.BorderStyle = BorderStyle.FixedSingle;
        _detail.BackColor = Color.FromArgb(20, 28, 46);
        _detail.ForeColor = Color.FromArgb(230, 237, 248);
        _detail.Font = new Font("Segoe UI", 10F);
        resultLayout.Controls.Add(_detail, 0, 3);
        split.Panel2.Controls.Add(resultLayout);

        var footer = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
        footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        footer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 270));
        _status.Text = "Siap. Dokumen tidak diunggah ke server.";
        _status.ForeColor = Color.FromArgb(150, 169, 193);
        _status.Dock = DockStyle.Fill;
        _status.TextAlign = ContentAlignment.MiddleLeft;
        _summary.Text = "Belum dianalisis";
        _summary.ForeColor = Color.FromArgb(112, 224, 222);
        _summary.Dock = DockStyle.Fill;
        _summary.TextAlign = ContentAlignment.MiddleRight;
        footer.Controls.Add(_status, 0, 0);
        footer.Controls.Add(_summary, 1, 0);
        root.Controls.Add(footer, 0, 2);
    }

    private static Label SectionLabel(string text) => new()
    {
        Text = text, Dock = DockStyle.Fill, ForeColor = Color.FromArgb(112, 224, 222),
        TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI Semibold", 9.5F),
    };

    private static Button Button(string text, EventHandler onClick, bool primary = false)
    {
        var button = new Button
        {
            Text = text, AutoSize = true, Height = 34, Margin = new Padding(5, 0, 0, 0),
            FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand,
            BackColor = primary ? Color.FromArgb(28, 153, 154) : Color.FromArgb(31, 44, 68),
            ForeColor = Color.White, Padding = new Padding(9, 3, 9, 3),
        };
        button.FlatAppearance.BorderSize = 0;
        button.Click += onClick;
        return button;
    }

    private void OpenDocument(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "Buka dokumen kebijakan",
            Filter = "Teks dan HTML|*.txt;*.md;*.html;*.htm|Semua file|*.*",
            CheckFileExists = true,
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            var info = new FileInfo(dialog.FileName);
            if (info.Length > 5 * 1024 * 1024)
            {
                MessageBox.Show(this, "MVP saat ini membatasi file teks hingga 5 MB.", "File terlalu besar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var text = File.ReadAllText(dialog.FileName, Encoding.UTF8);
            if (Path.GetExtension(dialog.FileName).Equals(".html", StringComparison.OrdinalIgnoreCase)
                || Path.GetExtension(dialog.FileName).Equals(".htm", StringComparison.OrdinalIgnoreCase))
            {
                text = Regex.Replace(text, @"(?is)<(script|style)\b[^>]*>.*?</\1>", " ");
                text = Regex.Replace(text, @"(?s)<[^>]+>", " ");
                text = System.Net.WebUtility.HtmlDecode(text);
            }
            _source.Text = text;
            _sourcePath = dialog.FileName;
            _fileLabel.Text = Path.GetFileName(dialog.FileName);
            _status.Text = "Dokumen dibuka secara lokal. Belum ada hasil baru sampai Analisis ditekan.";
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or DecoderFallbackException)
        {
            MessageBox.Show(this, "File tidak dapat dibaca. Periksa izin dan encoding file.", "Gagal membuka file",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadSample()
    {
        _sourcePath = null;
        _fileLabel.Text = "Contoh lokal (data ilustrasi)";
        _source.Text = """
            Privacy Notice — illustrative example only

            We collect personal information such as your name, email address and device identifiers when you create an account.
            We use this information to provide the service, improve our products and personalize recommendations.
            We may share data with third-party advertisers and analytics service providers.
            We retain account records for 2 years after account closure unless a longer period is required by law.
            Cookies and similar tracking technologies may be used to understand service usage.
            You may request access to, correction of, or deletion of your personal information.
            We may disclose information to law enforcement when required by law.
            """;
        AnalyzeSource(this, EventArgs.Empty);
    }

    private void AnalyzeSource(object? sender, EventArgs e)
    {
        _findings = PolicyAnalyzer.Analyze(_source.Text);
        _grid.DataSource = null;
        _grid.DataSource = _findings.ToList();
        _summary.Text = $"{_findings.Count} temuan • {_findings.Select(f => f.Category).Distinct().Count()} kategori";
        _status.Text = "Pemeriksaan berbasis pola selesai. Tidak ada penilaian hukum atau jaminan keamanan.";
        if (_findings.Count == 0)
            _detail.Text = "Tidak ada pola yang cocok terdeteksi. Ini bukan bukti bahwa dokumen tidak mengandung kebijakan penting.";
        else
        {
            _grid.ClearSelection();
            _grid.Rows[0].Selected = true;
            ShowSelectedFinding();
        }
    }

    private void ShowSelectedFinding()
    {
        if (_grid.CurrentRow?.DataBoundItem is not PolicyFinding finding) return;
        _detail.Text = $"Kategori: {finding.Category}\r\nPerhatian: {finding.Attention}\r\nBaris: {finding.LineNumber}\r\n\r\nBukti dari dokumen:\r\n“{finding.Evidence}”\r\n\r\nMengapa ditandai:\r\n{finding.Explanation}\r\n\r\nCatatan: temuan ini hanya menunjukkan kecocokan pola; baca konteks asli sebelum mengambil keputusan.";
    }

    private void ExportCsv(object? sender, EventArgs e)
    {
        if (!EnsureAnalyzed()) return;
        using var dialog = new SaveFileDialog
        {
            Title = "Ekspor temuan ke CSV",
            Filter = "CSV UTF-8|*.csv",
            FileName = "privacy-guardian-report.csv",
            DefaultExt = "csv",
            AddExtension = true,
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        var rows = new List<string> { "Kategori,Perhatian,Baris,Bukti,Penjelasan" };
        rows.AddRange(_findings.Select(f => string.Join(",", new[]
        {
            Csv(f.Category), Csv(f.Attention), f.LineNumber.ToString(), Csv(f.Evidence), Csv(f.Explanation)
        })));
        File.WriteAllText(dialog.FileName, "\uFEFF" + string.Join("\r\n", rows), new UTF8Encoding(true));
        _status.Text = $"CSV disimpan: {Path.GetFileName(dialog.FileName)}";
    }

    private void ExportText(object? sender, EventArgs e)
    {
        if (!EnsureAnalyzed()) return;
        using var dialog = new SaveFileDialog
        {
            Title = "Ekspor ringkasan",
            Filter = "Laporan teks|*.txt",
            FileName = "privacy-guardian-report.txt",
            DefaultExt = "txt",
            AddExtension = true,
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        var lines = new List<string>
        {
            "Privacy Guardian Windows — Laporan Pemeriksaan Teks",
            $"Tanggal ekspor (UTC): {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}",
            $"Sumber: {_sourcePath ?? "Teks yang ditempel / contoh lokal"}",
            $"Jumlah temuan: {_findings.Count}",
            "",
            "BATASAN: Hasil berbasis pola teks, bukan nasihat hukum atau penilaian keamanan menyeluruh.",
            ""
        };
        foreach (var f in _findings)
        {
            lines.Add($"[{f.Attention}] {f.Category} — baris {f.LineNumber}");
            lines.Add($"Bukti: {f.Evidence}");
            lines.Add($"Catatan: {f.Explanation}");
            lines.Add("");
        }
        File.WriteAllText(dialog.FileName, string.Join(Environment.NewLine, lines), new UTF8Encoding(true));
        _status.Text = $"Laporan disimpan: {Path.GetFileName(dialog.FileName)}";
    }

    private bool EnsureAnalyzed()
    {
        if (_source.TextLength == 0)
        {
            MessageBox.Show(this, "Tempel atau buka dokumen terlebih dahulu.", "Dokumen kosong",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }
        if (_findings.Count == 0 && _summary.Text == "Belum dianalisis")
            AnalyzeSource(this, EventArgs.Empty);
        return true;
    }

    private static string Csv(string value) => "\"" + value.Replace("\"", "\"\"") + "\"";
}
