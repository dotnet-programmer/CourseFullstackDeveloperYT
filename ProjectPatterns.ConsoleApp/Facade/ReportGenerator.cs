namespace DesignPatterns.ConsoleApp.Facade;

internal class ReportGenerator
{
	public void GenerateReport(IEnumerable<string> qualityScanErrors, IEnumerable<string> securityScanErrors, IEnumerable<string> dependencyScanErrors)
	{
		Console.WriteLine("Quality Scan Errors:");
		Console.WriteLine(string.Join(", ", qualityScanErrors));

		Console.WriteLine("Security Scan Errors:");
		Console.WriteLine(string.Join(", ", securityScanErrors));

		Console.WriteLine("Dependency Scan Errors:");
		Console.WriteLine(string.Join(", ", dependencyScanErrors));
	}
}