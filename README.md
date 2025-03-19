# 📚 GamifiedLearning - Gamifikowana Aplikacja do Nauki

## 📖 Opis projektu

**GamifiedLearning** to aplikacja webowa stworzona w technologii **ASP.NET Core (MVC)**, która pozwala użytkownikom uczyć się poprzez **grywalizację**. Aplikacja oferuje **lekcje, quizy i system postępów**, motywując użytkowników do nauki poprzez zdobywanie punktów i odznak. Struktura projektu jest modularna, co ułatwia rozwój.

---

## 🎯 Funkcjonalności

- 📚 **Lekcje** – dynamiczny system lekcji podzielonych na moduły.
- ❓ **Quizy** – interaktywne pytania sprawdzające wiedzę użytkownika.
- 🎮 **Gamifikacja** – system punktów, poziomów i odznak.
- 📊 **Śledzenie postępu** – użytkownik może monitorować swoje postępy w lekcjach i quizach.
- 🔐 **Autoryzacja i role** – obsługa użytkowników z rolami **Admin** i **User**.

---

## 🏗 Architektura projektu

Aplikacja składa się z trzech głównych warstw:

1. **GamifiedLearning (MVC)**
   - Obsługa żądań użytkownika (kontrolery, modele, widoki).
   - Warstwa prezentacji (frontend + backend).

2. **GamifiedLearning.BLL (Business Logic Layer)**
   - Logika biznesowa aplikacji.
   - Zarządzanie postępem użytkowników w lekcjach i quizach.

3. **GamifiedLearning.DAL (Data Access Layer)**
   - Warstwa dostępu do danych (Entity Framework Core).
   - Zarządzanie użytkownikami, lekcjami, quizami i postępem.

---

## 🛠 Technologie i narzędzia

- **Backend:** ASP.NET Core MVC 8.0
- **Baza danych:**  
  - **InMemory DB** (domyślnie, dla uproszczonej wersji demo).  
  - Możliwość przełączenia na **SQL Server** poprzez zmianę `ConnectionString` w `appsettings.json` i konfigurację **Entity Framework Core**.
- **Autoryzacja:** ASP.NET Identity (role: Admin, User)
- **Frontend:** Bootstrap 5 (widoki MVC)

---

## 💻 Wymagania systemowe

- .NET SDK 8.0
- Visual Studio 2022 (lub nowsze)

---

## 🚀 Instalacja i uruchomienie

### 1️⃣ Klonowanie repozytorium
  ```bash
  git clone https://github.com/your-repo/gamified-learning.git
  cd gamified-learning
  ```

### 2️⃣ Konfiguracja bazy danych
Domyślnie aplikacja używa InMemory DB.

Aby użyć SQL Server, zmień ConnectionString w appsettings.json i skonfiguruj Entity Framework Core.

### 4️⃣ Uruchomienie aplikacji
  ```bash
  dotnet run --project GamifiedLearning
  ```

Możesz także uruchomić aplikację w Visual Studio:
- Ustaw GamifiedLearning.Web jako projekt startowy.
- Kliknij Run (F5).

---

## 📌 Dodatkowe informacje

- Domyślne konto użytkownika:
  - Login: user@example.com
  - Hasło: User123!
 
- Domyślne konto admina:
  - Login: admin@example.com
  - Hasło: Admin123!
