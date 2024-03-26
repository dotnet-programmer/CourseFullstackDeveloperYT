namespace DesignPatterns.ConsoleApp.Strategy;

internal class Map(IRouteStrategy routeStrategy)
{
	private readonly IRouteStrategy _routeStrategy = routeStrategy;

	public void CreateRoute(Coordinate start, Coordinate end)
		=> _routeStrategy.CreateRoute(start, end);
}