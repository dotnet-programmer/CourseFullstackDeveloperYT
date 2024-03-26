using SolidPrinciples.ConsoleApp.SingleResponsibility;

namespace SolidPrinciples.ConsoleApp.OpenClose;

// klasa InvoicePersistance ma tylko 1 odpowiedzialność - zapis danych do pliku

// rozszerzenie klasy o dodatkowy format zapisu, np do pliku word

internal class InvoicePersistance(Invoice invoice, IInvoiceSaver invoiceSaver)
{
	private readonly Invoice _invoice = invoice;

	// abstrakcja reprezentująca sposób zapisu faktury
	private readonly IInvoiceSaver _invoiceSaver = invoiceSaver;

	// dodawanie kolejnych metod dla innego sposobu zapisu to złe rozwiązanie
	public void SaveToPdf()
		=> Console.WriteLine("Saving to PDF...");

	public void SaveToWord()
		=> Console.WriteLine("Saving to Word...");

	// refaktor - zmienić zależnosci tak, aby niezależnie od formatu w którym będzie zapis, klasa będzie spełniać swoją funkcjonalność bez zmian
	// zamiast osobnych metod, lepsza jest 1 generyczna metoda, która będzie polegać na abstrakcji do zapisu w konkretnym formacie
	public void Save()
		=> _invoiceSaver.Save(_invoice);

	// teraz klasa jest otwarta na rozszerzenie i zamknięta na modyfikacje:
	// dodanie innego typu zapisu faktury nie wymaga żadnych zmian w tej klasie

	// to jest przykład na poziomie klasy
}