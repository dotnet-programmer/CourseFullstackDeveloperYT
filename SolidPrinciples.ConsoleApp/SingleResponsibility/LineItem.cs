namespace SolidPrinciples.ConsoleApp.SingleResponsibility;

internal class LineItem
{
	public string Name { get; set; }
	public decimal Price { get; set; }
	public int Count { get; set; }
	public int TaxRate { get; set; }
}