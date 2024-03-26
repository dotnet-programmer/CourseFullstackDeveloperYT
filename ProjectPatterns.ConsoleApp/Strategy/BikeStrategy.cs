namespace DesignPatterns.ConsoleApp.Strategy;

internal class BikeStrategy : IRouteStrategy
{
	public void CreateRoute(Coordinate start, Coordinate end)
		=> Console.WriteLine("Bike strategy");
}