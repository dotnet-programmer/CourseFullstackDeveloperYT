namespace SolidPrinciples.ConsoleApp.LiskovSubstitution;

internal class CityDuck : Duck
{
	public override void Quack() => Console.Write("City duck swim");

	public override void Swim() => Console.Write("City duck quack");

	public override void Fly() => Console.Write("City duck fly");
}