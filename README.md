# Strona Booking
### Projekt "Strona Booking" jest aplikacją umożliwiającą rezerwację biletów na wybrany przez użytkownika lot. W aplikacji pojawia sie okno menu pozwalające na przegląd polecanych miejsc wraz z zabytkami i ceną oraz obecnej promocji na lot. W aplikacji istnieje również możliwość zarejestrowania nowego użytkownika za pomocą login i hasła jak również zalogowanie sie.
#### Projekt został wykonany w technologii C# Solution składa się z dwóch projektów: • ClassLibrary – biblioteki klas • Program – główny projekt
Program służy do wyświetlania wszystkich wyników funkcji w konsoli.

ClassLibrary składa sie z 7 poszczególnych klas:
* ***Miejsca_podrozy*** - Jest to klasa zawierająca listę miejsc, ich opisów oraz cen.
* ***Promocja_lot*** - Klasa ta zawiera losową promocję na dane miejsce z listy.
* ***Rejestracja*** - Możliwość rejestracji nowego uzytkownika.*
* ***Logowanie*** - Klasa pozwala na zalogowanie się a następnie przenosi nas do formularza rezerwacji lotu.
* ***Formularz*** - W nim znajdują się 3 enum ktore odnoszą sie do Programu w którym użytkownik decyzuje się na rezerwacje.
* ***Wybor_miejsc*** - Użytkownik decyduje które miejsce chce wybrać w samolocie.
* ***Rezerwacja*** - Zwraca potrzebne i przetowrzone wartości potrzebne do zrealizowania usługi.
