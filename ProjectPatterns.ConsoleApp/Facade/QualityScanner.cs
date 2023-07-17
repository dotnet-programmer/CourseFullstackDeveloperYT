namespace DesignPatterns.ConsoleApp.Facade;

internal class QualityScanner
{
	public IEnumerable<string> QualityScan(string githubUrl)
	{
		Console.WriteLine("Quality scan");
		return new List<string>() { "Quality error1", "Quality error2" };
	}
}