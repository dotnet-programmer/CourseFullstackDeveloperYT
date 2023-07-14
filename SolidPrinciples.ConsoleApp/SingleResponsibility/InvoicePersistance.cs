namespace SolidPrinciples.ConsoleApp.SingleResponsibility;

// klasa InvoicePersistance ma tylko 1 odpowiedzialność - zapis danych do pliku

internal class InvoicePersistance
{
	private readonly Invoice _invoice;

	public InvoicePersistance(Invoice invoice) => _invoice = invoice;

	public void SaveToPdf() => Console.WriteLine("Saving to PDF...");
}