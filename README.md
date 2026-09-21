# Privacy Guardian Windows

**Privacy Guardian Windows** adalah aplikasi desktop Windows yang dirancang untuk membantu pengguna memahami bagaimana sebuah aplikasi, website, atau layanan menangani data pribadi mereka melalui analisis **Privacy Policy, Terms of Service, Cookie Policy, Data Policy, dan dokumen kebijakan terkait**.

Privacy Guardian mengubah dokumen kebijakan yang panjang dan sulit dipahami menjadi informasi yang lebih terstruktur, sehingga pengguna dapat mengetahui:

* data apa yang dikumpulkan;
* bagaimana data digunakan;
* dengan siapa data dapat dibagikan;
* berapa lama data dapat disimpan;
* teknologi pelacakan apa yang digunakan;
* hak apa yang dimiliki pengguna;
* kondisi atau pengecualian penting;
* serta bagian kebijakan yang membutuhkan perhatian lebih lanjut.

Privacy Guardian **tidak menggantikan dokumen kebijakan asli dan bukan merupakan penasihat hukum**.

Aplikasi ini merupakan alat bantu untuk membaca, memahami, dan menemukan informasi penting dalam dokumen kebijakan.

---

# Daftar Isi

* [Tentang Privacy Guardian](#tentang-privacy-guardian)
* [Masalah yang Diselesaikan](#masalah-yang-diselesaikan)
* [Tujuan](#tujuan)
* [Prinsip Utama](#prinsip-utama)
* [Platform](#platform)
* [Fitur](#fitur)
* [Cara Kerja](#cara-kerja)
* [Jenis Informasi yang Dianalisis](#jenis-informasi-yang-dianalisis)
* [Sistem Analisis](#sistem-analisis)
* [Indikator Risiko](#indikator-risiko)
* [Transparansi Hasil](#transparansi-hasil)
* [Privasi Pengguna](#privasi-pengguna)
* [Keamanan](#keamanan)
* [Performa dan Laptop Berspesifikasi Rendah](#performa-dan-laptop-berspesifikasi-rendah)
* [Kebutuhan Sistem](#kebutuhan-sistem)
* [Instalasi](#instalasi)
* [Cara Menggunakan](#cara-menggunakan)
* [Input yang Didukung](#input-yang-didukung)
* [Output Analisis](#output-analisis)
* [Batasan Analisis](#batasan-analisis)
* [Offline dan Koneksi Internet](#offline-dan-koneksi-internet)
* [Data dan Penyimpanan](#data-dan-penyimpanan)
* [Struktur Aplikasi](#struktur-aplikasi)
* [Arsitektur](#arsitektur)
* [Prinsip Pengembangan](#prinsip-pengembangan)
* [Pengujian](#pengujian)
* [Keamanan Dependency](#keamanan-dependency)
* [Tim dan Tanggung Jawab](#tim-dan-tanggung-jawab)
* [Lisensi dan Distribusi](#lisensi-dan-distribusi)
* [Disclaimer](#disclaimer)
* [Visi Project](#visi-project)

---

# Tentang Privacy Guardian

Banyak layanan digital meminta pengguna menyetujui Privacy Policy sebelum menggunakan produk mereka.

Masalahnya, dokumen tersebut sering:

* sangat panjang;
* menggunakan istilah hukum;
* menggunakan istilah teknis;
* memiliki banyak pengecualian;
* sulit dipahami pengguna biasa;
* menyembunyikan informasi penting di antara banyak paragraf.

Privacy Guardian dibuat untuk mengurangi masalah tersebut.

Pengguna dapat memberikan dokumen kebijakan kepada aplikasi, kemudian Privacy Guardian menganalisis isi dokumen dan menyusun informasi yang relevan ke dalam bentuk yang lebih mudah dipahami.

Tujuan utamanya bukan membuat pengguna berhenti membaca Privacy Policy.

Tujuannya adalah membuat **isi Privacy Policy lebih mudah dibaca dan dipahami**.

---

# Masalah yang Diselesaikan

Privacy Guardian berfokus pada tiga masalah utama.

## 1. Dokumen Terlalu Panjang

Pengguna sering tidak memiliki waktu untuk membaca seluruh dokumen kebijakan.

Privacy Guardian membantu menemukan bagian-bagian yang relevan.

## 2. Bahasa Sulit Dipahami

Dokumen kebijakan dapat menggunakan bahasa hukum dan teknis.

Privacy Guardian membantu mengubah informasi tersebut menjadi penjelasan yang lebih sederhana tanpa menghilangkan konteks penting.

## 3. Informasi Penting Sulit Ditemukan

Informasi seperti pengumpulan data, pembagian data, retensi, lokasi, cookies, atau hak pengguna dapat tersebar di banyak bagian dokumen.

Privacy Guardian mengelompokkan informasi tersebut berdasarkan kategori.

---

# Tujuan

Privacy Guardian memiliki tujuan utama:

> **Membantu pengguna memahami bagaimana data mereka diperlakukan sebelum mereka menggunakan sebuah layanan.**

Aplikasi tidak dibuat untuk menentukan apakah sebuah perusahaan atau layanan "baik" atau "buruk".

Privacy Guardian menyajikan informasi berdasarkan isi dokumen yang dianalisis sehingga pengguna dapat membuat keputusan mereka sendiri.

---

# Prinsip Utama

## Privacy First

Privacy Guardian sendiri harus menghormati privasi pengguna.

Dokumen yang dianalisis merupakan data pengguna dan harus diperlakukan sebagai informasi yang dapat bersifat sensitif.

## Lightweight

Aplikasi harus dapat berjalan dengan penggunaan resource yang rendah.

## Transparent

Setiap hasil analisis harus memiliki dasar yang dapat ditelusuri kembali ke dokumen.

## Understandable

Hasil harus dapat dipahami pengguna biasa.

## Evidence-Based

Sistem tidak boleh membuat kesimpulan yang tidak memiliki dasar dari dokumen.

## User Control

Pengguna harus memiliki kendali terhadap dokumen dan data yang diproses aplikasi.

---

# Platform

Privacy Guardian Windows dikembangkan khusus untuk:

**Microsoft Windows Desktop**

Project ini menggunakan pendekatan desktop sehingga analisis dapat dilakukan langsung dari komputer pengguna.

Versi platform lain tidak termasuk dalam cakupan aplikasi Windows ini.

---

# Fitur

## Privacy Policy Analyzer

Menganalisis isi Privacy Policy dan dokumen kebijakan terkait.

## Data Collection Analysis

Mengidentifikasi jenis data yang disebutkan dalam dokumen.

Contoh:

* nama;
* alamat email;
* nomor telepon;
* informasi akun;
* alamat IP;
* informasi perangkat;
* lokasi;
* aktivitas pengguna;
* cookies;
* identifier;
* data diagnostik;
* informasi transaksi.

## Data Usage Analysis

Mengidentifikasi tujuan penggunaan data.

Contoh:

* penyediaan layanan;
* keamanan;
* analitik;
* personalisasi;
* komunikasi;
* pemasaran;
* periklanan;
* pengembangan produk.

## Data Sharing Analysis

Mencari informasi mengenai kemungkinan pembagian data dengan pihak lain.

Contoh:

* service provider;
* partner;
* perusahaan afiliasi;
* pengiklan;
* penyedia analitik;
* pihak berwenang;
* pihak ketiga lainnya.

## Data Retention Analysis

Mengidentifikasi informasi mengenai penyimpanan data dan masa retensi apabila dijelaskan dalam dokumen.

## Tracking Analysis

Mendeteksi penyebutan teknologi seperti:

* cookies;
* tracking technologies;
* analytics;
* advertising identifiers;
* pixel;
* device identifiers.

## User Rights Analysis

Mencari hak pengguna yang disebutkan dalam kebijakan.

Contoh:

* hak mengakses;
* hak memperbaiki;
* hak menghapus;
* hak menarik persetujuan;
* hak membatasi pemrosesan;
* hak menolak pemrosesan;
* hak memperoleh salinan data.

## Important Clause Detection

Menandai bagian kebijakan yang memiliki informasi penting atau pengecualian tertentu.

## Source Reference

Hasil analisis harus dapat dikaitkan kembali dengan bagian dokumen yang menjadi sumber informasi.

---

# Cara Kerja

Secara umum, Privacy Guardian bekerja melalui tahapan berikut:

```text
Dokumen Kebijakan
       │
       ▼
Input / Import
       │
       ▼
Text Extraction
       │
       ▼
Text Cleaning
       │
       ▼
Document Segmentation
       │
       ▼
Privacy Analysis
       │
       ├── Data Collection
       ├── Data Usage
       ├── Data Sharing
       ├── Retention
       ├── Tracking
       ├── User Rights
       └── Important Clauses
       │
       ▼
Evidence Mapping
       │
       ▼
Result Processing
       │
       ▼
Privacy Report
       │
       ▼
User
```

Setiap tahap memiliki fungsi yang berbeda dan harus dapat diuji secara terpisah.

---

# Jenis Informasi yang Dianalisis

Privacy Guardian mengelompokkan informasi ke dalam beberapa kategori.

### Personal Information

Informasi yang dapat berkaitan dengan identitas pengguna.

### Device Information

Informasi mengenai perangkat yang digunakan.

### Location Information

Informasi mengenai lokasi pengguna.

### Usage Information

Informasi mengenai aktivitas atau penggunaan layanan.

### Technical Information

Informasi teknis seperti IP address, browser, operating system, identifier, dan informasi diagnostik.

### Financial Information

Informasi pembayaran atau transaksi apabila disebutkan dalam dokumen.

### Communication Information

Informasi yang berkaitan dengan komunikasi pengguna dengan layanan.

### Tracking Information

Informasi mengenai cookies, analytics, pixels, identifiers, dan teknologi pelacakan lainnya.

---

# Sistem Analisis

Privacy Guardian tidak boleh menganggap setiap penyebutan suatu kata sebagai bukti bahwa suatu aktivitas benar-benar dilakukan.

Contohnya, jika dokumen menyebut:

> "We do not collect precise location data."

Sistem tidak boleh mengklasifikasikan kalimat tersebut sebagai bukti bahwa lokasi dikumpulkan.

Karena itu, analisis harus mempertimbangkan:

* konteks kalimat;
* negasi;
* subjek;
* objek;
* tujuan penggunaan;
* pengecualian;
* kondisi tertentu;
* hubungan antarbagian dokumen.

Hasil analisis harus berusaha membedakan antara:

**"data dikumpulkan"**

dan

**"data tidak dikumpulkan".**

---

# Indikator Risiko

Privacy Guardian dapat menggunakan indikator untuk membantu pengguna menemukan bagian yang perlu diperhatikan.

Indikator bukan keputusan hukum dan bukan penilaian mutlak terhadap suatu layanan.

Indikator harus memiliki alasan yang jelas.

Contoh kategori:

```text
LOW
Informasi relatif sederhana atau terbatas.

NOTICE
Terdapat informasi yang sebaiknya diperhatikan pengguna.

HIGH ATTENTION
Terdapat kondisi atau praktik yang membutuhkan perhatian lebih lanjut.
```

Indikator tidak boleh diberikan hanya berdasarkan jumlah kata atau keyword.

Setiap indikator harus memiliki dasar dari isi dokumen.

---

# Transparansi Hasil

Setiap hasil analisis idealnya memiliki tiga bagian:

### What

Apa yang ditemukan.

### Why

Mengapa informasi tersebut dianggap relevan.

### Source

Bagian dokumen yang menjadi dasar hasil.

Contoh struktur:

```text
Category:
Data Sharing

Finding:
Dokumen menyebutkan bahwa informasi tertentu dapat dibagikan
kepada penyedia layanan pihak ketiga.

Reason:
Pernyataan tersebut menunjukkan adanya pemrosesan atau
pembagian data dengan pihak eksternal.

Source:
[Bagian dokumen terkait]
```

Dengan pendekatan ini, pengguna tidak dipaksa mempercayai hasil aplikasi secara buta.

---

# Privasi Pengguna

Privasi pengguna merupakan bagian fundamental dari Privacy Guardian.

Aplikasi tidak boleh mengumpulkan informasi pengguna yang tidak diperlukan untuk fungsi utamanya.

Secara prinsip:

* dokumen pengguna tidak boleh dikumpulkan untuk tujuan yang tidak diperlukan;
* telemetry tidak boleh digunakan secara berlebihan;
* log tidak boleh menyimpan isi dokumen sensitif tanpa alasan;
* data sementara harus dikelola dengan benar;
* data yang tidak diperlukan harus tidak disimpan.

---

# Keamanan

Privacy Guardian harus memperlakukan input pengguna sebagai data yang tidak dapat dipercaya.

Aplikasi harus:

* memvalidasi file;
* menangani file yang rusak;
* menangani dokumen berukuran besar;
* mencegah eksekusi isi dokumen;
* mengisolasi proses parsing jika diperlukan;
* menghindari command execution dari input pengguna;
* menghindari path traversal;
* menghindari injection;
* menangani temporary file secara aman;
* membatasi informasi sensitif pada log.

---

# Performa dan Laptop Berspesifikasi Rendah

Salah satu requirement utama Privacy Guardian adalah **dapat digunakan pada laptop Windows lama**.

Aplikasi tidak boleh menganggap bahwa pengguna memiliki:

* RAM besar;
* CPU modern;
* GPU dedicated;
* SSD cepat;
* koneksi internet cepat.

Karena itu:

### CPU

Analisis harus menggunakan CPU secara efisien dan tidak menjalankan proses berat terus-menerus.

### RAM

Dokumen harus diproses dengan penggunaan memory yang wajar.

### GPU

GPU tidak boleh menjadi persyaratan utama.

### Background Process

Aplikasi tidak boleh menjalankan proses background yang tidak diperlukan.

### Startup

Aplikasi harus dapat dibuka tanpa proses startup yang berlebihan.

### Dependency

Dependency harus dijaga seminimal mungkin.

### AI

Model AI lokal berukuran besar tidak boleh menjadi persyaratan dasar aplikasi.

Setiap penggunaan teknologi berat harus mempunyai alasan yang jelas dan harus dibandingkan dengan solusi yang lebih ringan.

---

# Kebutuhan Sistem

Privacy Guardian ditujukan untuk sistem Windows yang mampu menjalankan aplikasi desktop modern dengan resource terbatas.

Target desain:

| Komponen         | Prinsip                                  |
| ---------------- | ---------------------------------------- |
| Operating System | Windows                                  |
| CPU              | x64 dengan dukungan yang sesuai          |
| RAM              | Dioptimalkan untuk penggunaan rendah     |
| GPU              | Tidak diperlukan                         |
| Storage          | Minimal sesuai ukuran aplikasi           |
| Internet         | Tidak menjadi persyaratan analisis dasar |

Spesifikasi minimum dan rekomendasi resmi harus mengikuti versi release yang digunakan.

---

# Instalasi

Privacy Guardian didistribusikan melalui repository resmi project.

Pengguna dianjurkan hanya memperoleh aplikasi dari **sumber resmi Privacy Guardian**.

Alur instalasi:

```text
Repository Resmi
      │
      ▼
Release
      │
      ▼
Download Installer / Package
      │
      ▼
Install
      │
      ▼
Run Privacy Guardian
```

File executable yang berasal dari sumber tidak resmi tidak dijamin keasliannya.

---

# Cara Menggunakan

## 1. Jalankan Privacy Guardian

Buka aplikasi melalui shortcut atau executable resmi.

## 2. Masukkan Dokumen

Pengguna dapat memberikan Privacy Policy atau dokumen kebijakan yang ingin dianalisis menggunakan metode input yang didukung aplikasi.

## 3. Jalankan Analysis

Pilih fungsi analisis.

Privacy Guardian akan memproses dokumen dan mengelompokkan informasi yang ditemukan.

## 4. Periksa Hasil

Hasil ditampilkan berdasarkan kategori.

Pengguna dapat melihat:

* data yang ditemukan;
* penggunaan data;
* pembagian data;
* tracking;
* retensi;
* hak pengguna;
* bagian penting lainnya.

## 5. Periksa Source

Jika tersedia, pengguna dapat membuka bagian dokumen yang menjadi dasar suatu hasil.

## 6. Ambil Keputusan

Privacy Guardian memberikan informasi.

**Keputusan tetap berada di tangan pengguna.**

---

# Input yang Didukung

Privacy Guardian dirancang untuk menangani dokumen atau teks kebijakan yang dapat diproses oleh sistem.

Jenis input dapat mencakup:

* teks langsung;
* dokumen teks;
* dokumen kebijakan yang kompatibel;
* file lokal yang didukung aplikasi.

Format file yang secara resmi didukung harus mengikuti release aplikasi.

Dokumen yang menggunakan format atau struktur yang tidak didukung dapat menghasilkan analisis yang tidak lengkap.

---

# Output Analisis

Hasil Privacy Guardian dirancang agar dapat dipahami dalam beberapa tingkat.

## Overview

Ringkasan informasi utama.

## Categories

Pengelompokan informasi berdasarkan jenis.

## Details

Penjelasan mengenai temuan tertentu.

## Evidence

Bagian dokumen yang mendukung temuan.

## Attention

Bagian yang membutuhkan perhatian lebih lanjut.

Struktur ini memungkinkan pengguna mendapatkan ringkasan tanpa kehilangan kemampuan untuk memeriksa detail.

---

# Batasan Analisis

Privacy Guardian memiliki keterbatasan.

Aplikasi tidak dapat menjamin bahwa semua informasi dalam dokumen selalu terdeteksi dengan benar.

Kesalahan dapat terjadi karena:

* bahasa ambigu;
* struktur dokumen tidak biasa;
* istilah hukum;
* konteks yang kompleks;
* negasi;
* pengecualian;
* dokumen terlalu besar;
* format dokumen yang tidak kompatibel;
* perubahan bahasa atau istilah;
* informasi yang sengaja dibuat tidak eksplisit.

Karena itu, hasil Privacy Guardian harus dianggap sebagai **alat bantu analisis**, bukan sebagai sumber hukum final.

---

# Offline dan Koneksi Internet

Privacy Guardian harus memprioritaskan pemrosesan lokal.

Fungsi dasar analisis tidak boleh bergantung pada koneksi internet apabila fungsi tersebut dapat dilakukan secara lokal.

Jika suatu fitur membutuhkan layanan online, aplikasi harus menjelaskan kepada pengguna bahwa data dapat dikirim keluar dari perangkat sebelum proses tersebut dilakukan.

Tidak boleh ada pengiriman data secara diam-diam.

---

# Data dan Penyimpanan

Privacy Guardian tidak boleh menyimpan dokumen pengguna secara permanen tanpa alasan dan mekanisme yang jelas.

Data sementara harus:

1. dibuat hanya ketika diperlukan;
2. digunakan selama proses berlangsung;
3. dihapus ketika sudah tidak diperlukan.

Jika suatu fitur membutuhkan penyimpanan hasil analisis, pengguna harus dapat mengetahui lokasi dan tujuan penyimpanan tersebut.

---

# Struktur Aplikasi

Struktur aplikasi mengikuti pemisahan tanggung jawab:

```text
Privacy Guardian
│
├── User Interface
│
├── Input Layer
│
├── Document Processing
│
├── Text Processing
│
├── Privacy Analyzer
│
├── Evidence Mapping
│
├── Result Engine
│
├── Report / Presentation
│
└── Security & Configuration
```

Setiap komponen harus memiliki tanggung jawab yang jelas.

---

# Arsitektur

Arsitektur utama mengikuti alur:

```text
┌───────────────────────┐
│        User           │
└──────────┬────────────┘
           │
           ▼
┌───────────────────────┐
│    User Interface     │
└──────────┬────────────┘
           │
           ▼
┌───────────────────────┐
│    Input Processing   │
└──────────┬────────────┘
           │
           ▼
┌───────────────────────┐
│  Document Processing  │
└──────────┬────────────┘
           │
           ▼
┌───────────────────────┐
│   Privacy Analyzer    │
└──────────┬────────────┘
           │
           ├───────────────┐
           ▼               ▼
┌──────────────────┐  ┌──────────────────┐
│ Evidence Mapping │  │ Result Processing│
└────────┬─────────┘  └────────┬─────────┘
         │                     │
         └──────────┬──────────┘
                    ▼
          ┌──────────────────┐
          │   Privacy Report │
          └──────────────────┘
```

UI tidak boleh menjadi tempat utama untuk menjalankan seluruh logic aplikasi.

Core analyzer harus dapat diuji tanpa bergantung sepenuhnya pada interface.

---

# Prinsip Pengembangan

## Simplicity

Jangan menambahkan kompleksitas tanpa kebutuhan.

## Performance

Setiap keputusan teknis harus mempertimbangkan perangkat berspesifikasi rendah.

## Security

Input dari pengguna harus selalu dianggap tidak terpercaya.

## Privacy

Jangan mengumpulkan data yang tidak diperlukan.

## Maintainability

Kode harus dapat dipahami dan dipelihara.

## Testability

Komponen penting harus dapat diuji secara independen.

## Transparency

Hasil analisis harus dapat ditelusuri kembali ke sumbernya.

---

# Pengujian

Privacy Guardian harus diuji melalui beberapa kategori.

## Functional Testing

Memastikan fitur berjalan sesuai tujuan.

## Analysis Testing

Memastikan sistem dapat mendeteksi berbagai pola privacy policy.

## Negative Testing

Menguji dokumen yang:

* kosong;
* rusak;
* tidak lengkap;
* sangat panjang;
* menggunakan struktur tidak biasa.

## Performance Testing

Mengukur:

* RAM;
* CPU;
* startup time;
* processing time;
* storage usage.

## Compatibility Testing

Menguji aplikasi pada perangkat Windows dengan berbagai tingkat spesifikasi.

Prioritas khusus diberikan kepada perangkat lama.

## Security Testing

Menguji:

* file berbahaya;
* malformed input;
* path traversal;
* injection;
* temporary files;
* error handling;
* data leakage.

---

# Keamanan Dependency

Setiap library atau dependency pihak ketiga yang digunakan harus:

* memiliki sumber yang jelas;
* menggunakan versi yang diketahui;
* diperiksa keamanannya;
* tidak ditambahkan hanya karena mempermudah satu fungsi kecil;
* dipertimbangkan dampaknya terhadap ukuran aplikasi;
* dipertimbangkan dampaknya terhadap RAM dan CPU.

Dependency yang tidak lagi diperlukan harus dapat dihapus.

---

# Tim dan Tanggung Jawab

## Choco

**Project Owner**

Memiliki kewenangan akhir terhadap:

* tujuan project;
* scope;
* kebijakan;
* distribusi;
* keputusan final;
* perubahan besar project.

## Formen — `hasby4726`

**Project Supervisor / Mandor**

Formen bertugas mengawasi project dan tim.

Tanggung jawab:

* mengawasi pembagian pekerjaan;
* memastikan jobdesk dijalankan;
* memantau progres;
* memeriksa kepatuhan terhadap requirement;
* mengevaluasi hasil;
* mengidentifikasi masalah;
* mengawasi kualitas pekerjaan;
* membuat laporan project;
* memastikan project tetap berada dalam scope.

Formen bukan pelaksana coding utama.

## Chici 1 — `hasbyprasetya09`

**Development Agent**

Bertanggung jawab atas pekerjaan implementasi yang diberikan sesuai jobdesk.

## Chici 2 — `hasbyprasetya22`

**Development Agent**

Bertanggung jawab atas pekerjaan implementasi yang diberikan sesuai jobdesk.

Setiap anggota harus bekerja sesuai tanggung jawabnya.

---

# Lisensi dan Distribusi

Privacy Guardian Windows **tidak menggunakan lisensi open-source standar**.

Repository ini menggunakan:

**License: None**

Tidak ada pemberian hak open-source melalui MIT, Apache, BSD, GPL, LGPL, MPL, EPL, Unlicense, atau lisensi open-source lainnya.

Hak terhadap source code tetap berada pada pemilik project sesuai hukum yang berlaku.

Distribusi aplikasi dilakukan melalui **sumber resmi project**.

Pengguna dianjurkan tidak memperoleh executable dari pihak ketiga yang tidak resmi.

Ketentuan penggunaan, modifikasi, redistribusi, dan distribusi versi resmi dapat diatur lebih lanjut melalui **proprietary license / software terms** yang diterbitkan oleh pemilik project.

---

# Source Code dan Binary

Privacy Guardian membedakan antara:

### Source Code

Kode sumber yang digunakan untuk membangun aplikasi.

### Official Build

Versi aplikasi yang dibangun dan diterbitkan oleh project.

### Third-Party Distribution

Salinan atau build yang dibuat dan didistribusikan oleh pihak lain.

Pengguna sebaiknya selalu menggunakan **official build** dari repository atau channel resmi Privacy Guardian.

---

# Disclaimer

Privacy Guardian Windows bukan:

* penasihat hukum;
* auditor keamanan;
* regulator;
* pengganti Privacy Policy;
* pengganti Terms of Service;
* jaminan keamanan sebuah layanan;
* jaminan kepatuhan hukum sebuah perusahaan.

Hasil analisis dapat memiliki kesalahan.

Pengguna harus mempertimbangkan dokumen asli dan konteks layanan sebelum membuat keputusan.

---

# Visi Project

Privacy Guardian dibangun berdasarkan gagasan sederhana:

> **Pengguna berhak memahami apa yang terjadi terhadap data mereka.**

Privacy Policy tidak seharusnya menjadi dokumen yang hanya disetujui tanpa dibaca karena terlalu panjang atau terlalu sulit dipahami.

Privacy Guardian berusaha menjadikan informasi tersebut lebih mudah diakses tanpa mengambil alih keputusan pengguna.

Aplikasi memberikan informasi.

Aplikasi memberikan konteks.

Aplikasi menunjukkan sumber.

**Pengguna tetap menentukan keputusan.**

---

# Project Identity

**Project Name:** Privacy Guardian Windows

**Platform:** Windows Desktop

**Category:** Privacy / Security / Document Analysis

**Primary Purpose:** Privacy Policy Analysis

**Design Priority:**

```text
Privacy
   ↓
Security
   ↓
Accuracy
   ↓
Performance
   ↓
Simplicity
   ↓
Usability
```

**Core Principle:**

> **Understand your privacy before you agree to it.**

---

# Repository

Repository resmi:

`privacy_guardian_windows`

Seluruh development, source code, dokumentasi, release, dan informasi resmi project harus merujuk pada repository resmi.

---

# Final Principle

Privacy Guardian Windows tidak dibuat untuk menjadi aplikasi yang paling kompleks.

Aplikasi ini dibuat untuk menjadi **alat yang ringan, transparan, aman, dan mudah digunakan untuk membantu pengguna memahami kebijakan privasi**.

Project harus selalu mempertahankan tiga karakter utama:

**PRIVATE. LIGHTWEIGHT. TRANSPARENT.**
