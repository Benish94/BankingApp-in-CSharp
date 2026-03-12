# 🏧 Bankautomat – C# Console Anwendung (.NET 8)

Dieses Projekt ist eine **Simulation eines Bankautomaten** als **C# Console-Anwendung**.
Es wurde als **Schulungsprojekt** entwickelt, um grundlegende Konzepte der Softwareentwicklung mit **.NET 8** zu demonstrieren.

Der Automat ermöglicht:

* Anmeldung mit **Kontonummer und PIN**
* **automatische Kontoerstellung**, wenn eine Kontonummer noch nicht existiert
* **Kontostand anzeigen**
* **Geld einzahlen**
* **Geld abheben**
* **Zinsen gutschreiben**
* automatische **Münzverteilung über einen Algorithmus**
* **Kontosperre nach 3 falschen PIN-Versuchen**
* Speicherung aller Daten in einer **JSON-Datei**

Zusätzlich besitzt das Programm eine **ASCII-basierte Oberfläche**, die einen echten Geldautomaten simuliert.

---

# 📦 Voraussetzungen

Installiert sein muss:

* **.NET SDK 8**

Installation prüfen:

```bash
dotnet --version
```

Beispielausgabe:

```
8.0.xxx
```

Download falls nötig:

https://dotnet.microsoft.com/download

---

# 🚀 Projekt starten

Im Projektordner ausführen:

```bash
dotnet build
dotnet run
```

Die Anwendung startet anschließend im Terminal.

---

# 🏧 Funktionsübersicht

## Startmenü

Beim Start erscheint das Hauptmenü des Automaten:

```
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

```
Kontonummer (8 Ziffern): 12345678
```

### Konto existiert nicht

Wenn die Kontonummer noch nicht vorhanden ist:

* wird automatisch ein **neues Konto erstellt**
* Benutzer legt **Name und PIN fest**

Beispiel:

```
⚠ Konto nicht gefunden.
Ein neues Konto wird erstellt.

Name eingeben: Max
PIN (4 Stellen): ****

✅ Konto erfolgreich erstellt.
```

---

### Konto existiert

Wenn das Konto existiert, erfolgt die **PIN-Abfrage**:

```
PIN (4 Stellen): ****
```

### Sicherheitsfunktion

Nach **3 falschen PIN-Versuchen** wird das Konto gesperrt:

```
❌ Falsche PIN (3/3)
❌ Konto wurde aus Sicherheitsgründen gesperrt
```

---

# 💳 Kundenmenü

Nach erfolgreichem Login erscheint das Kundenmenü:

```
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

Der Kontostand wird als **Münztabelle** angezeigt:

```
Wert      | Anzahl
-------------------
2.00 €    |      3
1.00 €    |      1
0.50 €    |      1
0.20 €    |      1
0.10 €    |      0
0.05 €    |      0
0.02 €    |      0
0.01 €    |      0
-------------------
Gesamt: 7.70 €
```

---

# 💰 Einzahlung

Der Benutzer gibt einen Betrag ein:

```
💰 Einzahlung
Betrag: 3.76
```

Der Automat:

1. wandelt den Betrag in **Cent** um
2. addiert ihn zum aktuellen Guthaben
3. verteilt das Geld automatisch auf Münzen

Der verwendete Algorithmus entspricht dem **Greedy-Algorithmus** aus dem ursprünglichen Python-Script.

---

# 💸 Auszahlung

Bei einer Auszahlung kann der Benutzer wählen:

```
1 20 €
2 50 €
3 100 €
4 Anderer Betrag
```

Wenn genügend Guthaben vorhanden ist:

```
💸 Geld wird ausgegeben...
████████████████████
Bitte entnehmen Sie Ihr Geld
```

---

# 📈 Zinsen

Der Automat kann **Zinsen auf das Guthaben gutschreiben**.

Der Zinssatz ist aktuell:

```
1 %
```

Die Zinsen werden automatisch auf das Guthaben aufgeschlagen.

---

# 💾 Datenspeicherung

Alle Konten werden automatisch gespeichert in:

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
      "2": 3,
      "1": 1,
      "0.5": 1,
      "0.2": 1
    }
  }
}
```

---

# 🗂 Projektstruktur

```
Bankautomat
│
├── Controllers
│   └── BankController.cs
│
├── Services
│   ├── BankService.cs
│   └── InterestService.cs
│
├── Interfaces
│   ├── IBankService.cs
│   ├── IInterestService.cs
│   └── IStorage.cs
│
├── Storage
│   └── JsonStorage.cs
│
├── Models
│   ├── Account.cs
│   └── CustomerType.cs
│
├── Data
│   └── CoinDefinitions.cs
│
├── UI
│   ├── AsciiATM.cs
│   └── ConsoleMenu.cs
│
├── Utils
│   └── InputValidator.cs
│
└── Program.cs
```

---

# 🧠 Architektur

Das Projekt verwendet eine einfache **Layer-Architektur**:

| Ebene      | Aufgabe                         |
| ---------- | ------------------------------- |
| Program    | Einstiegspunkt                  |
| Controller | Steuerung der Programmlogik     |
| Services   | Geschäftslogik (Bankfunktionen) |
| Interfaces | Verträge zwischen Komponenten   |
| Storage    | Speicherung der Daten           |
| Models     | Datenstrukturen                 |
| UI         | Konsolenoberfläche              |
| Utils      | Eingabevalidierung              |

---

# 🎯 Lernziele

Dieses Projekt demonstriert:

* C# Console Anwendungen
* .NET 8 Projektstruktur
* Verwendung von **Interfaces**
* Trennung von **Business Logic und UI**
* **Controller Pattern**
* JSON-Speicherung mit `System.Text.Json`
* einfache **Banklogik**
* Implementierung eines **Greedy-Algorithmus**

---

# ⚠ Hinweis

Dieses Projekt dient ausschließlich **Lern- und Demonstrationszwecken**.

Es enthält keine echten Sicherheitsmechanismen und ist **kein reales Bankensystem**.

---

# 👨‍💻 Autor

Schulungsprojekt zur Einführung in:

* C#
* .NET Entwicklung
* Softwarearchitektur
* Konsolenanwendungen
