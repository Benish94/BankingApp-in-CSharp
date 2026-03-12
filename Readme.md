# 🏧 Bankautomat – C# Console Projekt (.NET 8)

Dieses Projekt ist eine **Bankautomaten-Simulation als Console-Anwendung in C#**.
Es wurde als **Schulungsprojekt** entwickelt, um grundlegende Konzepte der Softwareentwicklung mit **.NET 8** zu demonstrieren.

Die Anwendung simuliert typische Funktionen eines Geldautomaten:

* Anmeldung mit **Kontonummer und PIN**
* Anzeige des **Kontostands**
* **Geld abheben** (inkl. Schnellauszahlung)
* **Zinsen gutschreiben**
* **Kontosperre nach 3 falschen PIN-Eingaben**
* Speicherung der Kontodaten in einer **JSON-Datei**

Zusätzlich enthält das Projekt eine **ASCII-Oberfläche**, die das Verhalten eines echten Bankautomaten simuliert.

---

# 📦 Voraussetzungen

Installiert sein muss:

* **.NET SDK 8.x**

Installation prüfen:

```
dotnet --version
```

Beispielausgabe:

```
8.0.xxx
```

Download (falls nicht installiert):

https://dotnet.microsoft.com/download

---

# 🚀 Projekt starten

Im Projektordner ausführen:

```
dotnet build
dotnet run
```

Das Programm startet anschließend im Terminal.

---

# 🏧 Funktionsübersicht

## Startmenü

Beim Start erscheint das Hauptmenü des Bankautomaten:

```
🏧 BANKAUTOMAT

1 Konto verwenden
2 Auszahlung ohne Konto
3 Beenden
```

---

## 💳 Login (Bestandskunden)

Der Login erfolgt mit:

* **Kontonummer (8-stellig)**
* **PIN (4-stellig)**

Beispiel:

```
Kontonummer: 12345678
PIN: ****
```

### Sicherheit

* Nach **3 falschen PIN-Eingaben** wird das Konto **gesperrt**.

```
❌ Falsche PIN (3/3)
❌ Konto wurde aus Sicherheitsgründen gesperrt
```

---

## 💰 Kundenmenü

Nach erfolgreichem Login:

```
💳 Kundenmenü

1 Kontostand anzeigen
2 Geld abheben
3 Zinsen gutschreiben
4 Logout
```

---

## 💸 Geld abheben

Beim Abheben kann zwischen einer **Schnellauszahlung** oder einem eigenen Betrag gewählt werden.

```
💸 Auszahlung wählen

1 20 €
2 50 €
3 100 €
4 Anderer Betrag
```

Während der Auszahlung erscheint eine kleine Animation:

```
💸 Geld wird ausgegeben...
████████████████████
Bitte entnehmen Sie Ihr Geld
```

---

## 📈 Zinsen gutschreiben

Die Bank kann auf das aktuelle Guthaben **Zinsen berechnen und gutschreiben**.

---

## 👤 Auszahlung ohne Konto

Auch Fremdkunden können Geld abheben:

```
Auszahlung ohne Konto
Betrag eingeben:
```

---

# 💾 Datenspeicherung

Alle Konten werden automatisch in einer JSON-Datei gespeichert:

```
accounts.json
```

Beispiel:

```json
{
  "12345678": {
    "name": "Max",
    "pin": "1234",
    "customerType": 0,
    "failedPinAttempts": 0,
    "isLocked": false,
    "accCoins": {
      "2": 4,
      "1": 3
    }
  }
}
```

---

# 🗂 Projektstruktur

```
Bankautomat
│
├─ Controllers
│   └─ BankController.cs
│
├─ Interfaces
│   ├─ IBankService.cs
│   ├─ IInterestService.cs
│   └─ IStorage.cs
│
├─ Models
│   ├─ Account.cs
│   └─ CustomerType.cs
│
├─ Services
│   ├─ BankService.cs
│   └─ InterestService.cs
│
├─ Storage
│   └─ JsonStorage.cs
│
├─ UI
│   ├─ AsciiATM.cs
│   └─ ConsoleMenu.cs
│
├─ Utils
│   └─ InputValidator.cs
│
├─ Data
│   └─ CoinDefinitions.cs
│
└─ Program.cs
```

---

# 🧠 Lernziele des Projekts

Dieses Projekt zeigt folgende Konzepte der Softwareentwicklung:

* **C# Console Anwendungen**
* **.NET 8 Projektstruktur**
* Arbeiten mit **Interfaces**
* Trennung von **Business Logic und UI**
* **Controller Pattern**
* JSON Speicherung mit **System.Text.Json**
* einfache **Banklogik**

---

# ⚠ Hinweis

Dieses Projekt dient ausschließlich **Lern- und Demonstrationszwecken**.

Es enthält **keine echten Sicherheitsmechanismen** und ist **kein echtes Bankensystem**.

---

# 👨‍💻 Autor

Schulungsprojekt zur Einführung in:

* C#
* .NET Architektur
* Softwarestrukturierung
* Konsolenanwendungen
