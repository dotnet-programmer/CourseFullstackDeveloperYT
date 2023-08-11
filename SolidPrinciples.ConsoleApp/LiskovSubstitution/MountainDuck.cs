namespace SolidPrinciples.ConsoleApp.LiskovSubstitution;

internal class MountainDuck : Duck
{
	public override void Quack() => Console.Write("Mountain duck swim");

	public override void Swim() => Console.Write("Mountain duck quack");

	public override void Fly() => Console.Write("Mountain duck fly");
}