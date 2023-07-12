using CsvHelper;
using LinqTraining.ConsoleApp;
using System.Globalization;
using Type = LinqTraining.ConsoleApp.Type;

internal class Program
{
	private static void Main(string[] args)
	{
		string csvPath = @"data/googleplaystore1.csv";
		var googleApps = LoadGoogleAps(csvPath);

		// wyświetlanie danych
		// Display(googleApps);

		// pobieranie danych
		// GetData(googleApps);

		// projekcja danych
		// ProjectData(googleApps);

		// dzielenie danych
		// DivideData(googleApps);

		// sortowanie danych
		// OrderData(googleApps);

		// operacje na zbiorach
		// DataSetOperation(googleApps);

		// weryfikacja danych
		DataVerification(googleApps);
	}

	private static void GetData(IEnumerable<GoogleApp> googleApps)
	{
		//bool IsHighRatedApp(GoogleApp app) => app.Rating > 4.6;
		//var highRatedAppd = googleApps.Where(IsHighRatedApp);

		//var highRatedAppd = googleApps.Where((GoogleApp app) => app.Rating > 4.6);

		var highRatedApps = googleApps.Where(a => a.Rating > 4.6);
		Console.WriteLine("highRatedApps");
		Display(highRatedApps);

		Console.WriteLine();

		var highRatedBeautyApps = googleApps.Where(a => a.Rating > 4.6 && a.Category == Category.BEAUTY);
		Console.WriteLine("highRatedBeautyApps");
		Display(highRatedBeautyApps);

		Console.WriteLine();

		var firstHighRatedBeautyApps = highRatedBeautyApps.First();
		Console.WriteLine("firstHighRatedBeautyApps");
		Display(firstHighRatedBeautyApps);

		Console.WriteLine();

		var firstHighRatedBeautyAppsFirst = highRatedBeautyApps.First(a => a.Reviews < 300);
		Console.WriteLine("firstHighRatedBeautyAppsFirst");
		Display(firstHighRatedBeautyAppsFirst);

		Console.WriteLine();

		var firstHighRatedBeautyAppsSingle = highRatedBeautyApps.Single(a => a.Reviews < 300);
		Console.WriteLine("firstHighRatedBeautyAppsSingle");
		Display(firstHighRatedBeautyAppsSingle);

		Console.WriteLine();

		var firstHighRatedBeautyAppsLast = highRatedBeautyApps.Last(a => a.Reviews < 300);
		Console.WriteLine("firstHighRatedBeautyAppsLast");
		Display(firstHighRatedBeautyAppsLast);
	}

	private static void ProjectData(IEnumerable<GoogleApp> googleApps)
	{
		var highRatedBeautyApps = googleApps.Where(a => a.Rating > 4.6 && a.Category == Category.BEAUTY);
		var highRatedBeautyAppsNames = highRatedBeautyApps.Select(a => a.Name);
		Console.WriteLine("highRatedBeautyAppsNames");
		Console.WriteLine(string.Join(", ", highRatedBeautyAppsNames));

		// Select przekształca (mapuje) jedną kolekcję na drugą kolekcję
		var dtos = highRatedBeautyApps.Select(a => new GoogleAppDto() { Reviews = a.Reviews, Name = a.Name });
		foreach (var item in dtos)
		{
			Console.WriteLine($"{item.Name}: {item.Reviews}");
		}

		var genres = highRatedBeautyApps.SelectMany(a => a.Genres);
		Console.WriteLine(string.Join(":", genres));

		var annonymousDtos = highRatedBeautyApps.Select(a => new { Reviews = a.Reviews, Name = a.Name, Category = a.Category });
		foreach (var item in annonymousDtos)
		{
			Console.WriteLine($"{item.Name}: {item.Reviews}");
		}
	}

	private static void DivideData(IEnumerable<GoogleApp> googleApps)
	{
		var highRatedBeautyApps = googleApps.Where(a => a.Rating > 4.6 && a.Category == Category.BEAUTY);

		Console.WriteLine("Take");

		var first5HighRatedBeautyApps = highRatedBeautyApps.Take(5);
		Display(first5HighRatedBeautyApps);
		first5HighRatedBeautyApps = highRatedBeautyApps.TakeLast(5);
		Display(first5HighRatedBeautyApps);
		first5HighRatedBeautyApps = highRatedBeautyApps.TakeWhile(a => a.Reviews > 1000);
		Display(first5HighRatedBeautyApps);

		Console.WriteLine("Skip");

		var skippedResults = highRatedBeautyApps.Skip(5);
		Display(skippedResults);
	}

	private static void OrderData(IEnumerable<GoogleApp> googleApps)
	{
		var highRatedBeautyApps = googleApps.Where(a => a.Rating > 4.4 && a.Category == Category.BEAUTY);
		Display(highRatedBeautyApps);

		Console.WriteLine();
		Console.WriteLine("Sorted result");
		var sortedResults = highRatedBeautyApps.OrderByDescending(a => a.Rating).ThenBy(a => a.Name).Take(5);
		Display(sortedResults);
	}

	private static void DataSetOperation(IEnumerable<GoogleApp> googleApps)
	{
		var paidAppsCategories = googleApps.Where(a => a.Type == Type.Paid).Select(a => a.Category).Distinct();
		Console.WriteLine($"Paid apps categories: {string.Join(", ", paidAppsCategories)}");

		// Union - wszystkie elementy ze zbioru A i ze zbioru B, jeżeli elementy pokrywaja się to nie będą powielone
		// Intersect - część wspólna 2 zbiorów, czyli elementy pokrywające się
		// Except - część zbioru A, która nie pokrywa się ze zbiorem B (zbiór A - powtarzające się z B)

		var setA = googleApps.Where(a => a.Rating > 4.7 && a.Type == Type.Paid && a.Reviews > 1000);
		var setB = googleApps.Where(a => a.Name.Contains("Pro") && a.Rating > 4.6 && a.Reviews > 10000);

		Console.WriteLine();
		Console.WriteLine("Set A:");
		Display(setA);
		Console.WriteLine();
		Console.WriteLine("Set B:");
		Display(setB);

		var appsUnion = setA.Union(setB);
		Console.WriteLine();
		Console.WriteLine("appsUnion");
		Display(appsUnion);

		var appsIntersect = setA.Intersect(setB);
		Console.WriteLine();
		Console.WriteLine("appsIntersect");
		Display(appsIntersect);

		var appsExcept = setA.Except(setB);
		Console.WriteLine();
		Console.WriteLine("appsExcept");
		Display(appsExcept);
	}

	private static void DataVerification(IEnumerable<GoogleApp> googleApps)
	{
		var allOperatorResult = googleApps.Where(a => a.Category == Category.WEATHER).All(a => a.Reviews > 20);
		Console.WriteLine($"allOperatorResult = {allOperatorResult}");

		var anyOperatorResult = googleApps.Where(a => a.Category == Category.WEATHER).Any(a => a.Reviews > 2_000_000);
		Console.WriteLine($"anyOperatorResult = {anyOperatorResult}");
	}

	private static List<GoogleApp> LoadGoogleAps(string csvPath)
	{
		using (var reader = new StreamReader(csvPath))
		using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
		{
			csv.Context.RegisterClassMap<GoogleAppMap>();
			var records = csv.GetRecords<GoogleApp>().ToList();
			return records;
		}
	}

	private static void Display(IEnumerable<GoogleApp> googleApps)
	{
		foreach (var googleApp in googleApps)
		{
			Console.WriteLine(googleApp);
		}
	}

	private static void Display(GoogleApp googleApp) => Console.WriteLine(googleApp);
}