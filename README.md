# Roll a Ball

Topu yönlendirerek sahnedeki elmasları topladığın 3D bir Unity oyunu. Dijital oyun dersi kapsamında Unity'nin klasik Roll a Ball projesi temel alınıp kendi sahnelerim ve arayüzümle genişletildi.

![Unity](https://img.shields.io/badge/Unity%202022.3-000000?logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)

## Özellikler

- Fizik tabanlı top kontrolü (Rigidbody + kuvvet uygulama)
- Elmas toplama ve skor sistemi, son elmas ancak diğerleri toplandıktan sonra alınabilir
- Oyuncuyu takip eden kamera
- Giriş, menü ve çıkış sahneleri arasında geçiş
- Uyarı ve tebrik mesajları, ses efektleri

## Çalıştırma

1. Unity Hub ile **Unity 2022.3** sürümünü kur.
2. Bu depoyu klonla ve Unity Hub'da **Add project from disk** ile klasörü aç.
3. `Assets/Scenes/girisSahnesi.unity` sahnesini açıp Play'e bas.

## Kod yapısı

| Dosya | Görevi |
|---|---|
| `Scripts/oyuncuKontrol.cs` | Top hareketi, elmas toplama, skor |
| `Scripts/kameraKontrol.cs` | Kamera takibi |
| `Scripts/elmasKontrol.cs` | Elmasların dönme animasyonu |
