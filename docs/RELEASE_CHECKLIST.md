# Privacy Guardian Windows — Checklist Rilis

Status saat ini: **BELUM SIAP DIJUAL** sampai semua item wajib dilengkapi bukti.

## Build dan pengujian otomatis
- [ ] Build Release berhasil di workflow Windows.
- [ ] Unit test analyzer berhasil di Windows.
- [ ] Self-test analyzer berhasil.
- [ ] Tidak ada file rahasia atau dokumen pengguna dalam paket.
- [ ] Version, nama paket, dan catatan perubahan disamakan.

## Uji manual Windows
- [ ] Aplikasi dibuka di Windows bersih.
- [ ] Layout tetap digunakan pada resolusi layar yang didukung dan skala DPI berbeda.
- [ ] Tempel teks dan buka file TXT, MD, HTML.
- [ ] File rusak, encoding berbeda, file kosong, dan file di atas batas ditangani jelas.
- [ ] Setiap temuan memiliki kutipan yang benar dan nomor baris akurat.
- [ ] CSV dapat dibuka di Excel dan kolom tidak rusak oleh koma, tanda kutip, atau newline.
- [ ] Ekspor TXT memuat sumber, tanggal, dan batasan analisis.
- [ ] Tidak ada koneksi jaringan yang dibuat untuk menganalisis dokumen.
- [ ] Aplikasi tidak menyimpan teks kebijakan secara otomatis.
- [ ] Error izin baca/tulis tidak menyebabkan aplikasi tertutup mendadak.

## Paket komersial
- [ ] Installer Windows dan/uninstall diuji.
- [ ] Persyaratan .NET runtime dijelaskan atau runtime disertakan secara sah.
- [ ] SHA-256 dihitung setelah build final.
- [ ] Panduan pengguna dan log perubahan disertakan.
- [ ] Lisensi penggunaan, kebijakan pembaruan, harga, dukungan, dan kebijakan privasi disiapkan.
- [ ] Screenshot listing berasal dari build nyata.
- [ ] Listing tidak menyatakan nasihat hukum, jaminan keamanan, atau akurasi yang belum terbukti.

## Bukti rilis
Catat commit SHA, workflow run, OS, tanggal tes, penguji, hasil, checksum, dan masalah yang belum terselesaikan.
