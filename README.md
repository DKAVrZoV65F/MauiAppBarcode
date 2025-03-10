# MauiAppBarcode

## Описание

Этот проект представляет собой приложение на .NET MAUI, которое позволяет сканировать штрих-коды и QR-коды. Приложение написано на C# 7.0 и использует библиотеки для работы с камерой и распознавания штрих-кодов.

## Основные функции

- **Сканирование штрих-кодов и QR-кодов**: Использование камеры для сканирования и распознавания штрих-кодов и QR-кодов.
- **Интерфейс пользователя**: Удобный и интуитивно понятный интерфейс для взаимодействия с пользователем.
- **Поддержка различных форматов**: Поддержка различных форматов штрих-кодов и QR-кодов.

## Установка и запуск

### Требования

- .NET 7.0 или выше
- Visual Studio 2022 или выше
- Git

### Установка

1. **Клонируйте репозиторий:**

    ```sh
    git clone https://github.com/DKAVrZoV65F/MauiAppBarcode.git
    cd MauiAppBarcode
    ```

2. **Откройте проект в Visual Studio:**

    Откройте решение `MauiAppBarcode.sln` в Visual Studio.

3. **Установите зависимости:**

    Visual Studio автоматически установит все необходимые зависимости.

### Запуск

1. **Запуск приложения:**

    Выберите целевую платформу (Android, iOS, Windows) и нажмите кнопку "Запуск" в Visual Studio.

## Примеры использования

### Пример 1: Сканирование штрих-кода

```csharp
// Пример кода на C# для сканирования штрих-кода
using ZXing.Mobile;

var options = new MobileBarcodeScanningOptions
{
    PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE, BarcodeFormat.EAN_13 }
};

var scanner = new MobileBarcodeScanner();
var result = await scanner.Scan(options);

if (result != null)
{
    Console.WriteLine($"Scanned barcode: {result.Text}");
}
```
