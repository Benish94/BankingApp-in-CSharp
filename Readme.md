# 🏧 Bankautomat – C# Console Anwendung (.NET 8)

Dieses Projekt ist eine **Simulation eines Bankautomaten** als **C# Console-Anwendung**.
Es wurde als **Schulungs- und Lernprojekt** erstellt, um grundlegende Konzepte der Softwareentwicklung mit **.NET 8**, **C#**, **Unit Tests** und **Softwarearchitektur** zu demonstrieren.

Der Automat unterstützt:

* Kontoanmeldung über **Kontonummer + PIN**
* **automatische Kontoerstellung**, wenn eine Kontonummer noch nicht existiert
* **Kontostand anzeigen**
* **Geld einzahlen**
* **Geld abheben**
* **Zinsen gutschreiben**
* automatische **Münz- und Scheinverteilung über einen Greedy-Algorithmus**
* Speicherung aller Konten in einer **JSON-Datei**
* **automatisierte Tests mit xUnit**

Die Anwendung läuft vollständig über die **Console**.

---

# 📦 Voraussetzungen

Installiert sein muss:

* **.NET SDK 8**

Installation prüfen:

```bash
dotnet --version
```

Beispiel:

```text
8.0.418
```

Download:

https://dotnet.microsoft.com/download/dotnet/8.0

---

# 📁 Projektstruktur

```text
Bankautomat
│
├── Bankautomat.sln
├── global.json
│
├── Bankautomat
│   ├── CoinMachine.csproj
│   ├── Program.cs
│   │
│   ├── Controllers
│   │   └── BankController.cs
│   │
│   ├── Services
│   │   ├── BankService.cs
│   │   └── InterestService.cs
│   │
│   ├── Interfaces
│   │   ├── IBankService.cs
│   │   ├── IInterestService.cs
│   │   └── IStorage.cs
│   │
│   ├── Storage
│   │   └── JsonStorage.cs
│   │
│   ├── Models
│   │   ├── Account.cs
│   │   └── CustomerType.cs
│   │
│   ├── Data
│   │   └── CoinDefinitions.cs
│   │
│   ├── UI
│   │   ├── AsciiATM.cs
│   │   └── ConsoleMenu.cs
│   │
│   └── Utils
│       └── InputValidator.cs
│
└── Bankautomat.Tests
    ├── Bankautomat.Tests.csproj
    └── BankServiceTests.cs
```

---

# 🚀 Programm starten

In den **Root-Ordner des Projekts wechseln**:

```bash
cd Bankautomat
```

Projekt bauen:

```bash
dotnet build
```

Programm starten:

```bash
dotnet run --project Bankautomat
```

Der Bankautomat startet anschließend im Terminal.

---

# 🏧 Nutzung des Bankautomaten

## Startmenü

Beim Start erscheint das Hauptmenü:

```text
┌──────────────────────────────┐
│ 🏧 BANKAUTOMAT               │
│                              │
│ 1 Konto verwenden            │
│ 2 Auszahlung ohne Konto      │
│ 3 Beenden                    │
└──────────────────────────────┘
```

---

# 💳 Konto verwenden

Der Benutzer gibt eine **8-stellige Kontonummer** ein.

```text
Kontonummer (8 Ziffern): 12345678
```

## Konto existiert nicht

Falls das Konto noch nicht existiert:

* neues Konto wird erstellt
* Name wird abgefragt
* eine **4-stellige PIN** wird festgelegt

```text
⚠ Konto nicht gefunden.
Ein neues Konto wird erstellt.

Name eingeben: Max
PIN (4 Stellen): ****

✅ Konto erfolgreich erstellt
```

---

## Login

Bei bestehenden Konten erfolgt die **PIN-Abfrage**.

```text
PIN (4 Stellen): ****
```

Nach **3 falschen PIN-Eingaben** wird das Konto gesperrt.

---

# 💳 Kundenmenü

Nach erfolgreichem Login:

