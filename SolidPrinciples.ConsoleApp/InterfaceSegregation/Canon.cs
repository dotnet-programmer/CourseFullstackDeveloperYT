namespace SolidPrinciples.ConsoleApp.InterfaceSegregation;

internal class Canon : IPrinter, IFaxContent
{
	public void PrintGrey(string content)
		=> Console.WriteLine("Canon print grey");

	public void PrintColor(string content)
		=> Console.WriteLine("Canon print color");

	// naruszenie segregacji interfejsów
	//public void Scan(string content)
	//	=> throw new NotImplementedException();

	public void Fax(string content)
		=> Console.WriteLine("Canon print fax");
}