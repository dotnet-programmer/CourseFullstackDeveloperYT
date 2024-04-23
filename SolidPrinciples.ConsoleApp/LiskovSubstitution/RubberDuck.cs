namespace SolidPrinciples.ConsoleApp.LiskovSubstitution;

internal class RubberDuck : Duck
{
	public override void Quack()
		=> Console.Write("Rubber duck quack");

	public override void Swim()
		=> Console.Write("Rubber duck swim");

	// naruszenie zasady Liskov - gumowa kaczka nie lata więc nie jesteśmy w stanie zaimplementować metody Fly w prawidłowy sposób
	// wszędzie tam gdzie klasy pochodne nie są w stanie spełnić lub reprezentować klasę bazową to jest naruszenie zasady podstawiania Liskov
	public override void Fly()
		=> throw new NotImplementedException();
}