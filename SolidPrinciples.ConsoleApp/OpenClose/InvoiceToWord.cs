using SolidPrinciples.ConsoleApp.SingleResponsibility;

namespace SolidPrinciples.ConsoleApp.OpenClose;

internal class InvoiceToWord : IInvoiceSaver
{
	public void Save(Invoice invoice)
		=> Console.WriteLine("Saving invoice as word");
}