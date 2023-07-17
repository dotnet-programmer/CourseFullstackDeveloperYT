namespace DesignPatterns.ConsoleApp.Facade;

internal class DependencyScanner
{
	public IEnumerable<string> DependencyScan(string githubUrl)
	{
		Console.WriteLine("Dependency scan");
		return new List<string>() { "Dependency error1", "Dependency error2" };
	}
}