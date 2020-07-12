# Strona Booking
### Projekt "Strona Booking" jest aplikacją pozwalająca na rezerwację biletów na lot samolotem. W aplikacji pojawia sie okno menu pozwalające na przegląd polecanych miejsc i obecnej promocji. W aplikacji istnieje również możliwość zarejestrowania nowego użytkownika jak również zalogowanie sie.
#### Projekt został wykonany w technologii C# Solution składa się z dwóch projektów: • ClassLibrary – biblioteki klas • Program – główny projekt
ClassLibrary składa sie z 7 poszczególnych klas:
* ***Miejsca_podrozy*** - Jest to klasa zawierająca listę miejsc, ich opisów oraz cen.
* ***Promocja_lot*** - Klasa ta zawiera losową promocję na dane miejsce z listy.
* ***Rejestracja*** - Możliwość rejestracji nowego uzytkownika.***
* ***Logowanie*** - Klasa pozwala na zalogowanie się a następnie przenosi nas do formularza rezerwacji lotu.
* ***Formularz*** - W nim znajdują się 3 enum ktore odnoszą sie do Programu w którym użytkownik decyzuje się na rezerwacje.
* ***Wybor_miejsc*** - Użytkownik decyduje które miejsce chce wybrać w samolocie.
* ***Rezerwacja*** - Zwraca potrzebne i przetowrzone wartości potrzebne do zrealizowania usługi.
