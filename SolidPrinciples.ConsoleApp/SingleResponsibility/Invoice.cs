// klasa reprezentująca fakture ma 1 odpowiedzialność - przechowywanie danych konkretnej faktury
// wyświetlanie np w konsoli i zapisywanie do pliku jest już inną odpowiedzialnością, należy utworzyć w osobnych klasach

namespace SolidPrinciples.ConsoleApp.SingleResponsibility;

internal class Invoice
{
	public IEnumerable<LineItem> LineItems { get; set; }
	public string Vendor { get; set; }
	public string Vendee { get; set; }
	public decimal Total { get; set; }

	public Invoice(IEnumerable<LineItem> lineItems, string vendor, string vendee)
	{
		LineItems = lineItems;
		Vendor = vendor;
		Vendee = vendee;
		Total = CalculateTotal();
	}

	public decimal CalculateTotal()
	{
		decimal total = 0;
		foreach (var item in LineItems)
		{
			total += item.Price + item.Count * (1 + item.TaxRate);
		}
		return total;
	}

	// złe rozwiązanie, klasa teraz przechowuje dane i zarządza wyświetlaniem ich
	public void Display()
	{
		Console.WriteLine($"Vendor: {Vendor}");
		Console.WriteLine($"Vendee: {Vendee}");
		Console.WriteLine($"Total: {Total}");
	}

	// złe rozwiązanie, klasa teraz przechowuje dane i zapisuje dane do pdf
	public void SaveToPdf() => Console.WriteLine("Saving to PDF...");

	// w takiej postaci klasa Invoice ma 3 odpowiedzialności, przez co są 3 powody do zmiany:
	// 1) przechowywanie/agregacja danych
	// 2) wyświetlenie/logowanie faktury do konsoli
	// 3) zapisanie faktury do PDF

	// Inne typowe odpowiedzialności to np.:
	// odpowiedzialność walidacji
	// odpowiedzialność notyfikacji
	// odpowiedzialność zapisu (do bazy, do pliki, do streamu)
	// odpowiedzialność logiki biznesowej
}