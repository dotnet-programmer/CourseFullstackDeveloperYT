using SolidPrinciples.ConsoleApp.SingleResponsibility;

namespace SolidPrinciples.ConsoleApp.OpenClose;

internal class InvoiceToPdf : IInvoiceSaver
{
	public void Save(Invoice invoice) => Console.WriteLine("Saving invoice as pdf");
}