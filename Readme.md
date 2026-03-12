# Münzautomaten / Bank Console Anwendung (.NET 8)

Dieses Projekt ist eine einfache Bank-Simulation als **Console-Anwendung in C# (.NET 8)**.
Es wurde als **Schulungsprojekt** entwickelt, um grundlegende Konzepte von C# und Softwarearchitektur zu demonstrieren.

Die Anwendung ermöglicht es Benutzern:

* sich mit einer **Kontonummer anzumelden**
* zwischen **Bestandskunden und Fremdkunden** zu unterscheiden
* **Kontostände einzusehen**
* **Geld abzuheben**
* **Zinsen auf Kontostände zu berechnen**
* Accounts persistent in einer **JSON-Datei** zu speichern

---

# Voraussetzungen

Installiert sein muss:

* **.NET SDK 8.0.418**

Prüfen mit:

```bash
dotnet --version
```

Falls nicht installiert:
https://dotnet.microsoft.com/download

---

# Projekt starten

Im Projektordner ausführen:

```bash
dotnet run
```

Die Anwendung startet anschließend im Terminal / der Konsole.

---

# Anmeldung

Beim Start fordert das Programm zur Eingabe einer **8-stelligen Kontonummer** auf.

Beispiel:

```
Kontonummer (8 Ziffern):
12345678
```

Das System unterscheidet zwei Kundentypen.

---

# Kundentypen

## Bestandskunde

Ein Bestandskunde besitzt bereits ein Konto im System.

Mögliche Funktionen:

```
1 Kontostand anzeigen
2 Auszahlung
3 Zinsen gutschreiben
4 Logout
```

### Kontostand anzeigen

Zeigt den aktuellen Kontostand des Kontos.

### Auszahlung

Ein Betrag wird vom Konto abgehoben.

### Zinsen gutschreiben

Die Bank kann Zinsen auf den aktuellen Kontostand berechnen.

---

## Fremdkunde

Wenn eine eingegebene Kontonummer **nicht existiert**, wird der Benutzer als Fremdkunde behandelt.

Fremdkunden können:

* **nur Geld abheben**

Sie haben **keinen Zugriff auf Kontostände oder Zinsfunktionen**.

---

# Speicherung der Konten

Alle Kontodaten werden in der Datei gespeichert:

```
accounts.json
```

Diese Datei wird automatisch erstellt, sobald ein Konto gespeichert wird.

Beispielstruktur:

```json
{
  "12345678": {
    "Name": "Max",
    "CustomerType": 0,
    "AccCoins": {
      "2": 3,
      "1": 1,
      "0.5": 0
    }
  }
}
```

---

# Projektstruktur

```
CoinMachine
│
├─ Program.cs
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
└─ Data
    └─ CoinDefinitions.cs
```

### Beschreibung

| Ordner     | Inhalt                             |
| ---------- | ---------------------------------- |
| Models     | Datenmodelle der Anwendung         |
| Services   | Geschäftslogik der Bank            |
| Storage    | Laden und Speichern der JSON Daten |
| Data       | Definition der Münzwerte           |
| Program.cs | Einstiegspunkt und Konsolenmenü    |

---

# Lernziele des Projekts

Dieses Projekt demonstriert folgende Konzepte:

* C# Grundlagen
* Arbeiten mit **.NET 8**
* **Console Anwendungen**
* **Dateispeicherung mit JSON**
* einfache **Softwarearchitektur**
* Trennung von **Models, Services und Storage**
* einfache **Banklogik**

---

# Hinweise

Dieses Projekt ist **kein echtes Bankensystem** und dient ausschließlich zu Lernzwecken.

Es enthält keine:

* Sicherheitsmechanismen
* Verschlüsselung
* Authentifizierung
* Datenbankanbindung

---

# Autor

Schulungsprojekt für C# / .NET Entwicklung.
