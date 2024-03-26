int sum = 0;
int? max = null;

while (true)
{
	Console.Write("Write a number, 0 ends data entry: ");
	int input = int.Parse(Console.ReadLine());

	if (input == 0)
	{
		break;
	}

	if (max == null || input > max)
	{
		max = input;
	}

	sum += input;
}

Console.WriteLine($"Sum = {sum}");
Console.WriteLine(max != null ? $"Max = {max}" : "No values inserted");