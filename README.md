# 🌍 Traversal - Seyahat Acentası Yönetim Sistemi

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Entity%20Framework-Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" />
  <img src="https://img.shields.io/badge/Google-Gemini%20AI-4285F4?style=for-the-badge&logo=google&logoColor=white" />
  <img src="https://img.shields.io/badge/SignalR-Real--Time-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
</p>

<p align="center">
  <img width="800" height="861" alt="1" src="https://github.com/user-attachments/assets/01bea10a-f8f6-47df-9285-163f7c6d954b" />

</p>

## 📋 Proje Hakkında

**Traversal**, ASP.NET Core MVC ile geliştirilmiş kapsamlı bir **Seyahat Acentası Yönetim Sistemi**dir. Kullanıcılar tur rotalarını inceleyebilir, rezervasyon yapabilir ve AI destekli seyahat asistanından öneriler alabilir.

## ✨ Özellikler

### 🎯 Kullanıcı Paneli
- ✅ Tur rotalarını görüntüleme ve arama
- ✅ Online rezervasyon yapma
- ✅ Aktif/Geçmiş rezervasyon takibi
- ✅ Profil yönetimi
- ✅ Tur yorumları ve puanlama
- ✅ **🤖 AI Seyahat Asistanı (Gemini AI)**

### 👨‍💼 Admin Paneli
- ✅ Dashboard ve istatistikler
- ✅ Destinasyon yönetimi (CRUD)
- ✅ Rezervasyon onay/red işlemleri
- ✅ Kullanıcı yönetimi
- ✅ Rehber yönetimi
- ✅ Yorum moderasyonu
- ✅ Excel ile veri dışa aktarma

### 🌐 Çoklu Dil Desteği
- 🇹🇷 Türkçe
- 🇺🇸 English
- 🇨🇳 中文 (Çince)
- 🇷🇺 Русский (Rusça)
- 🇫🇷 Français (Fransızca)
- 🇪🇸 Español (İspanyolca)

### 🤖 AI Seyahat Asistanı
Google Gemini AI entegrasyonu ile kullanıcılara:
- Kişiselleştirilmiş tur önerileri
- Destinasyon bilgileri
- Seyahat tavsiyeleri
- Anlık soru-cevap desteği

## 🛠️ Teknolojiler

| Katman | Teknoloji |
|--------|-----------|
| **Backend** | ASP.NET Core 8 MVC |
| **ORM** | Entity Framework Core (Code-First) |
| **Veritabanı** | MS SQL Server |
| **Frontend** | HTML5, CSS3, Bootstrap 5 |
| **JavaScript** | jQuery, AJAX |
| **Real-Time** | SignalR |
| **AI** | Google Gemini API |
| **Authentication** | ASP.NET Core Identity |
| **Validation** | FluentValidation |
| **Mapping** | AutoMapper |
| **Pattern** | CQRS, MediatR |
| **Reporting** | EPPlus (Excel) |

## 🏗️ Mimari Yapı
```
📦 TraversalCoreProject
├── 📂 BusinessLayer          # İş mantığı katmanı
│   ├── Abstract              # Interface'ler
│   ├── Concrete              # Manager sınıfları
│   └── ValidationRules       # FluentValidation kuralları
├── 📂 DataAccessLayer        # Veri erişim katmanı
│   ├── Abstract              # Repository interface'leri
│   ├── Concrete              # DbContext
│   └── EntityFramework       # EF Repository implementasyonları
├── 📂 EntityLayer            # Entity sınıfları
├── 📂 DTOLayer               # Data Transfer Objects
├── 📂 SignalRApi             # Real-time API
├── 📂 SignalRApiForSql       # SQL Dependency ile SignalR
└── 📂 TraversalCoreProject   # Ana MVC Projesi
    ├── Areas                 # Admin & Member alanları
    ├── Controllers           # MVC Controller'lar
    ├── ViewComponents        # Yeniden kullanılabilir bileşenler
    ├── Views                 # Razor View'lar
    └── Resources             # Çoklu dil dosyaları
```

## 🚀 Kurulum

### Gereksinimler
- .NET 8 SDK
- SQL Server
- Visual Studio 2022 / Rider

### Adımlar

1. **Repo'yu klonlayın**
```bash
git clone https://github.com/IsmetKerem/TraversalCoreProject.git
```

2. **Veritabanı bağlantısını ayarlayın**
```json
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=TraversalDb;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "GeminiApi": {
    "ApiKey": "YOUR_GEMINI_API_KEY"
  }
}
```

3. **Migration'ları çalıştırın**
```bash
dotnet ef database update
```

4. **Projeyi başlatın**
```bash
dotnet run
```

## 📸 Ekran Görüntüleri

<details>
<summary>🖼️ Görmek için tıklayın</summary>

### Ana Sayfa
<img width="1509" height="861" alt="1" src="https://github.com/user-attachments/assets/01bea10a-f8f6-47df-9285-163f7c6d954b" />


### Kullanıcı Dashboard
<img width="1509" height="861" alt="2" src="https://github.com/user-attachments/assets/f1ff85ed-5bb8-4bbd-8dc8-04a2a088d250" />

### AI Seyahat Asistanı
<img width="1509" height="861" alt="3" src="https://github.com/user-attachments/assets/102622df-f868-46c9-9aa3-e79899043598" />

### Admin Panel
<img width="1509" height="861" alt="4" src="https://github.com/user-attachments/assets/d7dc1e97-5797-4c14-8ff9-db0e9ee92b00" />



</details>

## 🤝 Katkıda Bulunma

1. Fork'layın
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Commit'leyin (`git commit -m 'feat: Add amazing feature'`)
4. Push'layın (`git push origin feature/amazing-feature`)
5. Pull Request açın

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

## 📞 İletişim

**İsmet Kerem**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://linkedin.com/in/SENIN_LINKEDIN)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/IsmetKerem)

---

<p align="center">
  ⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!
</p>
```

---
