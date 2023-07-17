// S - Single Responsibility Principle - zasada pojedynczej odpowiedzialności
// klasa nigdy nie powinna mieć więcej niż 1 powodu do zmiany, lub inaczej mówiąc każda klasa powinna mieć tylko 1 odpowiedzialność

// O - Open-Close Principle - zasada otwarte-zamknięte
// elementy takie jak klasy czy struktury powinny być otwarte na rozszerzenia, ale jednocześnie zamknięte na modyfikacje/zmiany

// L - Liskov Substitution Principle - zasada podstawienia Liskov
// funkcje które używają wskaźników lub referencji do klas bazowych muszą być w stanie uzywać obiektów klas pochodnych nie wiedząc o tym
// czyli klasy pochodne dziedzicząc po klasie bazowej muszą zawsze zachowywać się jako obiekt typu bazowego
// czyli po prostu klasa pochodna może tylko rozszerzać możliwości klasy bazowej bez zmiany zachowania klasy bazowej
// czyli wywołanie metody którą pierwotnie zdefiniowano w klasie bazowej powinno dać odpowiednie rezultaty

// I - Interface Segregation Principle - zasada segregacji interfejsów
// wiele małych interfejsów specyficznych dla klienta jest lepsze niż 1 duży interfejs do ogólnego przeznaczenia - żaden klient nie jest zmuszany do implementacji metod, których nie używa
// interfejsy zapewniają warstwę abstrakcji które upraszczają kod i tworzą barierę uniemożliwiającą sprzężenie z konkretnymi zależnościami

// D - Dependency Inversion Principle - zasada odwracania zależności
// obiekty powinny zależeć od abstrakcji a nie od konkretnych typów
// specyficzna forma luźnego łączenia modułów oprogramowania
// wszystkie zależności ustanowione z wysokopoziomowych modułów ustalające politykę dla niskopoziomowych modułów są odwrócone
// to powoduje że moduły wysokiego poziomu są niezależne od szczegółów implementacji modułu nieskiego poziomu
// czyli moduły wysokiego poziomu nie powinny zależeć od modułów niskiego poziomu, oba powinny zależeć od abstrakcji, np interfejsu
// abstrakcje nie powinny zależeć od szczegółów
// szczegóły, czyli jakieś konkretne implementacje powinny również zależeć od abstrakcji
// ta zasada odwraca sposób w jakim można myśleć o programowaniu obiektowym
// ideą tej zasady jest to że podczas projektowania interakcji między modułem wysokiego poziomu a modułem niskiego poziomu, interakcję należy traktować jako abstrakcyjną interakcję między nimi

Console.WriteLine();