namespace SolidPrinciples.ConsoleApp.SingleResponsibility;

// klasa InvoiceLogger ma tylko 1 odpowiedzialność - wyświetlanie danych

internal class InvoiceLogger(Invoice invoice)
{
	private readonly Invoice _invoice = invoice;

	public void Display()
	{
		Console.WriteLine($"Vendor: {_invoice.Vendor}");
		Console.WriteLine($"Vendee: {_invoice.Vendee}");
		Console.WriteLine($"Total: {_invoice.Total}");
	}
}