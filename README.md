# Magazyn
Projekt Magazyn powstaje jako materiał zaliczeniowy przedmiotu Programowanie Desktopowych Aplikacji Biznesowych.
Na ten moment obejmuje on możliwość dodania towaru, faktury oraz kontrahenta wraz z wszystkimi niezbędnymi składnikami.
Baza danych zawiera większą liczbę tabel (27) niż obecnie używaną (14) z powodu konieczności rozwoju projektu w kierunku firmy spawalniczej 
co wymusi utworzenie dodatkowych zakładek.

## Użyte technologie
W trakcie pisania projektu korzystam z następujących technologi oraz wzorców:
<ul>
  <li>T-SQL</li>
  <li>C#</li>
  <li>XAML</li>
  <li>Entity framework</li>
  <li>MVVMLight</li>
  <li>LINQ</li>
  <li>Wzorzec MVVM</li>
</ul>

## Użycie aplikacji
Po skompilowaniu projektu mamy do wyboru kilka zakładek po lewej stronie, pasek (toggle bar) znajdujący sie ponad przestrzenią roboczą oraz menu.
Z dowolnego z tych miejsc wybieramy jeden interesujący nas element np."Towary", w którym możemy zobaczyć wszystkie dodane do bazy danych towary oraz za pomocą przycisków znajdujących się w lewym górnym rogu
dodać nowy towar lub odświeżyć listę towarów co jest niezbędne do wczytania nowej zawartości tabeli po dodaniu nowego elementu.

Należy pamiętać, że do zapisania nowego elementu niezbędne jest wypełnienie niemal wszystkich jego pól. Przy czym wypełnienie pól, pod które są podpięte klucze obce tabeli, w której się obecnie znajdujemy 
jest możliwe jedynie przez użycie combo box-ów/przycisków, pod które s podpięte komendy wywołujące funkcje otwierające zakładki, które pokazują zawartość interesujących nas tabeli z bazy danych.
Warto dodać, iż samo zamknięcie zakładki nie spowoduje zapisania nowego rekordu do bazy danych. Do tego celu konieczne jest kliknięcie przycisku (ToggleButton)-zapisz przedstawionego jako ikona dyskietki w 
lewym górnym rogu przestrzeni roboczej.

Do bazy danych dodałem po jednym rekordzie w każdej z potrzebnych tabeli, jeżeli jednak zajdzie potrzeba stworzenia nowych w celu sprawdzenia funkcji aplikacji zawsze można to zrobić poprzez przycisk + 
znajdujący sie po prawej stronie zakładki wyświetlającej wszystkie rekordy w danej tabeli.

W najbliższym czasie do aplikacji zostanie dodana możliwość sortowania i filtrowania rekordów zapisanych w bazie. Zmiany będę dodawał na bieżąco.

# Kontakt
Wisniewskibe@gmail.com
+48 790 335 743

## Wygląd aplikacji
Przykładowy widok jednej z zakładek aplikacji.

<img src="https://github.com/TadeuszWisniewski/Prezentacja/assets/143537984/7e877ece-86bd-4a16-a03a-8d25debe413f" width="50%" height="50%"></imp>


