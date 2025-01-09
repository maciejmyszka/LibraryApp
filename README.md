# LibraryApp

LibraryApp to system zarz¹dzania bibliotek¹ stworzony w technologii **ASP.NET Core**, umo¿liwiaj¹cy zarz¹dzanie ksi¹¿kami, autorami i wypo¿yczeniami.

---

## Wymagania

- **.NET 6 SDK** lub nowszy
- **Entity Framework Core**
- **Microsoft SQL Server** (lub inna kompatybilna baza danych)
- **Visual Studio 2022** (opcjonalnie)
- Przegl¹darka internetowa

---

## Instalacja

1. **Sklonuj repozytorium**:
   ```bash
   git clone https://github.com/maciejmyszka/LibraryApp.git
   cd LibraryApp
   ```

2. **Przygotuj bazê danych i ustaw ³añcuch po³¹czenia w pliku appsettings.json**:
 
   ```bash
   {
        "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=LibraryApp;Trusted_Connection=True;"
   }
   ```
   
3. **Wykonaj migracje bazy danych**

    ```bash
   dotnet ef database update
   ```

4. **Uruchom aplikacjê**

    ```bash
   dotnet run
   ```

  
---

## U¿ytkownicy

| Email             | Password                                                                |
| ----------------- | ------------------------------------------------------------------ |
| admin@admin.com |  Admin123! |
| employee@employee.com |  Employee123! |


---

## Funkcjonalnoœæ

### Ksi¹¿ki
- **Wyœwietlanie listy ksi¹¿ek**: Strona g³ówna pokazuje wszystkie ksi¹¿ki wraz z autorami i dostêpnoœci¹.
- **Szczegó³y ksi¹¿ki**: Szczegó³owe informacje o ksi¹¿ce i jej autorze.
- **Dodawanie/edycja/usuwanie ksi¹¿ek** (tylko dla administratorów i pracowników).
- **Podczas wypo¿yczenia ksi¹¿ki zmienia siê jej status** przez co nie mo¿e zostaæ wypo¿yczona, gdy jej nie ma. Przy zwrocie wypo¿yczenia automatycznie ksi¹¿ka staje siê dostêpna.
- **Usuwanie ksi¹¿ki mo¿liwe jest tylko, gdy ksi¹¿ka jest dostêpna**

### Autorzy
- **Wyœwietlanie listy autorów**: Lista wszystkich autorów w systemie (tylko dla zalogowanych u¿ytkowników).
- **Dodawanie/edycja/usuwanie autorów** (tylko dla administratorów i pracowników).

### Wypo¿yczenia
- **Zarz¹dzanie wypo¿yczeniami**: Mo¿liwoœæ wypo¿yczenia ksi¹¿ek realizowane przez pracownika lub administratora.
- **Historia wypo¿yczeñ u¿ytkownika**: U¿ytkownik mo¿e przegl¹daæ swoje wypo¿yczenia.
- **Administrator oraz pracownika mog¹ przegl¹daæ wszystkie wypo¿yczenia**

### Zarz¹dzanie u¿ytkownikami
- **Wyœwietlanie listy u¿ytkowników**: Pracownicy i administratorzy mog¹ przegl¹daæ listê wszystkich u¿ytkowników w systemie.
- **Szczegó³y u¿ytkownika**: Wyœwietlanie szczegó³owych informacji o u¿ytkowniku, w tym jego roli w systemie.
- **Dodawanie u¿ytkownika**: Administratorzy mog¹ dodawaæ nowych u¿ytkowników.
- **Edycja u¿ytkownika**: Administratorzy mog¹ edytowaæ dane u¿ytkowników, w tym zmieniaæ ich role w systemie.
- **Usuwanie u¿ytkownika**: Administratorzy mog¹ usuwaæ u¿ytkowników z systemu.
- **Standardowe rejestrowanie u¿ytkowników domyœlnie z rol¹ User**