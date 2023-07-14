using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.ConsoleApp.LiskovSubstitution;
internal class CityDuck : Duck
{
	public override void Quack() => Console.Write("City duck swim");
	public override void Swim() => Console.Write("City duck quack");
	public override void Fly() => Console.Write("City duck fly");
}
