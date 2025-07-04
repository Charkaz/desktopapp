# Desktop App - ASP.NET Web API

Bu proje, basit bir ASP.NET Web API uygulamasıdır ve CI/CD pipeline'ı ile Jenkins ve GitHub Actions entegrasyonu içerir.

## Özellikler

- ✅ ASP.NET Core 8.0 Web API
- ✅ Swagger/OpenAPI dokümantasyonu
- ✅ Docker desteği
- ✅ Jenkins CI/CD pipeline
- ✅ GitHub Actions workflow
- ✅ Unit testler
- ✅ Otomatik deployment

## API Endpoints

### GET /api/hello
Basit bir selamlama mesajı ve timestamp döner.

**Response:**
```json
{
  "message": "Merhaba! Bu basit bir ASP.NET Web API endpoint'idir.",
  "timestamp": "2025-07-04T12:00:00Z"
}
```

## Geliştirme Ortamı

### Ön Gereksinimler
- .NET 8.0 SDK
- Docker Desktop
- Git

### Projeyi Çalıştırma

```bash
# Bağımlılıkları yükle
dotnet restore

# Projeyi çalıştır
dotnet run

# Swagger UI: http://localhost:5000/swagger
# API Endpoint: http://localhost:5000/api/hello
```

### Testleri Çalıştırma

```bash
# Tüm testleri çalıştır
dotnet test

# Test coverage raporu
dotnet test --collect:"XPlat Code Coverage"
```

## Docker

### Docker Image Oluşturma
```bash
docker build -t desktopapp .
```

### Docker Container Çalıştırma
```bash
docker run -d --name desktopapp-container -p 5001:80 desktopapp
```

## Jenkins Kurulumu

### Jenkins'i Docker ile çalıştırma
```bash
docker-compose -f docker-compose.jenkins.yml up -d
```

Jenkins erişim bilgileri:
- URL: http://localhost:8080
- İlk kurulum için admin şifresi Docker loglarından alınabilir:
```bash
docker logs jenkins
```

### Jenkins Pipeline Kurulumu

1. Jenkins'e giriş yapın (http://localhost:8080)
2. "New Item" → "Pipeline" seçin
3. Pipeline tanımını "Pipeline script from SCM" olarak ayarlayın
4. Git repository URL'ini girin
5. Script Path: `Jenkinsfile`
6. GitHub webhook'unu kurun

## GitHub Actions

GitHub Actions workflow'u `.github/workflows/ci-cd.yml` dosyasında tanımlıdır.

### Workflow Adımları:
1. **Build and Test**: Kod derleme ve test çalıştırma
2. **Docker Build**: Docker image oluşturma
3. **Integration Test**: Docker container ile entegrasyon testi
4. **Deploy**: Production ortamına deployment (sadece main branch)

### GitHub Secrets
Aşağıdaki secrets'ları GitHub repository'nize eklemeniz gerekebilir:
- `DOCKER_USERNAME`: Docker Hub kullanıcı adı
- `DOCKER_PASSWORD`: Docker Hub şifresi

## CI/CD Pipeline Akışı

1. **Code Push**: Kod GitHub'a push edilir
2. **Trigger**: GitHub webhook Jenkins'i tetikler
3. **Build**: Kod derlenir ve testler çalıştırılır
4. **Docker**: Docker image oluşturulur
5. **Test**: Integration testler çalıştırılır
6. **Deploy**: Başarılı olursa production'a deploy edilir

## Monitoring ve Logging

- Swagger UI: `/swagger`
- Health Check: `/health` (eklenebilir)
- Logs: Docker container logları

## Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Commit yapın (`git commit -m 'Add amazing feature'`)
4. Branch'i push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

## Lisans

Bu proje MIT lisansı altındadır.
