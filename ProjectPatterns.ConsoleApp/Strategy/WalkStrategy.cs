namespace DesignPatterns.ConsoleApp.Strategy;

internal class WalkStrategy : IRouteStrategy
{
	public void CreateRoute(Coordinate start, Coordinate end) => Console.WriteLine("Walk strategy");
}