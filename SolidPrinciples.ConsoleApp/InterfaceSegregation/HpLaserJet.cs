namespace SolidPrinciples.ConsoleApp.InterfaceSegregation;

internal class HpLaserJet : IPrinter, IScanner, IFaxContent
{
	public void PrintGrey(string content) => Console.WriteLine("Hp laser jet print grey");

	public void PrintColor(string content) => Console.WriteLine("Hp laser jet print color");

	public void Scan(string content) => Console.WriteLine("Hp laser jet print scan");

	public void Fax(string content) => Console.WriteLine("Hp laser jet print fax");
}