namespace SolidPrinciples.ConsoleApp.InterfaceSegregation;

// taki duży interfejs narusza zasadę ISP - nie każda drukarka będzie miała skan lub fax
internal interface IPrinterBad
{
	void PrintGrey(string content);

	void PrintColor(string content);

	void Scan(string content);

	void Fax(string content);
}

// *************************************************************

// rozdzielenie jednego dużego interfejsu na kilka mniejszych:

internal interface IPrinter
{
	void PrintGrey(string content);

	void PrintColor(string content);
}

internal interface IScanner
{
	void Scan(string content);
}

internal interface IFaxContent
{
	void Fax(string content);
}