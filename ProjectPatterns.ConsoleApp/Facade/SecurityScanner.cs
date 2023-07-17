namespace DesignPatterns.ConsoleApp.Facade;

internal class SecurityScanner
{
	public IEnumerable<string> SecurityScan(string githubUrl)
	{
		Console.WriteLine("Security scan");
		return new List<string>() { "Security error1", "Security error2" };
	}
}