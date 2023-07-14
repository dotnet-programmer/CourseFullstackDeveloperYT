namespace SolidPrinciples.ConsoleApp.LiskovSubstitution;

internal class Rectangle
{
	protected int _height;
	protected int _width;

	public virtual void SetHeight(int height) => _height = height;

	public virtual void SetWidth(int width) => _width = width;
}