```text
┌──────────────────────────────┐
│ 💳 Kundenmenü                │
│                              │
│ 1 Kontostand anzeigen        │
│ 2 Einzahlung                 │
│ 3 Auszahlung                 │
│ 4 Zinsen                     │
│ 5 Logout                     │
└──────────────────────────────┘
```

---

# 💰 Kontostand

Der Kontostand wird als **Münz- und Scheinübersicht** angezeigt.

Beispiel:

```text
Wert      | Anzahl
-------------------
100 €     | 1
50 €      | 1
20 €      | 1
10 €      | 1
5 €       | 1
2 €       | 1
1 €       | 0
0.50 €    | 1
0.20 €    | 1
0.05 €    | 1
0.01 €    | 1
-------------------
Gesamt: 187.76 €
```

---

# 💰 Einzahlung

Bei einer Einzahlung wird ein Betrag eingegeben:

```text
💰 Einzahlung
Betrag: 25.50
```

Der Automat:

1. wandelt den Betrag in **Cent**
2. addiert ihn zum Kontostand
3. verteilt das Geld automatisch auf Münzen und Scheine

---

# 💸 Auszahlung

Bei einer Auszahlung kann ein Betrag gewählt werden:

```text
┌──────────────────────────────┐
│ 💸 Auszahlung wählen         │
│                              │
│ 1 5 €                        │
│ 2 10 €                       │
│ 3 20 €                       │
│ 4 50 €                       │
│ 5 100 €                      │
│ 6 Anderer Betrag             │
└──────────────────────────────┘
```

Wenn genügend Guthaben vorhanden ist, wird das Geld ausgegeben.

---

# 📈 Zinsen

Der Automat kann **Zinsen auf das Guthaben berechnen**.

Aktueller Zinssatz:

```text
1 %
```

Die Zinsen werden zum Kontostand addiert.

---

# 💾 Datenspeicherung

Alle Konten werden automatisch gespeichert in:

```text
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
      "100": 1,
      "50": 1,
      "20": 1,
      "10": 1,
      "5": 1,
      "2": 1
    }
  }
}
```

---

# 🧪 Tests ausführen (xUnit)

Dieses Projekt enthält **automatisierte Tests** im Ordner:

```text
Bankautomat.Tests
```

Die Tests prüfen u.a.:

* Einzahlung
* Auszahlung
* Kontostandberechnung
* Münzverteilung (Greedy-Algorithmus)
* Zinsberechnung
* Kontoerstellung

---

## Tests starten

Im Root-Ordner ausführen:

```bash
dotnet test
```

---

## Erwartete Ausgabe

```text
Starting test execution...

Passed! 6 tests passed
```

---

# 🧠 Architektur

Das Projekt folgt einer einfachen **Layer-Architektur**.

| Layer      | Aufgabe                       |
| ---------- | ----------------------------- |
| Program    | Einstiegspunkt                |
| Controller | Steuerung der Programmlogik   |
| Services   | Geschäftslogik                |
| Interfaces | Verträge zwischen Komponenten |
| Storage    | Datenpersistenz               |
| Models     | Datenmodelle                  |
| UI         | Console Oberfläche            |
| Utils      | Eingabevalidierung            |
| Tests      | automatisierte Tests          |

---

# 🎯 Lernziele des Projekts

Dieses Projekt demonstriert:

* C# Console Anwendungen
* .NET 8 Projektstruktur
* Verwendung von **Interfaces**
* Trennung von **Business Logic und UI**
* **Controller Pattern**
* JSON-Datenpersistenz
* **Greedy Algorithmus** für Münzverteilung
* **Unit Testing mit xUnit**

---

# ⚠ Hinweis

Dieses Projekt ist ein **Lernprojekt** und kein echtes Bankensystem.

Es enthält keine echten Sicherheitsmechanismen und dient ausschließlich Demonstrationszwecken.

---

# 👨‍💻 Autor

Schulungsprojekt zur Einführung in:

* C#
* .NET Entwicklung
* Softwarearchitektur
* Unit Testing
* Konsolen
