namespace DesignPatterns.ConsoleApp.Strategy;

internal interface IRouteStrategy
{
	void CreateRoute(Coordinate start, Coordinate end);
}