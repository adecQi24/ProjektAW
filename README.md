# ProjektAW
ProgramowanieIV - Project 2

1. Cel bazy danych:
Celem utworzenia bazy danych KartaPojazdu, było usprawnienie tworzenia ewidencji przebiegu pojazdu. Każda z tabel posiada odpowiednie kolumny, a połączenie ich poprawnie relacjami
umożliwia proste i szybkie tworzenie bazy danych kart pojazdów.

2. Ocena ryzyka:
Ryzyko wprowadzenia niepoprawnych danych zostało ograniczone do minimum, a wręcz zniwelowane całkowicie. Odpowiednie zdefiniowanie typów każdej kolumny zmusza nas do
wpisywania poprawnych danych.

3. Opis bazy danych:
Baza danych składa się z 5 tabel:  
- Tabela Ewidencje -> zawiera date rozpoczęcia oraz zakończenia prowadzenia ewidencji, stan licznika początkowy oraz końcowy pojazdu oraz pojedynczy wpis;
- Tabela Liczba_Kilometrów -> zawiera liczbę przejechanych kilometrów;
- Tabela Osoby_Kierujące -> zawiera dane każdego kierowcy takie jak: imię, nazwisko oraz adres;
- Tabela Pojazdy -> zawiera numer rejestracyjny pojazdu oraz informacje o jego marce oraz rodzaju;
- Tabela Wpisy -> zawiera opis trasy, datę wyjazdu, kolejny numer wpisu, liczbę przejechanych kilometrów, oraz konkretną osobę. 

4. Diagram encji:

![Diagram-Project2](https://github.com/adecQi24/ProjektAW/assets/128797673/6d0407d2-febd-46f8-9b61-218a6f7e91b0)
