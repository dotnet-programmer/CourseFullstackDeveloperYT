using DesignPatterns.ConsoleApp.Facade;
using DesignPatterns.ConsoleApp.Factory;
using DesignPatterns.ConsoleApp.Strategy;

// Wzorce projektowe to typowe, uniwersalne i sprawdzone w praktyce rozwiązanie często pojawiających się powtarzalnych problemów projektowych
// Można je nazwać koncepcją/strukturą/szablonem gotowego rozwiązania, które można dostosować w swoim projekcie aby rozwiązać powtarzajacy się problem w kodzie.

// Można wyróżnić 3 podstawowe kategorie wzorców projektowych:
// Kreacyjne - tworzenie obiektów w elastyczny sposób przez reużywalny kod
// Strukturalne - zdefiniowanie referencji między obiektami tak aby kod był jak najbardziej rozszerzalny
// Behavioralne - zajmują się komunikacją oraz podziałem odpowiedzialności pomiędzy obiektami

// Wzorzec Strategia

// Cel:
// Behawioralny wzorzec projektowy, który definiuje rodzinę wymiennych algorytmów i kapsułkuje je w postaci klas.
// Jednocześnie umożliwia wymienne stosowanie każdego z nich w trakcie działania aplikacji.

// Problem:
// Aplikacja mapy - znajdowanie różnych tras w zależności od środka transportu (samochód/rower/nogi)

// Rozwiązanie:
// bazową klasą będzie klasa Map, której zadaniem będzie utworzenie ścieżki z punktu A do punktu B, gdzie punkty to koordynaty na mapie
// interfejs IRouteStrategy -> CreateRoute(Coordinate, Coordinate)
// class Map -> _routeStrategy : IRouteStrategy; CreateRoute(Coordinate, Coordinate) { tutaj wywołanie metody CreateRoute z obiektu IRouteStrategy }
// dla każdego środka transportu utworzyć osobne klasy, które będą implementować interfejs IRouteStrategy

BikeStrategy bikeStrategy = new();
Map map = new(bikeStrategy);
Coordinate start = new();
Coordinate end = new();
map.CreateRoute(start, end);

// Wzorzec Fabryka

// Cel:
// Kreacyjny wzorzec projektowy, który udostępnia interfejs do tworzenia obiektów w ramach klasy bazowej.
// Jednocześnie pozwala podklasom zmieniać typ tworzonych obiektów

// Problem:
// Aplikacja do tworzenia diagramów np. UML czy FlowChart.
// W tej apce na każdym diagramie można wstawic wiele elementów które są niezależne od konkretnego diagramu.
// Aby nie powielać kodu tworzenia tych kształtów możemy utworzyć fabrykę, która udostępni interfejs do tworzenia obiektów w ramach klasy bazowej.
// Oznacza to, ze kształty muszą mieć wspólną harakterystykę, a w tym przypadku można wydzielić położenie danego kształtu na diagramie i metodę do renderowania dla ich klasy bazowej.
// Mając taką klasę bazową, fabryka w jednej metodzie tworzenia kształtów będzie w stanie zwrócić dowolną implementację kształtu w zależności od potrzeb.
// W ten sposób nie powiela się kodu tworzenia kształtów, a samą fabrykę bęzdie można reużywać w miejscach, gdzie jakiś kształt będzie potrzebny.

ShapeFactory shapeFactory = new();
Shape circle = shapeFactory.CreateShape(ShapeType.Circle);
circle.Render();
Shape triangle = shapeFactory.CreateShape(ShapeType.Triangle);
triangle.Render();

// Wzorzec Fasada

// Cel:
// Strukturalny wzorzec projektowy, którego celem jest stworzenie prostego interfejsu dla zestawu klas.
// Implementuje się jedną klasę, która jest powiązana z innymi klasami złożonego systemu.
// Zadaniem fasady jest wywołać metody powiązanych z nią klas.
// Czyli fasada ułatwia wykonywanie złożonych funkcjonalności korzystając z różnych obiektów i przy tym ukrywa szczegóły implementacji.

// Problem:
// Biblioteka, która skanuje kod źródłowy w repozytorium githuba i generuje raport

ScanFacade scanFacade = new();
scanFacade.Scan("http://github.com/somerepo");