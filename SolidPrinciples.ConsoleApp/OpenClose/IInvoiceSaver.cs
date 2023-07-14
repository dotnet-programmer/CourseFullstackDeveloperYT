using SolidPrinciples.ConsoleApp.SingleResponsibility;

namespace SolidPrinciples.ConsoleApp.OpenClose;

internal interface IInvoiceSaver
{
	void Save(Invoice invoice);
}