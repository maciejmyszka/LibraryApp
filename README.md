# LibraryApp

LibraryApp to system zarz�dzania bibliotek� stworzony w technologii **ASP.NET Core**, umo�liwiaj�cy zarz�dzanie ksi��kami, autorami i wypo�yczeniami.

---

## Wymagania

- **.NET 6 SDK** lub nowszy
- **Entity Framework Core**
- **Microsoft SQL Server** (lub inna kompatybilna baza danych)
- **Visual Studio 2022** (opcjonalnie)
- Przegl�darka internetowa

---

## Instalacja

1. **Sklonuj repozytorium**:
   ```bash
   git clone https://github.com/maciejmyszka/LibraryApp.git
   cd LibraryApp
   ```

2. **Przygotuj baz� danych i ustaw �a�cuch po��czenia w pliku appsettings.json**:
 
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

4. **Uruchom aplikacj�**

    ```bash
   dotnet run
   ```

  
---

## U�ytkownicy

| Email             | Password                                                                |
| ----------------- | ------------------------------------------------------------------ |
| admin@admin.com |  Admin123! |
| employee@employee.com |  Employee123! |


---

## Funkcjonalno��

### Ksi��ki
- **Wy�wietlanie listy ksi��ek**: Strona g��wna pokazuje wszystkie ksi��ki wraz z autorami i dost�pno�ci�.
- **Szczeg�y ksi��ki**: Szczeg�owe informacje o ksi��ce i jej autorze.
- **Dodawanie/edycja/usuwanie ksi��ek** (tylko dla administrator�w i pracownik�w).
- **Podczas wypo�yczenia ksi��ki zmienia si� jej status** przez co nie mo�e zosta� wypo�yczona, gdy jej nie ma. Przy zwrocie wypo�yczenia automatycznie ksi��ka staje si� dost�pna.
- **Usuwanie ksi��ki mo�liwe jest tylko, gdy ksi��ka jest dost�pna**

### Autorzy
- **Wy�wietlanie listy autor�w**: Lista wszystkich autor�w w systemie (tylko dla zalogowanych u�ytkownik�w).
- **Dodawanie/edycja/usuwanie autor�w** (tylko dla administrator�w i pracownik�w).

### Wypo�yczenia
- **Zarz�dzanie wypo�yczeniami**: Mo�liwo�� wypo�yczenia ksi��ek realizowane przez pracownika lub administratora.
- **Historia wypo�ycze� u�ytkownika**: U�ytkownik mo�e przegl�da� swoje wypo�yczenia.
- **Administrator oraz pracownika mog� przegl�da� wszystkie wypo�yczenia**

### Zarz�dzanie u�ytkownikami
- **Wy�wietlanie listy u�ytkownik�w**: Pracownicy i administratorzy mog� przegl�da� list� wszystkich u�ytkownik�w w systemie.
- **Szczeg�y u�ytkownika**: Wy�wietlanie szczeg�owych informacji o u�ytkowniku, w tym jego roli w systemie.
- **Dodawanie u�ytkownika**: Administratorzy mog� dodawa� nowych u�ytkownik�w.
- **Edycja u�ytkownika**: Administratorzy mog� edytowa� dane u�ytkownik�w, w tym zmienia� ich role w systemie.
- **Usuwanie u�ytkownika**: Administratorzy mog� usuwa� u�ytkownik�w z systemu.
- **Standardowe rejestrowanie u�ytkownik�w domy�lnie z rol� User**