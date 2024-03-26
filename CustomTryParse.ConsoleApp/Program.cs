int inputValue;
while (!StringTryParseToNegativeInt(Console.ReadLine(), out inputValue))
{
	Console.WriteLine("Insert negative number");
}
Console.WriteLine($"Inserted negative number = {inputValue}");

Console.WriteLine();

while (!TryParseToNegativeInt(Console.ReadLine(), out inputValue))
{
	Console.WriteLine("Insert negative number");
}
Console.WriteLine($"Inserted negative number = {inputValue}");

bool StringTryParseToNegativeInt(string text, out int result)
{
	result = default;

	if (text[0] != '-')
	{
		return false;
	}

	for (int i = 1; i < text.Length; i++)
	{
		if (!char.IsDigit(text[i]))
		{
			return false;
		}
	}

	result = int.Parse(text);
	return true;
}

bool TryParseToNegativeInt(string input, out int result)
{
	if (int.TryParse(input, out result))
	{
		return result < 0;
	}
	else
	{
		result = default;
		return false;
	}
}