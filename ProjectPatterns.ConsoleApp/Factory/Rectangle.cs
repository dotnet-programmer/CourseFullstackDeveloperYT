namespace DesignPatterns.ConsoleApp.Factory;

internal class Rectangle : Shape
{
	public override void Render()
		=> Console.WriteLine("Render Rectangle");
}