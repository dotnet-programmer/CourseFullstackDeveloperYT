namespace DesignPatterns.ConsoleApp.Facade;

internal class ScanFacade
{
	private readonly QualityScanner _qualityScanner = new();
	private readonly SecurityScanner _securityScanner = new();
	private readonly DependencyScanner _dependencyScanner = new();
	private readonly ReportGenerator _reportGenerator = new();

	public void Scan(string githubUrl)
	{
        Console.WriteLine($"Scanning {githubUrl}");
        var qualityScanErrors = _qualityScanner.QualityScan(githubUrl);
		var securityScanErrors = _securityScanner.SecurityScan(githubUrl);
		var dependencyScanErrors = _dependencyScanner.DependencyScan(githubUrl);

		Console.WriteLine("Scan report:");
		_reportGenerator.GenerateReport(qualityScanErrors, securityScanErrors, dependencyScanErrors);
	}
}