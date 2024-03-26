namespace SolidPrinciples.ConsoleApp.SingleResponsibility;

// klasa InvoicePersistance ma tylko 1 odpowiedzialność - zapis danych do pliku

internal class InvoicePersistance(Invoice invoice)
{
	private readonly Invoice _invoice = invoice;

	public void SaveToPdf()
		=> Console.WriteLine("Saving to PDF...");
}