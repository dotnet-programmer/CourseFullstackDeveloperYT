namespace DesignPatterns.ConsoleApp.Factory;

internal class Triangle : Shape
{
	public override void Render()
		=> Console.WriteLine("Render Triangle");
}