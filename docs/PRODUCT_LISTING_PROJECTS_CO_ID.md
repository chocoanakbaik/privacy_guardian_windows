# Draf listing — Privacy Guardian Windows

> Status internal. Bukan listing siap-publikasi sampai pemeriksaan rilis dan uji manual Windows selesai.

## Judul sementara
Privacy Guardian Windows — Pemeriksa Dokumen Kebijakan Privasi Offline

## Deskripsi
Privacy Guardian Windows adalah alat desktop lokal untuk membantu pembaca menemukan bagian penting dalam dokumen kebijakan. Tempel atau buka teks kebijakan lalu periksa temuan dengan kutipan dan nomor baris sumber. Temuan bisa diekspor menjadi CSV untuk ditinjau lebih lanjut.

## Fungsi MVP saat ini
- Pemeriksaan teks dengan pola yang deterministik dan dapat dijelaskan.
- Kategori: pengumpulan data, penggunaan data, pembagian data, retensi, pelacakan, hak pengguna, pengecualian, dan transfer lintas negara.
- Kutipan bukti, nomor baris, dan alasan kenapa bagian ditandai.
- Input teks, Markdown, dan HTML lokal (maksimum 5 MB).
- Ekspor CSV dan TXT.
- Tidak mengunggah dokumen ke server dan tidak memerlukan akun.

## Batasan yang wajib dijelaskan
- Hanya pemeriksa pola teks. Bukan AI semantik, bukan penasihat hukum, dan bukan label “aman/tidak aman”.
- Hasil dapat melewatkan istilah atau salah menandai kalimat. Pengguna harus membuka konteks dokumen asli.
- PDF, DOCX, OCR, pengambilan URL otomatis, analisis semua bahasa, dan penilaian kebijakan otomatis belum disediakan pada MVP.
- Membutuhkan Windows dan .NET 8 runtime; paket distribusi sebaiknya menyertakan runtime setelah ukuran dan syarat redistribusi diverifikasi.
- Tidak boleh mengklaim akurasi atau kepatuhan hukum yang belum diuji.

## Gerbang sebelum jual
1. Lulus build dan unit test.
2. Uji pada Windows bersih dengan dan tanpa .NET runtime terpasang.
3. Verifikasi pembukaan file, file besar, karakter Unicode, kutipan, ekspor CSV, izin folder, dan pesan kesalahan.
4. Tambahkan installer, checksum, panduan pengguna, catatan versi, lisensi, dan kanal dukungan.
5. Ambil screenshot aplikasi dari build sebenarnya.
6. Tentukan harga dan ketentuan penggunaan setelah nilai produk dibandingkan dengan alternatif gratis.

Harga tidak ditetapkan sebelum distribusi dan batasan dukungan diputuskan.
