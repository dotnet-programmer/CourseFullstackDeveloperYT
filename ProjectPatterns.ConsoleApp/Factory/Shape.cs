namespace DesignPatterns.ConsoleApp.Factory;

public abstract class Shape
{
	public int X { get; set; }
	public int Y { get; set; }

	public abstract void Render();
}