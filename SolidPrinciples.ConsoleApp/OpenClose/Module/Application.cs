namespace SolidPrinciples.ConsoleApp.OpenClose.Module;

internal class Application
{
	// to jest zły kod, nie da się go rozszerzyć o nowe kształty bez zmian w tym kodzie
	public void RenderBadSolution(List<ShapeBadSolution> shapes)
	{
		for (int i = 0; i < shapes.Count; i++)
		{
			ShapeType type = shapes[i].ShapeType;
			switch (type)
			{
				case ShapeType.Circle:
					RenderCircle((CircleBad)shapes[i]);
					break;
				case ShapeType.Rectangle:
					RenderRectangle((RectangleBad)shapes[i]);
					break;
				default:
					break;
			}
		}
	}
	private void RenderCircle(CircleBad circle) => Console.WriteLine("Render circle...");
	private void RenderRectangle(RectangleBad rectangle) => Console.WriteLine("Render rectangle...");


	// to jest dobre rozwiązanie - użycie polimorfizmu
	// można dodać dowolną ilosć nowych kształtów bez zmian w sposobie działania tego kodu
	public void RenderGoodSolution(List<Shape> shapes)
	{
		for (int i = 0; i < shapes.Count; i++)
		{
			shapes[i].Render();
		}
	}
}