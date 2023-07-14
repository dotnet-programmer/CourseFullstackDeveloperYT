namespace SolidPrinciples.ConsoleApp.OpenClose.Module;

// przykład przedstawiajacy open-close na poziomie modułu

// napierw złe rozwiązanie - bez użycia polimorfizmu
public enum ShapeType
{
	Circle,
	Rectangle
}

public class Point
{
	public int X { get; set; }
	public int Y { get; set; }
}

internal class ShapeBadSolution
{
	public ShapeType ShapeType { get; set; }
}

internal class CircleBad : ShapeBadSolution
{
	public int Radius { get; set; }
	public Point Center { get; set; }
}

internal class RectangleBad : ShapeBadSolution
{
	public int Width { get; set; }
	public int Height { get; set; }
	public Point TopLeft { get; set; }
}

// ****************************************************************

// dobre rozwiązanie - metoda wirtualna
internal class Shape
{
	public virtual void Render() { }
}

internal class Circle : Shape
{
	public int Radius { get; set; }
	public Point Center { get; set; }
	public override void Render() => Console.Write("Render Circle...");
}

internal class Rectangle : Shape
{
	public int Width { get; set; }
	public int Height { get; set; }
	public Point TopLeft { get; set; }
	public override void Render() => Console.Write("Render Rectangle...");
}