namespace DesignPatterns.ConsoleApp.Factory;

internal class ShapeFactory
{
	public Shape CreateShape(ShapeType shapeType)
		=> shapeType switch
		{
			ShapeType.Circle => new Circle(),
			ShapeType.Rectangle => new Rectangle(),
			ShapeType.Triangle => new Triangle(),
			_ => throw new InvalidOperationException($"Shape type {shapeType} is not handled")
		};
}