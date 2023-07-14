namespace SolidPrinciples.ConsoleApp.LiskovSubstitution;

// w takiej implementacji nie da się posłużyć kwadratem tak, aby reprezentował dowolny czworokąt
// naruszenie zasady Liskow - nie można traktować kwadratu jako dowolnego czworokąta
internal class Square : Rectangle
{
	public override void SetHeight(int height)
	{
		_width = height;
		_height = height;
	}

	public override void SetWidth(int width)
	{
		_width = width;
		_height = width;
	}
}